using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Lista
    {
        public readonly int posizione;
        public readonly double costo;
        public Lista(double costo, int posizione)
        {
            this.costo = costo;
            this.posizione = posizione;
        }
    }
    class Scelta
    {
        protected int selezione;
        protected double kWh, Smc;
        private Caldaia caldaia_cond = new Caldaia(1, (1500 + 300));
        private Caldaia caldaia_trad = new Caldaia(0.9, (1500 + 300));
        private Elettrico stufa = new Elettrico(1, (600 + 250));
        private Elettrico pompa_buonlv = new Elettrico(3.6, (3000 + 250));
        private Elettrico pompa_cheap = new Elettrico(2.8, (1000 + 250));
        private Bolletta gas = new Bolletta(1.08, 5.228, 60, 0.113, 0.0347);
        private Bolletta luce = new Bolletta(0.276, 5.98, 20.28, 0.00798, 0.036);
        public Scelta(double kWh, double Smc, int selezione)
        {
            this.kWh = kWh;
            this.Smc = Smc;
            this.selezione = selezione;
        }
        public void Scelta_Macchinario()
        {
            List<Macchinario> macchinario= new List<Macchinario>() { caldaia_cond, caldaia_trad, stufa, pompa_buonlv, pompa_cheap };
            List<Lista> prezzo = new List<Lista>();
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
            }

            ControllaLista(ref prezzo);
            
        }

        public void ControllaLista(ref List<Lista> prezzi)
        {
            //List<Macchinario> classifica = (List<Macchinario>)macchinario.OrderBy(Macchinario => Macchinario.GetCostoTotale());
            prezzi.OrderBy(prezzi => prezzi.costo);
        }
    }
}
