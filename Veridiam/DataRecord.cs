using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veridiam
{
    internal class DataRecord
    {
        public DataRecord() 
        {
            
            // Limit status
            // Current Position

        }
    }

    internal class MechConfig
    {
        public int numberOfAxis { get; }
        public string[] axisDesignation { get; set; }
        public int[] acceleration { get; set; }
        public int[] deceleration { get; set; }
        public double[] scalingDivider { get; set; }
        public int[] p { get; set; }
        public int[] i { get; set; }
        public int[] d { get; set; }
        public bool[] axisUseLimits { get; set; }

        public MechConfig(int numberOfAxis) 
        {
            this.numberOfAxis = numberOfAxis;
            axisDesignation = new string[numberOfAxis];
            acceleration = new int[numberOfAxis];
            deceleration = new int[numberOfAxis];
            scalingDivider = new double[numberOfAxis];
            p = new int[numberOfAxis];
            i = new int[numberOfAxis];
            d = new int[numberOfAxis];
            axisUseLimits = new bool[numberOfAxis];
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            try
            {
                FileStream fileStream = new FileStream("default.cfg", FileMode.Open);
                while (fileStream.Position < fileStream.Length)
                {
                    // load whatever
                }
            }
            catch (FileNotFoundException) 
            { 
                // default file not found, load hard-coded defaults
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
        
        public ScanData(int numberOfDataPoints)
        {

        }
    }

}
