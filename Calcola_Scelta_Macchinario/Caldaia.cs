using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcola_Scelta_Macchinario
{
    class Caldaia :  Macchinario
    {
        //public 
        public Caldaia(double rendimento, double costo_Iniziale) : base(rendimento, costo_Iniziale)
        {
            this.rendimento = rendimento;
            prezzo = costo_Iniziale;
            consumo = 0;
            costo_tot = 0;
        }

        public override void Calcola_Consumo(double kWh, double Smc, double potere_calorifero)
        {
            consumo = kWh / (potere_calorifero * rendimento) + Smc;
        }
        public override void Costo_Totale(Bolletta gas)
        {
            base.Costo_Totale(gas);
        }
        
    }
}
