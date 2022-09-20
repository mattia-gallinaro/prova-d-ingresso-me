using System;
using System.IO;
using Newtonsoft.Json;

namespace Calcola_Scelta_Macchinario
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using var watcher = new FileSystemWatcher("");
            watcher.Filter = "output.json";

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Premi un tasto per terminare il programma");
            Console.ReadKey();
        }
        private static void Onchanged(object sender, FileSystemEventArgs e)
        {
            var text = File.ReadAllText("output.json");
            //JsonConverter jsonstring = JsonConvert.DeserializeObject<JsonConvert>(text);
        }
    }
}
