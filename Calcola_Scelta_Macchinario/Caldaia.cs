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
        public Caldaia(double rendimento, double costo_Iniziale)
        {
            this.rendimento = rendimento;
            this.costo_Iniziale = costo_Iniziale;
            consumo = 0;
        }

        public override void Calcola_Consumo(double kWh, double Smc)
        {
            consumo = kWh / (10, 7 * rendimento) + Smc;
        }
        public override double Costo_Totale(Elettrico materia)
        {
            return 0;
        }
    }
}
