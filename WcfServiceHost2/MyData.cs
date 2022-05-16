using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceHost2
{
    public class MyData
    {
        public static void info()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            Console.WriteLine(date);
            Console.WriteLine("Krzysztof Bialik, 254573");
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(Environment.OSVersion);
            Console.WriteLine(Environment.Version);
            Console.WriteLine(Dns.GetHostEntry(Dns.GetHostName())
                               .AddressList
                               .First(x => x.AddressFamily == AddressFamily.InterNetwork));
        }
    }
}
