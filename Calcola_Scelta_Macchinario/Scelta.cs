using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcola_Scelta_Macchinario
{
    class Scelta
    {
        protected int selezione;
        protected double kWh, Smc;
        public Scelta(double kWh, double Smc, int selezione)
        {
            this.selezione = selezione;
        }
        public void Scelta_Macchinario()
        {
            double value = 0;
            Caldaia caldaia_cond = new Caldaia(1 , (1500 + 300));
            Caldaia caldaia_trad = new Caldaia(0.9 , (1500 + 300));
            Elettrico stufa = new Elettrico(1, (600 + 250));
            Elettrico pompa_buonlv = new Elettrico(3.6, (3000 + 250));
            Elettrico pompa_cheap = new Elettrico(2.8, (1000 + 250));

            List<object> list = new List<object>() { caldaia_cond, caldaia_trad, stufa, pompa_buonlv, pompa_cheap };
            foreach(object p in list)
            {
                Console.WriteLine(p.GetType());
                if(p.GetType() == typeof(Caldaia))
                {
                    Console.WriteLine("sono una caldaia");
                }
                else
                {
                    Console.WriteLine("sono un macchinario elettrico");
                }
            }


        }
    }
}
