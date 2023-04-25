using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veridiam
{
    internal class ScanSystem
    {
        GalilHandler gal = new GalilHandler();
        public static int Connect()
        {
            return GalilHandler.Connect();
        }
        internal static int Disconnect()
        {
            return GalilHandler.Disconnect();
        }
    }
}
