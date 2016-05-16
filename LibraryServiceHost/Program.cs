using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Library;

namespace LibraryServiceHost
{
    /// <summary>
    /// Quick setup for a locally hosted web service
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create a URI to serve as the base address
            Uri address = new Uri("http://localhost/LibraryServiceHost/");

            // Create a ServiceHost instance
            ServiceHost selfHost = new ServiceHost(typeof(LibraryService), address);

            try
            {
                // Add a service endpoint
                selfHost.AddServiceEndpoint(typeof(ILibraryService), new WSHttpBinding(), "LibraryService");

                // Enable metadata exchange
                ServiceMetadataBehavior serviceMetadataBehavior = new ServiceMetadataBehavior();
                serviceMetadataBehavior.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(serviceMetadataBehavior);

                // Start the service
                selfHost.Open();
                Console.WriteLine("LibraryService is ready.");
                Console.WriteLine("Press ENTER to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // After the user hits a key, shut down the service
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"An exception occured: {ce}");
            }
        }
    }
}
