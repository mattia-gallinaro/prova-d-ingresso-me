using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Caldaia : Macchinario
    {
        public Caldaia(double rendimento, double costo_Iniziale, string nome) : base(rendimento, costo_Iniziale, nome)
        {
            
        }

        public override void Calcola_Consumo(double kWh, double Smc, double potere_calorifero)
        {
            consumo = kWh / (potere_calorifero * rendimento) + Smc;
        }
        public override void Costo_Totale(Bolletta gas)
        {
            base.Costo_Totale(gas);
        }
    }
}
