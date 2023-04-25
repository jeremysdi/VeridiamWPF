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
        
        #region Galil Specific
        public static int Connect()
        {
            return GalilHandler.Connect();
        }
        internal static int Disconnect()
        {
            return GalilHandler.Disconnect();
        }
        internal static int ServoOn()
        {
            return GalilHandler.ServoOn();
        }
        internal static int ServoOff()
        {
            return GalilHandler.ServoOff();
        }
        internal static int Reset()
        {
            return GalilHandler.Reset();
        }

        internal static void JogBack()
        {
            throw new NotImplementedException();
        }

        internal static void Jog()
        {
            throw new NotImplementedException();
        }

        internal static void FullStepBack()
        {
            throw new NotImplementedException();
        }

        internal static void FullStep()
        {
            throw new NotImplementedException();
        }

        internal static void TenStep()
        {
            throw new NotImplementedException();
        }

        internal static void TenStepBack()
        {
            throw new NotImplementedException();
        }

        internal static void HundoStep()
        {
            throw new NotImplementedException();
        }

        internal static void HundoStepBack()
        {
            throw new NotImplementedException();
        }

        internal static void ThouStep()
        {
            throw new NotImplementedException();
        }

        internal static void ThouStepBack()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
