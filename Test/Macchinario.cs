using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Macchinario
    {
        //variabili della classe Macchinario
        protected double rendimento, costo_tot, consumo, prezzo, costo_Annuale;
        protected bool selezionato;
        protected string nome;
        public Macchinario(double rendimento, double prezzo, string nome)//costruttore della classe Macchinario
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

        public virtual void Costo_Totale(Bolletta bolletta)//calcola il costo annuale in base al gas 
        {
            costo_Annuale = bolletta.Costo_tot_bolletta(this.consumo);//richiama la funzione Costo_Tot_Bolletta passandoli il consumo totale per calcolare quanto il costo_Annuale cioé quanto l'utente spenderebbe di bolletta all'anno con quel macchinario
            costo_tot = costo_Annuale + prezzo;//somma il costo delle bollette in un anno e il prezzo del macchinario 

        }

        public void SetSelezionato()//funzione per settare il valore di selezionato a true, che sta ad indicare che l'utente ha scelto quel macchinario
        {
            selezionato = true;
        }
        public bool GetSelezionato()//ritorna il valore della variabile selezionato, true se é la macchina selezionata dall'utente false se non lo é
        {
            return selezionato;
        }
        public double CostoAnnuale(int anni)//funzione per calcolare quanto costa una macchina in base al numero di anni passatogli
        {
            return (this.costo_Annuale * anni + this.prezzo);//ritorna il costo annuale moltiplicato per gli anni e sommato al prezzo originale del macchinario
        }
        public string GetNome()//ritorna la stringa nome che contiene il nome del macchinario prima assegnatoli
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
