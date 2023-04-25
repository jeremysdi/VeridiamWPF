using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Socomate;

namespace Veridiam
{
    internal class SocomateHandler
    {
        int numberOfChannels;

        public SocomateHandler(int numberOfChannels)
        {
            this.numberOfChannels = numberOfChannels;
        }

        // Connecting to and configuring the device
        public string Connect()
        {
            string message = string.Empty;
            try
            {
                SIDEV.SI_Open(2);
                string channelMessage;
                for (int i = 0; i < numberOfChannels; i++)
                {
                    channelMessage = Configure(i);
                    if (!string.IsNullOrEmpty(channelMessage))
                    {
                        message += channelMessage + ". \n";
                    }
                }
            }
            catch (Exception err)
            {
                message = err.Message;
            }
            return message;
        }
        private string Configure(int channel)
        {
            string message = string.Empty;
            try
            {
                int acquired = 0, status = 0;
                int sizeOfBuffer = 8000;
                int sizeOfFrame = 0;

                SIDEV.SI_Acq_Config(channel, 0, ref sizeOfBuffer, null, 0, 0, null);
                SIDEV.SI_Acq_Get_Status(channel, ref status, ref sizeOfBuffer, ref sizeOfFrame, ref acquired);
            }
            catch (Exception err)
            {
                message = err.Message;
            }
            return message;

        }

        // Disconnecting from the device after clearing properly
        public string Disconnect()
        {
            string message = string.Empty;
            try
            {
                string channelMessage;
                for (int i = 0; i < numberOfChannels; i++)
                {
                    channelMessage = StopAndClear(i);
                    if (!string.IsNullOrEmpty(channelMessage))
                    {
                        message += channelMessage + ". \n";
                    }
                }
            }
            catch (Exception err)
            {
                message = err.Message;
            }
            finally
            {
                SIDEV.SI_Close();
            }
            return message;
        }
        private string StopAndClear(int channel)
        {
            string message = string.Empty;
            try
            {
                SIDEV.SI_Acq_Stop(channel);
                SIDEV.SI_Acq_Clear(channel);
            }
            catch (Exception err)
            {
                message = err.Message;
            }
            return message;
        }

        // Getting one Ascan from the device
        public string GetAscanByChannel(int channel, ref ushort[] frame)
        {
            string message = string.Empty;
            try
            {
                int err;
                int sizeofFrame = 16384;
                ushort[] tempFrame = new ushort[sizeofFrame];
                err = SIDEV.SI_Get_Ascan(channel, channel, tempFrame, ref sizeofFrame, 20);
                if (err == 0 && sizeofFrame > 0)
                {
                    frame = tempFrame;
                }
                else
                {
                    frame = null;
                    message = "Null Frame";
                }
            }
            catch (Exception err)
            {
                message = err.Message;
            }
            return message;
        }
    }
}
