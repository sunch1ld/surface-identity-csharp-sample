using ClientSI_Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ClientSI.Library;
using ClientSI.Requests;
using Library.ObjReader;
using System;

namespace ClientSI
{
    public class Program  
    {
        public static IConfiguration Configuration;
        static async System.Threading.Tasks.Task Main()
        {

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            var identificationSettings = Configuration.GetSection("IdentificationSettings").Get<IdentificationSettings>();

            var serviceProvider = new ServiceCollection()
               .AddSingleton<IIdentification>(identification => new IdentificationClient(identificationSettings))
               .BuildServiceProvider();

            var identification = serviceProvider.GetService<IIdentification>();

            ObjReader or = new ObjReader()
            {
                Path = identificationSettings.Filename
            };

            or.ReadFile();

            IdentificationRequest request = new IdentificationRequest(
                identificationSettings.InstanceName, 
                identificationSettings.ProjectIds, 
                or.X.ToArray(), 
                or.Y.ToArray(), 
                or.Z.ToArray(), 
                identificationSettings.UnitOfMeasure);

            var indentificationResults = await identification.IdentifyAsync(request);

            foreach (var result in indentificationResults)
            {
                var message = result.Value.Found ? $"Object {result.Value.ObjectName}  (id: {result.Value.ObjectId}), with surface {result.Value.SurfaceName} (id: {result.Value.SurfaceId}) found in project id {result.Key} \n" :
                    $"Not found in project id: {result.Key} \n";
                Console.WriteLine(message);
            }

            Console.ReadLine();
        }
    }
}
 
