using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace HelloWindowsService
{
    // Install-Package Topshelf

    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(configure =>
            {
                configure.Service<MyService>(service =>
                {
                    // here you can pass dependencies and configuration to the service
                    service.ConstructUsing(s => new MyService());

                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                configure.StartAutomatically();
                configure.EnableServiceRecovery(r => r.RestartService(0));
                configure.RunAsLocalSystem();

                configure.SetServiceName("MySimpleService");
                configure.SetDisplayName("My Simple Service");
                configure.SetDescription("This is my simple service");

                // Install-Package Topshelf.Serilog
                configure.UseSerilog(CreateLogger());
            });
        }

        private static ILogger CreateLogger()
        {
            // Install-Package Serilog.Sinks.Console -Version 3.1.1
            // Install-Package Serilog.Sinks.File - Version 4.1.0

            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", Serilog.Events.LogEventLevel.Debug)
                .CreateLogger();
            return logger;
        }
    }


    public class MyService
    {
        private ServiceHost serviceHost;

        private readonly LogWriter logger = HostLogger.Get<MyService>();

        public bool Start()
        {
            try
            {
                serviceHost = new ServiceHost(typeof(HelloWindowsService.HelloService));

                serviceHost.Open();

                logger.Info("Service Running...");
                Console.WriteLine("Press a key to quit");

                return true;
            }
            catch(Exception e)
            {
                logger.Error(e);

                return false;
            }
            finally
            {
                serviceHost.Close();
            }

        }

        public bool Stop()
        {
            serviceHost.Close();

            return true;
        }

    }

    public class MySimpleService
    {
        private readonly LogWriter logger = HostLogger.Get<MySimpleService>();

        public void Start()
        {
            logger.Info("Starting MySimpleService ...");
            // do some work here
            Console.WriteLine("Hello from MySimpleService");
        }

        public void Stop()
        {
            logger.Info("Stopping MySimpleService ...");
            // clean up
        }
    }
}
