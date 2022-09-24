using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Macchinario
    {
        protected double rendimento, costo_tot, consumo, prezzo, costo_Annuale;
        protected bool selezionato;
        protected string nome;
        public Macchinario(double rendimento, double prezzo, string nome)
        {
            this.rendimento = rendimento;
            this.prezzo = prezzo;
            consumo = 0;
            costo_tot = 0;
            costo_Annuale = 0;
            selezionato = false;
            this.nome = nome;
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
        public double CostoAnnuale(int anni)
        {
            return (this.costo_Annuale * anni + this.prezzo);
        }
        public string GetNome()
        {
            return this.nome;
        }
        public override string ToString()
        {
            string frase = rendimento + " e' il rendimento," + prezzo + " e' il costo di installazione e della macchina";
            return (frase);
        }
    }
}
