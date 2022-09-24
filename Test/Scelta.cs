using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Test
{
    class Lista_Prezzi
    {
        //variabili 
        protected int posizione;
        protected double costo;
        public Lista_Prezzi(double costo, int posizione)
        {
            this.costo = costo;
            this.posizione = posizione;
        }
        public double GetCosto()//ritorna il costo
        {
            return this.costo;
        }
        public int GetPosizione()//ritorna la posizione
        {
            return this.posizione;
        }
    }
    class Scelta
    {
        //variabili limitate alla classe per il calcolo della miglior scelta
        protected int selezione;
        protected double kWh, Smc;
        
        public Scelta(double kWh, double Smc, int selezione)//costruttore
        {
            this.kWh = kWh;
            this.Smc = Smc;
            this.selezione = selezione;
        }
        public string Scelta_Macchinario()
        {
            //istanze delle classi Caldaia, Elettrico e Bollette con assegnazione di valori in base al macchinario
            Caldaia caldaia_condensazione = new Caldaia(1, (1500 + 300), "Caldaia a condensazione");
            Caldaia caldaia_tradizionale = new Caldaia(0.9, (1500 + 300), "Caldaia tradizionale");
            Elettrico stufa = new Elettrico(1, (600 + 250), "Stufa elettrica");
            Elettrico pompa_buon_livello = new Elettrico(3.6, (3000 + 250), "Pompa di calore costosa");
            Elettrico pompa_economica = new Elettrico(2.8, (1000 + 250), "Pompa di calore economica");
            Bolletta gas = new Bolletta(1.08, 5.228, 60, 0.113, 0.0347, 0.007496);
            Bolletta luce = new Bolletta(0.276, 5.98, 20.28, 0.00798, 0.036, 0);

            //lista di macchinari in cui assegna le varie istanze prima create per poi calcolarne il consumo e costo sia totale che annuale di ciascuna
            List<Macchinario> macchinario= new List<Macchinario>() { caldaia_condensazione, caldaia_tradizionale, stufa, pompa_buon_livello, pompa_economica };
            
            string risposta = "";
            macchinario[selezione].SetSelezionato();//richiama la funzione SetSelezionato per indicare quale macchinario ha selezionato l'utente 
            foreach (Macchinario p in macchinario)//si ripete per tutti gli elementi della lista macchinario
            {
                p.Calcola_Consumo(kWh, Smc, 10.7);//richiama la funzione per calcolare il consumo totale del macchinario
                if (Convert.ToString(p.GetType()) == "Test.Caldaia")//controlla se l'istanza é una caldaia o un elettrico
                {
                    p.Costo_Totale(gas);//calcola il costo totale della macchina passandogli la bolletta gas siccome si tratta di una caldaia e utilizza gas
                }
                else
                {
                    p.Costo_Totale(luce);//calcola il costo totale della macchina passandogli la bolletta luce siccome si tratta di un elettrico e utilizza energia elettrica
                }
                
            }

            risposta += Controllo_Anni(ref macchinario, 1);//chiama la funzione Controllo_Anni per calcolare il calcolo dei macchinari in base al numero di anni e assegna la frase a risposta
            risposta += Controllo_Anni(ref macchinario, 3);
            risposta += Controllo_Anni(ref macchinario, 5);

            return risposta;//ritorna il risultato

        }
        public string Controllo_Anni(ref List<Macchinario> macchinario,  int anni)
        {
            string risposta = "";
            List<Lista_Prezzi> prezzo = new List<Lista_Prezzi>();//lista per i prezzi dei macchinari
            foreach(Macchinario p in macchinario)//si ripete per tutti gli elementi della lista macchinario
            {
                prezzo.Add(new Lista_Prezzi(p.CostoAnnuale(anni), prezzo.Count()));//aggiunge un nuovo elemento nella lista prezzo
            }
            List<Lista_Prezzi> prezzi_ord = prezzo.OrderBy(p => p.GetCosto()).ToList<Lista_Prezzi>();//riordina i prezzi in base al valore dal piú piccolo al piú grande 
            if (macchinario[prezzi_ord[0].GetPosizione()].GetSelezionato())//se l'elemento in posizione prezzo_ord[0].getposizione ha come valore di selezionato true allora é il macchinario selezionato dall'utente
            {
                risposta += "\nPer il "+ anni+"^ anno il tuo macchinario e' quello piu' conveniente che ha costo: " + Math.Round(macchinario[selezione].CostoAnnuale(anni), 2)+ "\n";//scrive il costo del macchinario
            }
            else
            {
                risposta += "\nPer il " +anni+"^ anno il miglior macchinario e': " + macchinario[prezzi_ord[0].GetPosizione()].GetNome() + " con un risparmio di: " + Math.Round(macchinario[selezione].CostoAnnuale(anni) - prezzi_ord[0].GetCosto(), 2) + " euro sulla " + macchinario[selezione].GetNome()+ " che ha costo : " + Math.Round(macchinario[selezione].CostoAnnuale(anni), 2) + "\n";//indica il risparmio con il macchinario piú conveniente rispetto al macchinario scelto con il suo costo

            }
            return risposta;
        }
    }
}
