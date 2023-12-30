using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Diagnostics;

namespace Null_v4
{
    static class IPInfo
    {
        static public string GetLocalIPAddress
        {
            get
            {
                try
                {
                    var host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (var ip in host.AddressList)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return ip.ToString();
                        }
                    }
                    return "";
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                return null;
            }
        }
    }
}
