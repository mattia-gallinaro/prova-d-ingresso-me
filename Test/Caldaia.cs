using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Caldaia : Macchinario
    {
        public Caldaia(double rendimento, double costo_Iniziale, string tipo) : base(rendimento, costo_Iniziale, tipo)
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
