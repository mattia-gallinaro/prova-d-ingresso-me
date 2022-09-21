using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcola_Scelta_Macchinario
{
    class Macchinario
    {
        protected double rendimento, costo_tot, consumo , prezzo;

        public Macchinario(double rendimento, double prezzo)
        {
            this.rendimento = rendimento;
            this.prezzo = prezzo;
            consumo = 0;
            costo_tot = 0;
        }

        public virtual void Calcola_Consumo(double elettricita_utilizzata, double gas_consumato, double potere_calorifero)
        {
            consumo = 0;
        }

        public virtual void Costo_Totale(Materia materia)
        {
            costo_tot = materia.Costo_tot_bolletta(consumo) + prezzo;

        }
        public virtual double GetPrezzo()
        {
            return prezzo;
        }
        public override string ToString()
        {
            string frase =  rendimento + " e' il rendimento," + prezzo + " e' il costo di installazione e della macchina";
            return (frase);
        }
        
    }
}
