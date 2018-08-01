using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.Main;

namespace HID_USB_Form
{
    public partial class Form1 : Form
    {
        public static DateTime LastDataEventDate = DateTime.Now;
        public static UsbDevice MyUsbDevice;
        private static ErrorCode ec = ErrorCode.None;
        UsbEndpointReader reader;
        UsbEndpointWriter writer;
        private static List<string> USB_data = new List<string>();

       // private static bool RXReady = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UsbRegDeviceList allDevices = UsbDevice.AllDevices;
            foreach (UsbRegistry usbRegistry in allDevices)
            {
                if (usbRegistry.Open(out MyUsbDevice))
                {
                    logBox.AppendText(MyUsbDevice.Info.ToString());
                    for (int iConfig = 0; iConfig < MyUsbDevice.Configs.Count; iConfig++)
                    {
                        UsbConfigInfo configInfo = MyUsbDevice.Configs[iConfig];
                        logBox.AppendText(configInfo.ToString());

                        ReadOnlyCollection<UsbInterfaceInfo> interfaceList = configInfo.InterfaceInfoList;
                        for (int iInterface = 0; iInterface < interfaceList.Count; iInterface++)
                        {
                            UsbInterfaceInfo interfaceInfo = interfaceList[iInterface];
                            logBox.AppendText(interfaceInfo.ToString());

                            ReadOnlyCollection<UsbEndpointInfo> endpointList = interfaceInfo.EndpointInfoList;
                            for (int iEndpoint = 0; iEndpoint < endpointList.Count; iEndpoint++)
                            {
                                logBox.AppendText(endpointList[iEndpoint].ToString());
                            }
                        }
                    }
                }
            }

            try
            {
                UsbDeviceFinder MyUsbFinder = new UsbDeviceFinder(0x0483, 0x5750);
                MyUsbDevice = UsbDevice.OpenUsbDevice(MyUsbFinder);

                if (MyUsbDevice == null) throw new Exception("Device Not Found.");

                IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                if (!ReferenceEquals(wholeUsbDevice, null))
                {
                    // Select config #1
                    wholeUsbDevice.SetConfiguration(1);

                    // Claim interface #0.
                    wholeUsbDevice.ClaimInterface(0);
                }

                reader = MyUsbDevice.OpenEndpointReader(ReadEndpointID.Ep01, 8, EndpointType.Interrupt);

                writer = MyUsbDevice.OpenEndpointWriter(WriteEndpointID.Ep01, EndpointType.Interrupt);

                reader.DataReceived += (OnRxEndPointData);
                reader.DataReceivedEnabled = true;
                USBcmdTimer.Start();

            }
            catch (Exception ex)
            {
                logBox.AppendText("\r\n");
                logBox.AppendText((ec != ErrorCode.None ? ec + ":" : String.Empty) + ex.Message);
            }
        }

        private static void OnRxEndPointData(object sender, EndpointDataEventArgs e)
        {
            LastDataEventDate = DateTime.Now;
            USB_data.Add(LastDataEventDate.ToString() + ": " + Encoding.Default.GetString(e.Buffer, 0, e.Count));
          //  RXReady = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logBox.AppendText("-------------USB Custom HID Loopback testing: 8 bytes, 15 repeats-------------");
            string cmdLine = "PD2 119\n";

            int bytesWritten;
            byte[] btwr = Encoding.Default.GetBytes(cmdLine);
            int numTransfers = 16;

            for (int i = 0; i < numTransfers; i++)
            {
                ec = writer.Write(btwr, 0, reader.ReadBufferSize, 2000, out bytesWritten);
                if (ec != ErrorCode.None || bytesWritten < reader.ReadBufferSize) throw new Exception(UsbDevice.LastErrorString);
            }

            LastDataEventDate = DateTime.Now;
            while ((DateTime.Now - LastDataEventDate).TotalMilliseconds < 1000)
            {
            }

            logBox.AppendText("\r\nDone!\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            USBcmdTimer.Stop();
            if (reader.DataReceivedEnabled)
            {
                reader.DataReceivedEnabled = false;
                reader.DataReceived -= (OnRxEndPointData);
            }
            if (MyUsbDevice != null)
            {
                if (MyUsbDevice.IsOpen)
                {
                    IUsbDevice wholeUsbDevice = MyUsbDevice as IUsbDevice;
                    if (!ReferenceEquals(wholeUsbDevice, null))
                    {
                        // Release interface #0.
                        wholeUsbDevice.ReleaseInterface(0);
                    }
                    MyUsbDevice.Close();
                }
            }
            MyUsbDevice = null;

            UsbDevice.Exit();

            Close();
        }

        private void USBcmdTimer_Tick(object sender, EventArgs e)
        {
            if (USB_data.Count>0)
            {
                logBox.AppendText(USB_data[0]);
                USB_data.RemoveAt(0);
            }
        }

        private void buttonUSBcmd_Click(object sender, EventArgs e)
        {
            logBox.AppendText("-------------USB Custom HID Command testing: -------------");
            string cmdLine = "PD"+channelBox.Text+" "+ pwmBox.Text + "\n";

            int bytesWritten;
            byte[] btwr = Encoding.Default.GetBytes(cmdLine);

            ec = writer.Write(btwr, 0, reader.ReadBufferSize, 2000, out bytesWritten);
            if (ec != ErrorCode.None || bytesWritten < reader.ReadBufferSize) throw new Exception(UsbDevice.LastErrorString);

            logBox.AppendText("\r\nDone!\r\n");
        }
    }
}
