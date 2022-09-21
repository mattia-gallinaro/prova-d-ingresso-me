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
            string text = File.ReadAllText("output.json");
            JsonConverter jsonConvert;
            try
            {
                jsonConvert = JsonConvert.DeserializeObject<JsonConverter>(text);
                if(jsonConvert == null)
                {
                    Console.WriteLine("Non ho trovato nulla");
                    throw new ArgumentNullException(" Accade ");
                }
            }
            catch
            {
                Console.WriteLine("Impossibile convertire il json");
            }
            
            
            //JsonConverter jsonstring = JsonConvert.DeserializeObject<JsonConvert>(text);
        }
    }
}
