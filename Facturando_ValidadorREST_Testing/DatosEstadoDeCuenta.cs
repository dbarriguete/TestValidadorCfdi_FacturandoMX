using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Specialized;


namespace IdEx.Facturando_ValidadorREST_Testing
{
    public class DatosEstadoDeCuenta
    {
        public string RfcDistribuidor { get; set; }
        public string IdDistribuidor { get; set; }
        
        public string JsonDataToString()
        {
            string answer = "{ ";
            
            return answer + "}";
        }
    }
}