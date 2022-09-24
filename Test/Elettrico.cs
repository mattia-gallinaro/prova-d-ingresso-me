using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Elettrico : Macchinario 
    {
        public Elettrico(double rendimento, double costo_init, string nome) : base(rendimento, costo_init, nome)//assegna i valori alle variabili omonime
        {
            
        }

        public override void Calcola_Consumo(double elettricita_utilizzata, double gas_consumato, double potere_calorifero)
        {
            consumo = (gas_consumato * potere_calorifero / rendimento) + elettricita_utilizzata;//converte gli Smc utilizzati all'anno in kWh e li somma a quelli che giá utilizza 
        }
        public override void Costo_Totale(Bolletta elettricita)//richiama la funzione del padre per calcolare il costo totale della macchina per il primo anno
        {
            base.Costo_Totale(elettricita);
        }
    }
}
