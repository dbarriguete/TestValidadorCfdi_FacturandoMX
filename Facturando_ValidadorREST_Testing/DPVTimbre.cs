using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdEx.Facturando_ValidadorREST_Testing
{
    public class DPVTimbre
    {
        public bool NumeroCertificadoSat { get; set; }
        public bool SelloCfd { get; set; }
        public bool SelloSat { get; set; }

        public DPVTimbre()
        {
            NumeroCertificadoSat = true;
            SelloCfd = true;
            SelloSat = true;
        }
    }
}