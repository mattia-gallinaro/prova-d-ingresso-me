using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Macchinario
    {
        protected double rendimento, costo_tot, consumo, prezzo, costo_Annuale;
        protected bool selezionato;
        protected string tipo;
        public Macchinario(double rendimento, double prezzo, string tipo)
        {
            this.rendimento = rendimento;
            this.prezzo = prezzo;
            this.tipo = tipo;
            consumo = 0;
            costo_tot = 0;
            costo_Annuale = 0;
            selezionato = false;
        }

        public virtual void Calcola_Consumo(double elettricita_utilizzata, double gas_consumato, double potere_calorifero)
        {
            consumo = 0;
        }

        public virtual void Costo_Totale(Bolletta bolletta)
        {
            costo_Annuale = bolletta.Costo_tot_bolletta(this.consumo);
            costo_tot = costo_Annuale + prezzo;

        }

        public void SetSelezionato()
        {
            selezionato = true;
        }
        public string GetConsumo()
        {
            return Convert.ToString(consumo);
        }
        public virtual string GetTipoConsumo()
        {
            return tipo;
        }
        public virtual double GetPrezzo()
        {
            return prezzo;
        }
        public double GetCostoTotale()
        {
            return costo_tot;
        }
        public bool GetSelezionato()
        {
            return selezionato;
        }
        public override string ToString()
        {
            string frase = rendimento + " e' il rendimento," + prezzo + " e' il costo di installazione e della macchina";
            return (frase);
        }
    }
}
