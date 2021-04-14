using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chat.client
{
    public enum FestivalUserEvent
    {
        TicketBought
    } ;
    public class FestivalUserEventArgs : EventArgs
    {
        private readonly FestivalUserEvent userEvent;
        private readonly Object data;

        public FestivalUserEventArgs(FestivalUserEvent userEvent, object data)
        {
            this.userEvent = userEvent;
            this.data = data;
        }

        public FestivalUserEvent UserEventType
        {
            get { return userEvent; }
        }

        public object Data
        {
            get { return data; }
        }
    }
}