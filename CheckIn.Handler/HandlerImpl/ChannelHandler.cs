using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Handler.HandlerImpl
{
    using CheckIn.Data;
    using CheckIn.Handler.Handler;
    public class ChannelHandler: IChannelHandler
    {
        private readonly CheckInDb CheckInDb;

        public ChannelHandler()
        {
            this.CheckInDb = new CheckInDb();
        }
    }
}
