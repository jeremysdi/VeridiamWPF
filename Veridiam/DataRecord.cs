using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Veridiam
{
    internal class DataRecord
    {
        MechConfig MechConfig { get; }
        public DataRecord(int numberOfAxis, int numberOfTransducers) 
        {
            MechConfig = new MechConfig(numberOfAxis);
            // Limit status
            // Current Position

        }
    }

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

    internal class ScanParameters
    {
        public ScanParameters()
        {
            // Scan Speed
            // Index Axis Increment
            // Scan Axis Increment
            // Part Length
            // Part Diameter
            // Scan start position
            // scan end position
        }
    }

    internal class ScanData
    {
        private StreamWriter FileWriter = null;
        public ScanData(int numberOfDataPoints)
        {
            // write it all to a data file, only header is the number of dataPoints
            FileStream fileStream = new FileStream("data.frm", FileMode.Create);
            FileWriter = new StreamWriter(fileStream);
            FileWriter.Write(numberOfDataPoints);
        }

        public void WriteData(ushort[] frame)
        {
            FileWriter.Write(frame.Length);
            foreach (ushort i in frame) { FileWriter.Write(i); }
        }

        public void ScanComplete()
        {
            FileWriter.Flush();
            FileWriter.Close();
        }
    }

}
