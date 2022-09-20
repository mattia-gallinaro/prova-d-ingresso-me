using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcola_Scelta_Macchinario
{
    class Macchinario
    {
        protected double rendimento, costo_Iniziale, consumo;

        public Macchinario()
        {
        }

        public virtual void Calcola_Consumo(double elettricita_utilizzata, double gas_consumato)
        {
            consumo = 0;
        }

        public virtual double Costo_Totale(Materia materia)
        {
            double costo_Totale = materia.Costo_tot_bolletta(consumo) + costo_Iniziale;
            return costo_Totale;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
