using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    //classe per i
    class Caldaia : Macchinario
    {
        public Caldaia(double rendimento, double costo_Iniziale, string nome) : base(rendimento, costo_Iniziale, nome)//assegna i valori alle variabili omonime
        {
            
        }

        public override void Calcola_Consumo(double kWh, double Smc, double potere_calorifero)//riprende la funzione del padre e calcola il consumo della macchina
        {
            consumo = kWh / (potere_calorifero * rendimento) + Smc;//converte i kwh utilizzati all'anno in Smc e li somma a quelli che giá utilizza 
        }
        public override void Costo_Totale(Bolletta gas)//richiama la funzione del padre per calcolare il costo totale della macchina per il primo anno
        {
            base.Costo_Totale(gas);
        }
    }
}
