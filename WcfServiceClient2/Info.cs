using System;
using System.Net;

class Info
{
    public static void MyInfo()
    {
        Console.WriteLine("Hello, World!");

        Console.WriteLine(DateTime.Now);

        Console.WriteLine("Grzegorz Dzikowski 256305");
        Console.WriteLine(Environment.UserName);
        Console.WriteLine(Environment.OSVersion);
        Console.WriteLine(Environment.Version);
        var strHostName = Dns.GetHostName();
        IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
        IPAddress[] addr = ipEntry.AddressList;

        for (int i = 0; i < addr.Length; i++)
        {
            Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
        }
        Console.WriteLine("Local Machine's Host Name: " + strHostName);
    }
}