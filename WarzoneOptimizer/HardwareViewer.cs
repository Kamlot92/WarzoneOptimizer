﻿#region Copyright (c) Amirhosein Davatgari. All rights reserved.
//
// C# PC Hardware Information 
//
// https://Amirhoseindavat.ir
//
// Alpha Build
//
// Version 0.1
#endregion

using System;
using System.Management;

namespace HardwareInformation
{
    class GetHardwareInformation
    {

        public struct CPU
        {
            public static string Manufacor
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher CPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                    foreach (ManagementObject list in CPU.Get())
                    {
                        name = list["Manufacturer"].ToString();
                    }
                    return name;
                }
            }
            public static string Cores
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher CPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                    foreach (ManagementObject list in CPU.Get())
                    {
                        name = list["NumberOfCores"].ToString();
                    }
                    return name;
                }
            }
            public static string Threads
            {
                get{
                    string name = "";
                    ManagementObjectSearcher CPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                    foreach (ManagementObject list in CPU.Get())
                    {
                        name = list["NumberOfLogicalProcessors"].ToString();
                    }
                    return name;
                }
            }
            public static string MaxClockSpeed
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher CPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                    foreach (ManagementObject list in CPU.Get())
                    {
                        name = list["MaxClockSpeed"].ToString();
                    }
                    return name;
                }
            }
            public static string Family
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher CPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                    foreach (ManagementObject list in CPU.Get())
                    {
                        name = list["Family"].ToString();
                    }
                    return name;
                }
            }
            public static string Model
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher CPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                    foreach (ManagementObject list in CPU.Get())
                    {
                        name = list["name"].ToString();
                    }
                    return name;
                }
            }
        }
        public struct GPU
        {
            public static string Manufacor
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher GPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
                    foreach (ManagementObject list in GPU.Get())
                    {
                        name = list["name"].ToString();
                    }
                    return name;
                }
            }
            public static string RefreshRate
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher GPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
                    foreach (ManagementObject list in GPU.Get())
                    {
                        name = list["CurrentRefreshRate"].ToString();
                    }
                    return name;
                }
            }
            public static string DriverVersion
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher GPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
                    foreach (ManagementObject list in GPU.Get())
                    {
                        name = list["DriverVersion"].ToString();
                    }
                    return name;
                }
            }
            public static string Model
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher GPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
                    foreach (ManagementObject list in GPU.Get())
                    {
                        name = list["name"].ToString();
                    }
                    return name;
                }
            }
        }

        public struct Monitor
        {
            public static string Model
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher GPU = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DesktopMonitor");
                    foreach (ManagementObject list in GPU.Get())
                    {
                        name = list["MonitorManufacturer"].ToString();
                    }
                    return name;
                }
            }
            public static string Resolution
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher Monitor = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DesktopMonitor");
                    foreach (ManagementObject list in Monitor.Get())
                    {
                        name = list["ScreenWidth"].ToString();
                    }
                    return name;
                }
            }

        }
        public struct Ram
        {
            public static string Speed
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher RAM = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
                    foreach (ManagementObject list in RAM.Get())
                    {
                        name = list["Speed"].ToString();
                    }
                    return name;
                }
            }
            public static int Size
            {
                get
                {
                    ManagementObjectSearcher RAM = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");
                    ManagementObjectCollection results = RAM.Get();
                    double size;
                    foreach (ManagementObject result in results)
                    {
                        size = Convert.ToDouble(result["TotalVisibleMemorySize"]);
                        size = Math.Round((size / (1024 * 1024)), 0);
                        int res = Convert.ToInt32(size);
                        return res;
                    }

                    return 0;
                }
            }
            public static string Type
            {
                get
                {
                    string name = "";
                    int type;
                    ManagementObjectSearcher RAM = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");
                    foreach (ManagementObject list in RAM.Get())
                    {
                        type = Convert.ToInt32(list["MemoryType"]);
                        switch (type)
                        {
                            case 20:
                                name = "DDR";
                                break;
                            case 21:
                                name = "DDR1";
                                break;
                            case 24:
                                name = "DDR2";
                                break;
                            case 25:
                                name = "DDR3";
                                break;
                            case 26:
                                name = "DDR4";
                                break;
                        }
                    }
                    return name;
                }
            }
            public static string Slot
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher RAM = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemoryArray");
                    foreach (ManagementObject list in RAM.Get())
                    {
                        name = list["MemoryDevices"].ToString();
                    }
                    return name;
                }
            }
            public static string UsedSlot
            {
                get
                {
                    string name = "";
                    ManagementObjectSearcher RAM = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemoryArray");
                    foreach (ManagementObject list in RAM.Get())
                    {
                        name = list["DeviceLocator"].ToString();
                    }
                    return name;
                }
            }
        }
        public struct OS
        {
            public static string Name
            {
                get
                {
                    ManagementObjectSearcher OS = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");
                    string OSname = "";
                    foreach (ManagementObject List in OS.Get())
                    {
                        OSname = string.Format("{0} {1}", List["Caption"].ToString(), List["OSArchitecture"].ToString());
                    }
                    return OSname;
                }
            }
        }
    }
}
