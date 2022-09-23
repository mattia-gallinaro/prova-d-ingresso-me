using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Bolletta
    {
        //costi fissi
        protected internal double quota_fissa, spesa_tp_gc;
        //costi all'unitá
        protected internal double costo_per_unita, costo_tp_gc_unita, oneri;
        //protected double 

        public Bolletta(double costo_per_unita, double quota_fissa, double spesa_tp_gc, double costo_tp_gc_unita, double oneri)
        {
            this.costo_per_unita = costo_per_unita;
            this.quota_fissa = quota_fissa;
            this.spesa_tp_gc = spesa_tp_gc;
            this.costo_tp_gc_unita = costo_tp_gc_unita;
            this.oneri = oneri;
        }

        public double Costo_tot_bolletta(double consumo)
        {
            double costo = costo_per_unita * consumo + quota_fissa * 12 + (spesa_tp_gc + costo_tp_gc_unita*consumo) + oneri * consumo;
            return costo;
        }
    }
}
