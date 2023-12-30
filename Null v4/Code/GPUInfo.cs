using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Null_v4
{
    static class GPUInfo
    {
        private static ManagementObjectSearcher RAMSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");

        static public string GPUAdapterRAM
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in RAMSearcher.Get())
                    {
                        return queryObj["AdapterRAM"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return "";
                }
            }
        }

        static public string GPUDescription
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in RAMSearcher.Get())
                    {
                        return queryObj["Description"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return "";
                }
            }
        }

        static public string GPUDriverVersion
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in RAMSearcher.Get())
                    {
                        return queryObj["DriverVersion"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return "";
                }
            }
        }

        static public string GPUProcessor
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in RAMSearcher.Get())
                    {
                        return queryObj["DeviceID"].ToString();
                    }
                    return "";
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    return "";
                }
            }
        }

    }
}
