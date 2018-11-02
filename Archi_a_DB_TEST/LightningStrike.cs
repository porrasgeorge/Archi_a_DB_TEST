using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archi_a_DB_TEST
{
    class LightningStrike
    {
        public LightningStrike(DateTime fechaHora, double latitud, double longitud)
        {
            FechaHora = fechaHora;
            this.latitud = latitud;
            this.longitud = longitud;
        }

        public DateTime FechaHora { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }
}