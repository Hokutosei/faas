using System;
using System.Threading;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace faas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DockerClient client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock"))
     .CreateClient();

            listContainers(client);
            Console.WriteLine($"done!");
            Thread.Sleep(300000);
        }

        public static async void listContainers(DockerClient client)
        {
            Console.WriteLine($"exec");
            var p = new ContainersListParameters() {
                Limit = 10
            };
            var containers = await client.Containers.ListContainersAsync(p);
            Console.WriteLine($"containers {containers}");
            foreach(var container in containers)
            {
                Console.WriteLine($"container {container.ID}");
            }

            return;
        }
    }
}
