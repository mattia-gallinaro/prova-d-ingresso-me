using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Test
{
    class Lista
    {
        protected int posizione;
        protected double costo;
        public Lista(double costo, int posizione)
        {
            this.costo = costo;
            this.posizione = posizione;
        }
        public double GetCosto()
        {
            return this.costo;
        }
        public int GetPosizione()
        {
            return this.posizione;
        }
    }
    class Scelta
    {
        protected int selezione;
        protected double kWh, Smc;
        private Caldaia caldaia_condensazione = new Caldaia(1, (1500 + 300), "Caldaia a condensazione");
        private Caldaia caldaia_tradizionale = new Caldaia(0.9, (1500 + 300), "Caldaia tradizionale");
        private Elettrico stufa = new Elettrico(1, (600 + 250), "Stufa elettrica");
        private Elettrico pompa_buon_livello = new Elettrico(3.6, (3000 + 250), "Pompa di calore costosa");
        private Elettrico pompa_economica = new Elettrico(2.8, (1000 + 250), "Pompa di calore economica");
        private Bolletta gas = new Bolletta(1.08, 5.228, 60, 0.113, 0.0347);
        private Bolletta luce = new Bolletta(0.276, 5.98, 20.28, 0.00798, 0.036);
        public Scelta(double kWh, double Smc, int selezione)
        {
            this.kWh = kWh;
            this.Smc = Smc;
            this.selezione = selezione;
        }
        public string Scelta_Macchinario()
        {
            List<Macchinario> macchinario= new List<Macchinario>() { caldaia_condensazione, caldaia_tradizionale, stufa, pompa_buon_livello, pompa_economica };
            List<Lista> prezzo = new List<Lista>();
            string risposta = "";
            macchinario[selezione].SetSelezionato();
            foreach (Macchinario p in macchinario)
            {
                Console.WriteLine("Macchina " + p.GetType());

                p.Calcola_Consumo(kWh, Smc, 10.7);
                
                //Console.WriteLine(p.GetConsumo());
                if (Convert.ToString(p.GetType()) == "Test.Caldaia")
                {
                    p.Costo_Totale(gas);
                    
                    //Console.WriteLine("sono una caldaia");
                }
                else
                {
                    p.Costo_Totale(luce);
                    //Console.WriteLine("Sono un macchinario elettrico");
                }
                Console.WriteLine(p.GetCostoTotale());
                prezzo.Add(new Lista(p.costoAnnuale(1), prezzo.Count()));
                Console.WriteLine(prezzo[prezzo.Count() - 1].GetCosto());
                
            }

            List<Lista> prezzi_ord = prezzo.OrderBy(p => p.GetCosto()).ToList<Lista>();
            foreach(Lista p in prezzi_ord)
            {
                Console.WriteLine(p.GetCosto());
                Console.WriteLine(p.GetPosizione());
            }
            if(macchinario[prezzi_ord[0].GetPosizione()].GetSelezionato())
            {
                risposta += "Per il 1^ anno il tuo macchinario e' quello piu' conveniente";
            }
            else
            {
                risposta += "Per il 1^ anno il miglior macchinario e': " + macchinario[prezzi_ord[0].GetPosizione()].GetNome() + " con un risparmio di: " +macchinario[selezione].GetNome();
            }
            return risposta;
        }
    }
}
