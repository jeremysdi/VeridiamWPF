using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veridiam
{
    internal class GalilHandler
    {
        static readonly gclib g = new gclib();
        internal static int Connect()
        {
            try
            {
                g.GOpen("I NEED AN IPADRESS SOMEHOW!");
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        internal static int Disconnect()
        {
            try
            {
                g.GClose();
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        internal static int ServoOn()
        {
            try
            {
                g.GCommand("SH");
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        internal static int ServoOff()
        {
            try
            {
                g.GCommand("MO");
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        internal static int Reset()
        {
            try
            {
                g.GCommand("CB 1");
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
}
