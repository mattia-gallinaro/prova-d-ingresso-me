using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcola_Scelta_Macchinario
{
    class Elettrico : Macchinario
    {
        public Elettrico(double rendimento, double costo_init) : base(rendimento, costo_init)
        {
            this.rendimento = rendimento;
            prezzo = costo_init;
            consumo = 0;
            costo_tot = 0;
        }

        public override void Calcola_Consumo(double elettricita_utilizzata, double gas_consumato , double potere_calorifero)
        {
            consumo = (gas_consumato * potere_calorifero / rendimento) + elettricita_utilizzata;
        }
        public override void Costo_Totale(Bolletta elettricita)
        {
            base.Costo_Totale(elettricita);           
        }
    }
}
