using AsyncCallbackService;
using CallbackService;
using Exercise4_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceHost2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyData.info();
            //step 1 Create the URI of service base address
            Uri baseAddress1 = new Uri("http://localhost:8050/ComplexCalc");
            Uri baseAddress2 = new Uri("http://localhost:8051/AsyncService");
            Uri baseAddress3 = new Uri("http://localhost:8052/CallbackService");
            Uri baseAddress4 = new Uri("http://localhost:8052/AsyncComplexCalc");

            //step 2 Create service instance
            ServiceHost myHost1 = new ServiceHost(typeof(MyComplexCalc), baseAddress1);
            ServiceHost myHost2 = new ServiceHost(typeof(AsyncService), baseAddress2);
            ServiceHost myHost3 = new ServiceHost(typeof(MySuperCalc), baseAddress3);
            ServiceHost myHost4 = new ServiceHost(typeof(AsyncComplexCalc), baseAddress3);
            //step 3 Add the endpoint
            BasicHttpBinding myBinding1 = new BasicHttpBinding();
            BasicHttpBinding myBinding2 = new BasicHttpBinding();
            WSDualHttpBinding myBinding3 = new WSDualHttpBinding();
            WSDualHttpBinding myBinding4 = new WSDualHttpBinding();
            ServiceEndpoint endpoint1 = myHost1.AddServiceEndpoint(typeof(IComplexCalc), myBinding1, "endpoint1");
            ServiceEndpoint endpoint2 = myHost2.AddServiceEndpoint(typeof(IAsyncService), myBinding2, "endpoint2");
            ServiceEndpoint endpoint3 = myHost3.AddServiceEndpoint(typeof(ISuperCalc), myBinding3, "ThirdService");
            ServiceEndpoint endpoint4 = myHost4.AddServiceEndpoint(typeof(ISuperCalc), myBinding4, "FourthService");
            //step 4 Set up metadata and publish service metadata
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost1.Description.Behaviors.Add(smb);
            myHost2.Description.Behaviors.Add(smb);
            myHost3.Description.Behaviors.Add(smb);

            try
            {
                myHost1.Open();
                Console.WriteLine("--> ComplexCalculator is running.");
                myHost2.Open();
                Console.WriteLine("--> Async service is running");
                Console.WriteLine("--> Press <ENTER> to stop. \n");
                myHost3.Open();
                Console.WriteLine("--> Callback SuperCalc is running");
                Console.ReadLine();
                myHost3.Close();
                Console.WriteLine("--> Callback SuperCalc finished");
                myHost2.Close();
                Console.WriteLine("-->Async serive finished");
                myHost1.Close();
                Console.WriteLine("--> ComplexCalculator finished.");

            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("Exception occurred: {0}", ce.Message);
                myHost1.Abort();
                myHost2.Abort();
                myHost3.Abort();
            }
        }
    }
}
