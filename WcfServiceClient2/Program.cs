using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfServiceClient2.ServiceReference1;
using WcfServiceClient2.ServiceReference2;
using WcfServiceClient2.ServiceReference4;

namespace WcfServiceClient2
{


    class Program
    {
        [STAThread]
        static void Main()
        {
            Info.MyInfo();

            
            ComplexCalcClient client1 = new ComplexCalcClient("BasicHttpBinding_IComplexCalc");
            ComplexNum cnum1 = new ComplexNum();
            cnum1.real = 1.2;
            cnum1.imag = 3.4;
            ComplexNum cnum2 = new ComplexNum();
            cnum2.real = 5.6;
            cnum2.imag = 7.8;
            Console.WriteLine("\nCLIENT1 - START");
            Console.WriteLine("...calling addCNum(...)");
            ComplexNum result1 = client1.addCNum(cnum1, cnum2);
            Console.WriteLine(" addCNum(...) = ({0} | {1})", result1.real, result1.imag);
            //Console.WriteLine("--> Press ENTER to continue");
            //Console.ReadLine();
            client1.Close();
            Console.WriteLine("CLIENT1 - STOP");

            Console.WriteLine("CLIENT2 - START (Async service)");
            AsyncServiceClient client2 = new AsyncServiceClient("BasicHttpBinding_IAsyncService");
            Console.WriteLine("...calling Fun1");
            //client2.Fun1("Client2");
            Thread.Sleep(10);
            Console.WriteLine("...continue after Fun1 call");

            Console.WriteLine("...calling Fun2");
            //client2.Fun2("Client2");
            Thread.Sleep(10);
            Console.WriteLine("...continue after Fun2 call");

            //Console.WriteLine("--> Press ENTER to continue");
            //Console.ReadLine();
            client2.Close();
            Console.WriteLine("CLIENT2 - STOP");


            Console.WriteLine("\nCLIENT3 – START (Callbacks):");
            SuperCalcCallback myCbBHandler = new SuperCalcCallback();
            InstanceContext instanceContext = new InstanceContext(myCbBHandler);
            SuperCalcClient client3 = new SuperCalcClient(instanceContext);
            double value1 = 10;
            Console.WriteLine("...call of Factorial({0})...", value1);
            client3.Factorial(value1);
            int value2 = 5;
            Console.WriteLine("...call of DoSomething...");
            client3.DoSomething(value2);
            value1 = 20;
            Console.WriteLine("...call of Factorial({0})...", value1);
            client3.Factorial(value1);
            Console.WriteLine("--> Client must wait for the results");
            Console.WriteLine("--> Press ENTER after receiving ALLresults");
            Console.ReadLine();
            client3.Close();
            Console.WriteLine("CLIENT3 - STOP");



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Okienko1());
        }
    }
}
