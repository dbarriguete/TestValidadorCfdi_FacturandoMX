using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdEx.Facturando_ValidadorREST_Testing
{
    public class DPVDocumento
    {
        public bool Documento { get; set; }
        public bool NumeroCertificado { get; set; }
        public bool Sello { get; set; }
        public bool CadenaOriginal { get; set; }
        public bool CadenaOriginalPac { get; set; }

        public DPVDocumento()
        {
            Documento = true;
            NumeroCertificado = true;
            Sello = true;
            CadenaOriginal = true;
            CadenaOriginalPac = true;
        }
    }
}