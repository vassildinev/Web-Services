namespace DateTimeUtilities.ConsoleClient
{
    using System;

    using DateTimeServiceReference;
    using System.Text;
    using System.ServiceModel;
    using Web;
    using System.ServiceModel.Description;

    public class Startup
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            //TestWithWcfServiceClient();
            TestWithServiceHost();
        }

        private static void TestWithWcfServiceClient()
        {
            using (var client = new DateTimeServiceClient())
            {
                string result = client.GetDayOfWeek(DateTime.Now);
                Console.WriteLine(result);
                Console.WriteLine("Press [Enter] to shut service down");
                Console.ReadLine();
            }
        }

        private static void TestWithServiceHost()
        {
            var serviceAddress = new Uri("http://localhost:1234/datetime");
            var selfHost = new ServiceHost(typeof(DateTimeService), serviceAddress);
            var smb = new ServiceMetadataBehavior();

            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);
            using (selfHost)
            {
                selfHost.Open();
                Console.WriteLine("The service is started at endpoint " + serviceAddress);
                Console.WriteLine("Press [Enter] to shut service down");
                Console.ReadLine();
            }
        }
    }
}
