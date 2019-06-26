using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace IdEx.Facturando_ValidadorREST_Testing
{
    public class DatosBuscarCfdi
    {
        public string RfcDistribuidor { get; set; }
        public string IdDistribuidor { get; set; }

        public string Version { get; set; }
        public string RfcEmisor { get; set; }
        public string RfcReceptor { get; set; }
        public string Uuid { get; set; }
        public string Total { get; set; }

        public NameValueCollection ExtraDataString { get; set; }
        public NameValueCollection ExtraDataNumericAndBool { get; set; }

        public string JsonDataToString()
        {
            string answer = "{";
            JsonSerializer jsonserial = new JsonSerializer();

            answer = answer + "\"Version\": \"" + Version + "\", " +
                            " \"RfcEmisor\": \"" + RfcEmisor + "\", " +
                            " \"RfcReceptor\": \"" + RfcReceptor + "\", " +
                            " \"Uuid\": \"" + Uuid + "\" ";
            if (Total!=null && !Total.Equals("") && Total.Trim().Length>0)
            {
                answer = answer + ", \"Total\": " + Total;
            }
                            

            //se agregan los datos enviados dinámicamente
            if (ExtraDataString != null)
            {
                foreach (string key in ExtraDataString.Keys)
                {
                    answer = answer + ", \"" + key + "\": \"" + ExtraDataString[key] + "\"";
                }
            }

            if (ExtraDataNumericAndBool != null)
            {
                foreach (string key in ExtraDataNumericAndBool.Keys)
                {
                    answer = answer + ", \"" + key + "\": " + ExtraDataNumericAndBool[key] + " ";
                }
            }


            return answer + "}";
        }
    }
}