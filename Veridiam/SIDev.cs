
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace Socomate
{
    class SIDEV
    {
        private const string DLL_FILE_NAME = "sidev_64.dll";

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Open(
          Int32 boot
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Close();

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Load(
           String FileName
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Save(
           String FileName
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Write(
           Int32 Probe,
           Int32 Channel,
           Int32 Unit,
           String ParameterName,
           ref Double Value,
           [In, Out]  Double[] dblArray1,
           [In, Out]  Double[] dblArray2,
           StringBuilder strValue,
           ref Int32 Clipped
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Read(
           Int32 Probe,
           Int32 Channel,
           Int32 Unit,
           String ParameterName,
           ref Double Value,
           [In, Out] Double[] dblArray1,
           [In, Out] Double[] dblArray2,
           StringBuilder strValue
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Get_Ascan(
           Int32 Probe,
           Int32 Channel,
           [In, Out] UInt16[] Ascan,
           ref Int32 size,
           Int32 Timeout
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Get_Ascans(
           ref Int32 number_of_channels,
           [In, Out]  Int32[] probes_list,
           [In, Out]  Int32[] channels_list,
           [In, Out] UInt16[] Ascan,
           ref Int32 size,
           Int32 timeout
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Acq_Config(
           Int32 probe,
           Int32 type,
           ref Int32 buffer_size,
           [In, Out] Int32[] frame_despcriptor,
           Int32 when,
           Int32 number_of_conditions,
           [In, Out] Int32[] conditions
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Acq_Start(
           Int32 probe,
           Int32 number_of_frames_to_acquire
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Acq_Get_Status(
           Int32 probe,
           ref Int32 status,
           ref Int32 buffer_size,
           ref	Int32 frame_size,
           ref Int32 acquired_frames
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Acq_Read(
           Int32 probe,
           ref Int32 number_read,
           ref Int32 size_of_frame_buffer,
           [In, Out] UInt16[] frames
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Acq_Stop(
           Int32 probe
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Acq_Clear(
           Int32 probe
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Duplicate_Channels(
           Int32[] scrProbes,
           Int32[] scrChannels,
           Int32[] destProbes,
           Int32[] destChannels,
           Int32 NumberOfDuplications,
           String Filters
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Duplicate_Probes(
           Int32[] scrProbes,
           Int32[] destProbes,
           Int32 NumberOfDuplications,
           String Filters
        );

        [DllImport(DLL_FILE_NAME)]
        public static extern Int32 SI_Notification();

    }
}
