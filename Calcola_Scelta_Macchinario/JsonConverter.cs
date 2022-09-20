using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcola_Scelta_Macchinario
{
    class JsonConverter
    {
        public readonly double kWh, Smc;
        public readonly int selezione;
        //public readonly string kWh, Smc, selezione;
        public JsonConverter(double kWh, double Smc, int selezione)
        {
            this.kWh = kWh;
            this.Smc = Smc;
            this.selezione = selezione;
        }
    }
}
