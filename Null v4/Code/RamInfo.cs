using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Null_v4
{
    static class RamInfo
    {
        private static ManagementObjectSearcher RAMSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");

        static public string RAMPartNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in RAMSearcher.Get())
                    {
                        return queryObj["PartNumber"].ToString();
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

        static public string RAMSerialNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in RAMSearcher.Get())
                    {
                        return queryObj["SerialNumber"].ToString();
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

        static public string RAMSpeed
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in RAMSearcher.Get())
                    {
                        return queryObj["Speed"].ToString();
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

        static public string RAMFormFactor
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in RAMSearcher.Get())
                    {
                        return queryObj["FormFactor"].ToString();
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

        static public string RAMMaxVoltage
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in RAMSearcher.Get())
                    {
                        return queryObj["MaxVoltage"].ToString();
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
