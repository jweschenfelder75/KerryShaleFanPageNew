using System;
using de.jweschenfelder.KSFP.Shared.Enums;

namespace de.jweschenfelder.KSFP.Shared.Events
{
    public class ServerStatusEventArgs : EventArgs
    {
        public ServerStatusEnum ServerStatus { get; set; } = ServerStatusEnum.None;
    }
}
