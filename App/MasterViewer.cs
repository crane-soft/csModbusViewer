using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csModbusLib;
using csModbusView;

namespace csModbusViewer
{
    class MasterViewer : ViewerBase
    {
        private MbMaster ModMaster;
        private bool doRefreshStop;
        private bool RefreshRunning;
        private System.Timers.Timer sysRefreshTimer;

        public MasterViewer()
        {
            ModMaster = new MbMaster();
            sysRefreshTimer = new System.Timers.Timer();
            sysRefreshTimer.Enabled = false;
            sysRefreshTimer.AutoReset = false;
            sysRefreshTimer.Interval = 50;
            sysRefreshTimer.Elapsed += OnSystemTimedEvent;
        }

        protected override void InitViewList()
        {
            foreach (MasterGridView mbView in _ModbusViewList) {
                mbView.InitGridView(ModMaster);
            }
        }

        public override bool IsConnected()
        {
            return ModMaster.IsConnected;
        }

        public override bool Connect()
        {
            if (ModMaster.Connect(modbusConnection, SlaveID)) {
                sysRefreshTimer.Enabled = true;
                RefreshRunning = true;
                return true;
            }
            return false;
        }

        public override void CloseConnection()
        {
            if (RefreshRunning) {
                doRefreshStop = true;
            } else {
                ModMaster.Close();
            }
       }

        private void OnSystemTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (doRefreshStop) {
                ModMaster.Close();
                doRefreshStop = false;
                RefreshRunning = false;
            } else {
                csModbusLib.ErrorCodes ErrCode;
                ErrCode = RequestData();
                if (doRefreshStop == false) {
                    DisplayErrorCode(ErrCode);
                }
                sysRefreshTimer.Enabled = true;
            }
        }

        private csModbusLib.ErrorCodes RequestData()
        {
            csModbusLib.ErrorCodes ErrCode;

            foreach (MasterGridView mbView in _ModbusViewList) {
                ErrCode = mbView.Update_ModbusData();
                if (ErrCode != ErrorCodes.NO_ERROR)
                    return ErrCode;
            }
            return ErrorCodes.NO_ERROR;
        }

        public override ExceptionCodes GetModusException()
        {
            return ModMaster.GetModusException();
        }

        protected override MbInterface TCPInterface(string hostName, int port)
        {
            ConnectionInfo = string.Format("TCP {0}:{1}", hostName, port);
            return new MbTCPMaster(hostName, port);
        }

        protected override MbInterface UDPInterface(string hostName, int port)
        {
            ConnectionInfo = string.Format("UDP {0}:{1}", hostName, port);
            return new MbUDPMaster(hostName, port);
        }
    }
}
