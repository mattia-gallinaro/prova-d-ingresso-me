using System;
using System.IO;
using Newtonsoft.Json;

namespace Calcola_Scelta_Macchinario
{
    class Program
    {
        static void Main(string[] args)
        {
            using var watcher = new FileSystemWatcher("C:/Users/galli/OneDrive/Documenti/GitHub/prova-d-ingresso-me/Sito_raccogli_dati");
            watcher.Filter = "output.json";

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.Changed += new FileSystemEventHandler(Watcher_Changed);

            Console.WriteLine("Premi un tasto per terminare il programma");
            Console.ReadKey();
        }
        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Scelta scelta;
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
                scelta = new Scelta(jsonConvert.kWh, jsonConvert.Smc, jsonConvert.selezione);
                scelta.Scelta_Macchinario();
            }
            catch
            {
                Console.WriteLine("Impossibile convertire il json");
            }

            
            //JsonConverter jsonstring = JsonConvert.DeserializeObject<JsonConvert>(text);
        }
    }
}
