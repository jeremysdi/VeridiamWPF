using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Veridiam
{
    internal class DataRecord
    {
        MechConfig MechConfig { get; }
        ScanParameters ScanParameters { get; }
        ScanData ScanData { get; }
        SystemStatus Status { get; }
        public DataRecord(int numberOfAxis, int numberOfTransducers)
        {
            MechConfig = new MechConfig(numberOfAxis);

        }
    }

    // Values for setting up motion
    internal class MechConfig
    {
        public int NumberOfAxis { get; }
        public string[] AxisDesignation { get; set; }
        public int[] Acceleration { get; set; }
        public int[] Deceleration { get; set; }
        public double[] ScalingDivider { get; set; }
        public int[] P { get; set; }
        public int[] I { get; set; }
        public int[] D { get; set; }
        public bool[] AxisUseLimits { get; set; }

        public MechConfig(int numberOfAxis)
        {
            this.NumberOfAxis = numberOfAxis;
            AxisDesignation = new string[numberOfAxis];
            Acceleration = new int[numberOfAxis];
            Deceleration = new int[numberOfAxis];
            ScalingDivider = new double[numberOfAxis];
            P = new int[numberOfAxis];
            I = new int[numberOfAxis];
            D = new int[numberOfAxis];
            AxisUseLimits = new bool[numberOfAxis];
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            try
            {
                FileStream fileStream = new FileStream("default.cfg", FileMode.Open);
                StreamReader sr = new StreamReader(fileStream);

                // Hardcoded

                // Axis Designation
                string[] line = sr.ReadLine().Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    AxisDesignation[i] = line[i];
                }

                // Acceleration
                line = sr.ReadLine().Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    Acceleration[i] = int.Parse(line[i]);
                }

                // Deceleration
                line = sr.ReadLine().Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    Deceleration[i] = int.Parse(line[i]);
                }

                // Scaling Divider
                line = sr.ReadLine().Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    ScalingDivider[i] = int.Parse(line[i]);
                }

                // P
                line = sr.ReadLine().Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    P[i] = int.Parse(line[i]);
                }

                // I
                line = sr.ReadLine().Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    I[i] = int.Parse(line[i]);
                }

                // D
                line = sr.ReadLine().Split(',');
                for (int i = 0; i < line.Length; i++)
                {
                    D[i] = int.Parse(line[i]);
                }
            }
            catch (FileNotFoundException)
            {
                // default file not found, load hard-coded defaults
                MessageBox.Show("Could not find default.cfg file");
            }
            catch (Exception err)
            {
                MessageBox.Show("default.cfg did not load properly");
            }
        }
    }

    // Values for setting up scan
    internal class ScanParameters
    {
        public int ScanSpeed { get; set; }
        public double IndexIncrement { get; set; }
        public double ScanIncrement { get; set; }
        public double PartLength { get; set; }
        public double PartDiameter { get; set; }
        public double[] ScanStartPosition { get; set; }
        public double[] ScanEndPosition { get; set; }

        public ScanParameters()
        {
            
        }
    }

    // ScanData manages a data file that has raw data, used to write data during scan
    internal class ScanData
    {
        private StreamWriter FileWriter = null;
        private readonly string defaultFileName = "data.frm";
        private readonly object WriteScanLock = new object();
        private bool WritingScanData = false;
        private int writeCount = 0;
        private Queue<ushort[]> WriteDataQueue = new Queue<ushort[]>();
        private Task WriteTask = null;
        public ScanData()
        {
            // write it all to a data file, only header is the number of dataPoints
            
        }

        private void FileWriteTask()
        {
            FileStream fileStream = new FileStream(defaultFileName, FileMode.Create);
            FileWriter = new StreamWriter(fileStream);

            while (WritingScanData)
            {
                if (WriteDataQueue.Count > 0)
                {
                    ushort[] frame = WriteDataQueue.Dequeue();
                    FileWriter.Write(frame.Length);
                    foreach (ushort i in frame) { FileWriter.Write(i); }
                }
            }

            FileWriter.Flush();
            FileWriter.Close();
        }

        public void ScanStart()
        {
            lock (WriteScanLock)
            {
                if (!WritingScanData)
                {
                    WritingScanData = true;
                    writeCount = 0;
                    // run write scan data task
                    WriteTask = Task.Run(() => FileWriteTask());
                }
            }
            
            // else send message, already scanning
        }

        public void WriteData(ushort[] frame)
        {
            lock (WriteScanLock)
            {
                if (WritingScanData)
                {

                    writeCount++;
                }
            }
            
            // else send message, not currently scanning
        }

        public void ScanComplete()
        {
            if (WritingScanData)
            {
                
                WritingScanData = false;
            }
            // else send message, not currently scanning

            // can now read/compile 
        }
    }

    // SystemStatus keeps track of data that is checked frequently, using locks for multithreaded access
        // -- Limit Status
        // -- Current Position
    internal class SystemStatus
    {
        private readonly object LimitLock = new object();
        private readonly object PositionLock = new object();

        private int NumberOfAxis;
        private bool[] LimitStatus = null;
        private double[] CurrentPosition = null;
        public SystemStatus(int numberOfAxis) 
        { 
            NumberOfAxis = numberOfAxis;
            LimitStatus = new bool[NumberOfAxis];
            CurrentPosition = new double[NumberOfAxis];
        }

        public bool[] GetLimitStatus()
        {
            bool[] copyLimitStatus = new bool[NumberOfAxis];
            lock (LimitLock)
            {
                Array.Copy(LimitStatus, copyLimitStatus, NumberOfAxis);
            }
            return copyLimitStatus;
        }

        public void SetLimitStatus(bool[] limitStatus) 
        { 
            lock (LimitLock)
            {
                LimitStatus = limitStatus;
            }
        }

        public double[] GetCurrentPosition()
        {
            double[] copyCurrentPosition = new double[NumberOfAxis];
            lock (PositionLock)
            {
                Array.Copy(CurrentPosition, copyCurrentPosition, NumberOfAxis);
            }
            return copyCurrentPosition;
        }

        public void SetCurrentPosition(double[] currentPosition)
        {
            lock (PositionLock)
            {
                CurrentPosition = currentPosition;
            }
        }
    }

}
