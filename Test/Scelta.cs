using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Scelta
    {
        protected int selezione;
        protected double kWh, Smc;
        public Scelta(double kWh, double Smc, int selezione)
        {
            this.kWh = kWh;
            this.Smc = Smc;
            this.selezione = selezione;
        }
        public void Scelta_Macchinario()
        {
            Caldaia caldaia_cond = new Caldaia(1, (1500 + 300), "gas");
            Caldaia caldaia_trad = new Caldaia(0.9, (1500 + 300), "gas");
            Elettrico stufa = new Elettrico(1, (600 + 250), "kwh");
            Elettrico pompa_buonlv = new Elettrico(3.6, (3000 + 250), "kwh");
            Elettrico pompa_cheap = new Elettrico(2.8, (1000 + 250), "kwh");
            Bolletta gas = new Bolletta(1.08, 5.228, 60, 0.113, 0.0347);
            Bolletta luce = new Bolletta(0.276, 5.98, 20.28, 0.00798, 0.036);
            List<Macchinario> macchinario= new List<Macchinario>() { caldaia_cond, caldaia_trad, stufa, pompa_buonlv, pompa_cheap };
            macchinario[selezione].SetSelezionato();
            foreach (Macchinario p in macchinario)
            {
                Console.WriteLine("Macchina " + p.GetType());

                p.Calcola_Consumo(kWh, Smc, 10.7);
                
                //Console.WriteLine(p.GetConsumo());
                if (p.GetTipoConsumo() == "gas")
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
            }

            ControllaLista(macchinario);


        }

        public void ControllaLista(List<Macchinario> macchinario)
        {
            List<Macchinario> classifica = (List<Macchinario>)macchinario.OrderBy(Macchinario => Macchinario.GetCostoTotale());
            if (classifica[0].GetSelezionato())
            {

            }
        }
    }
}
