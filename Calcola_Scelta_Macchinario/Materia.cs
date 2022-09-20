using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcola_Scelta_Macchinario
{
    class Materia
    {
        protected internal double costo_per_unita, qvd , spesa_tp_gc, oneri;
        //protected double 

        public Materia(double costo)
        {
            costo_per_unita = costo;
            qvd = 0;
            spesa_tp_gc = 0;
            oneri = 0;
        }

        public virtual double Costo_tot_bolletta(double consumo)
        {
            double costo = costo_per_unita * consumo + qvd + spesa_tp_gc * 12 + oneri;
            return costo;
        }
    }
}
