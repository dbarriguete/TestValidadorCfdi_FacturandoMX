using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdEx.Facturando_ValidadorREST_Testing
{
    public class DPVCertificado
    {
        public bool Version { get; set; }
        public bool EmitidoPor { get; set; }

        public DPVCertificado()
        {
            Version = true;
            EmitidoPor = true;
        }
    }
}