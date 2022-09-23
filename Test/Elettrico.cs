using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Elettrico : Macchinario 
    {
        public Elettrico(double rendimento, double costo_init) : base(rendimento, costo_init)
        {
            
        }

        public override void Calcola_Consumo(double elettricita_utilizzata, double gas_consumato, double potere_calorifero)
        {
            consumo = (gas_consumato * potere_calorifero / rendimento) + elettricita_utilizzata;
        }
        public override void Costo_Totale(Bolletta elettricita)
        {
            base.Costo_Totale(elettricita);
        }
    }
}
