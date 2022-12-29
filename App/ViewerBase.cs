using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csModbusViewer.Properties;
using csModbusLib;
using csModbusView;

namespace csModbusViewer
{
    abstract class ViewerBase
    {
        protected bool Running = false;
        protected csModbusLib.ConnectionType InterfaceType = ConnectionType.NO_CONNECTION;
        protected MbInterface modbusConnection;
        public string ConnectionInfo { get; protected set; }
        protected List<ModbusView> _ModbusViewList;
        protected byte SlaveID;
        public delegate void DisplayErrorCode_Delegate(csModbusLib.ErrorCodes ErrCode);
        public event DisplayErrorCode_Delegate ErrorCodeEvent;

        public ViewerBase()
        {
        }

        public List<ModbusView> ModbusViewList {
            get {
                return _ModbusViewList;
            }
            set {
                _ModbusViewList = value;
                InitViewList();
            }
        }

        protected abstract void InitViewList();
        public abstract bool IsConnected();
        public abstract bool Connect();
        public abstract void CloseConnection();
        public abstract ExceptionCodes GetModusException();

        public void Close()
        {
            foreach (ModbusView mbView in _ModbusViewList) {
                mbView.Dispose();
            }
            _ModbusViewList.Clear();
        }

        protected void DisplayErrorCode(csModbusLib.ErrorCodes ErrCode)
        {
            ErrorCodeEvent?.Invoke(ErrCode);
        }

        public csModbusLib.ConnectionType InitConnection()
        {
            switch (Settings.Default.Connection) {
                case "RTU": {
                        InterfaceType = csModbusLib.ConnectionType.SERIAL_RTU;
                        modbusConnection = new MbRTU(Settings.Default.ComPort, Settings.Default.Baudrate);
                        ConnectionInfo = string.Format("RTU {0},{1}", Settings.Default.ComPort, Settings.Default.Baudrate);
                        break;
                    }

                case "ASCII": {
                        InterfaceType = csModbusLib.ConnectionType.SERIAL_ASCII;
                        modbusConnection = new MbASCII(Settings.Default.ComPort, Settings.Default.Baudrate);
                        ConnectionInfo = string.Format("ASCII {0},{1}", Settings.Default.ComPort, Settings.Default.Baudrate);
                        break;
                    }

                case "TCP": {
                        InterfaceType = csModbusLib.ConnectionType.TCP_IP;
                        modbusConnection = TCPInterface(Settings.Default.Hostname, Settings.Default.TCPport);
                        break;
                    }

                case "UDP": {
                        InterfaceType = csModbusLib.ConnectionType.UDP_IP;
                        modbusConnection = UDPInterface(Settings.Default.Hostname, Settings.Default.TCPport);
                        break;
                    }

                default: {
                        MessageBox.Show(Settings.Default.Connection + "\r\n" + "not supported");
                        ConnectionInfo = "";
                        InterfaceType = ConnectionType.NO_CONNECTION;
                        break;
                    }
            }
            SlaveID =  (byte) Settings.Default.SlaveID;
            ConnectionInfo += string.Format(" ID:{0}", SlaveID);
            return InterfaceType;
        }

        protected abstract MbInterface TCPInterface(string hostName, int port);
        protected abstract MbInterface UDPInterface(string hostName, int port);
    }
}

