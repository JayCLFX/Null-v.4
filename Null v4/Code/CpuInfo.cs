using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Null_v4
{
    public class CpuInfo
    {
        private static ManagementObjectSearcher CPUSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

        static public string CPUName
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in CPUSearcher.Get())
                    {
                        return queryObj["Name"].ToString();
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

        static public string CPUSN
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in CPUSearcher.Get())
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

        static public string CPUID
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in CPUSearcher.Get())
                    {
                        return queryObj["ProcessorId"].ToString();
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

        static public string CPUCores
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in CPUSearcher.Get())
                    {
                        return queryObj["NumberOfCores"].ToString();
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

        static public string CPUPartNumber
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in CPUSearcher.Get())
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

        static public string CPULogicalProcessors
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in CPUSearcher.Get())
                    {
                        return queryObj["NumberOfLogicalProcessors"].ToString();
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

        static public string CPUThreads
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in CPUSearcher.Get())
                    {
                        return queryObj["ThreadCount"].ToString();
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
