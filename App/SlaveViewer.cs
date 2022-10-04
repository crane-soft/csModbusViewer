﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using csModbusLib;
using csModbusView;

namespace csModbusViewer
{
    class SlaveViewer : ViewerBase
    {
        public delegate void ValueChanged_Delegate(object sender , ModbusData.ModbusValueEventArgs e);
        public event ValueChanged_Delegate ValueChanged_Event;

        private MbSlaveServer modSlave;
        private StdDataServer MyDataServer;
        private bool ListenStarted = false;

        public SlaveViewer()
        {
            modSlave = new MbSlaveServer();
        }

        public override void SetViewList(List<ModbusView> ViewList)
        {
            base.SetViewList(ViewList);
            MyDataServer = new StdDataServer();

            foreach (SlaveGridView mbView in ModbusViewList) {
                mbView.AddDataToServer(MyDataServer);
                mbView.ValueChangedEvent += MBGridView_ValueChanged;
                mbView.ValueReadEvent += MBGridView_ValueChanged;
            }
        }

        private void MBGridView_ValueChanged(object sender, ModbusData.ModbusValueEventArgs e)
        {
            ValueChanged_Event?.Invoke(sender, e);
        }

        public override bool IsConnected()
        {
            return ListenStarted;
        }

        public override bool Connect()
        {
            ListenStarted = modSlave.StartListen(modbusConnection, MyDataServer);
            return ListenStarted;
        }

        public override void Close()
        {
            modSlave.StopListen();
        }


        public override ExceptionCodes GetModusException()
        {
            return ExceptionCodes.NO_EXCEPTION;
        }

        protected override MbInterface TCPInterface(string hostName, int port)
        {
            throw new NotImplementedException();
        }

        protected override MbInterface UDPInterface(string hostName, int port)
        {
            throw new NotImplementedException();
        }
    }
}
