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

        private System.Timers.Timer sysRefreshTimer;

        public MasterViewer()
        {
            ModMaster = new MbMaster();
            sysRefreshTimer = new System.Timers.Timer();
            sysRefreshTimer.Enabled = false;
            sysRefreshTimer.AutoReset = false;
            sysRefreshTimer.Interval = 20;
            sysRefreshTimer.Elapsed += OnSystemTimedEvent;

        }

        public override void SetViewList(List<ModbusView> ViewList)
        {
            base.SetViewList(ViewList);
            foreach (MasterGridView mbView in ModbusViewList) {
                mbView.InitGridView(ModMaster);
            }
        }

        public override bool IsConnected()
        {
            return ModMaster.IsConnected;
        }

        public override bool Connect()
        {
            if (ModMaster.Connect(modbusConnection, 1)) {
                sysRefreshTimer.Enabled = true;
                return true;
            }
            return false;
        }

        public override void Close()
        {
            sysRefreshTimer.Enabled = false;
            ModMaster.Close();
        }

        private void OnSystemTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            sysRefreshTimer.Enabled = false;
            csModbusLib.ErrorCodes ErrCode;
            ErrCode = RequestData();
            DisplayErrorCode(ErrCode);
            sysRefreshTimer.Enabled = true;
        }

        private csModbusLib.ErrorCodes RequestData()
        {
            csModbusLib.ErrorCodes ErrCode;

            foreach (MasterGridView mbView in ModbusViewList) {
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
            return new MbTCPMaster(hostName, port);
        }

        protected override MbInterface UDPInterface(string hostName, int port)
        {
            return new MbUDPMaster(hostName, port);
        }
    }
}
