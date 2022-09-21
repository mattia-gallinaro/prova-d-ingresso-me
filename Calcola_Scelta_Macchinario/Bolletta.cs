using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcola_Scelta_Macchinario
{
    class Bolletta
    {
        protected internal double costo_per_unita, quota_fissa, spesa_tp_gc, oneri;
        //protected double 

        public Bolletta(double costo_per_unita, double quota_fissa)
        {
            this.costo_per_unita = costo_per_unita;
            this.quota_fissa = quota_fissa;
            spesa_tp_gc = 96;
            oneri = 47;
        }

        public double Costo_tot_bolletta(double consumo)
        {
            double costo = costo_per_unita * consumo + quota_fissa + spesa_tp_gc * 12 + oneri;
            return costo;
        }
    }
}
