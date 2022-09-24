using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Bolletta
    {
        //variabili che indicano i costi fissi per le bollette del gas e della luce
        protected internal double quota_fissa, spesa_tp_gc;
        //costi all'unitá sia per kwh che per smc
        protected internal double costo_per_unita, costo_tp_gc_unita, oneri, quota_vendita_unitá;

        public Bolletta(double costo_per_unita, double quota_fissa, double spesa_tp_gc, double costo_tp_gc_unita, double oneri, double quota_vendita_unitá)//assegna i valori alle variabili omonime
        {
            this.costo_per_unita = costo_per_unita;
            this.quota_fissa = quota_fissa;
            this.spesa_tp_gc = spesa_tp_gc;
            this.costo_tp_gc_unita = costo_tp_gc_unita;
            this.oneri = oneri;
            this.quota_vendita_unitá = quota_vendita_unitá;
        }

        public double Costo_tot_bolletta(double consumo)//calcola il prezzo in base al consumo della macchina e il valore delle variabili
        {
            double costo = costo_per_unita * consumo + quota_vendita_unitá * consumo + quota_fissa * 12 + (spesa_tp_gc + costo_tp_gc_unita * consumo) + oneri * consumo;//calcola quanto costa la bolletta annualmente in base al consumo del macchinario
            return costo;
        }
    }
}
