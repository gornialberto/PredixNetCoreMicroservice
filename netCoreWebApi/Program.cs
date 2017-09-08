using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace netCoreWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "ecagent_linux_sys",
                Arguments = "-dbg -mod client -aid lQHBP2 -hst wss://<gateway url>/agent -cid <uaaClientId> -csc <UaaClientSecret> -tid gBwuUe -oa2 https://<your uaa url>/oauth/token -dur 3000 -lpt 8433"
            };

            Console.WriteLine("Starting child process...");
            using (var process = Process.Start(processInfo))
            {
                process.Start();
            }

            Task.Delay(200);

            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",false,true)
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
