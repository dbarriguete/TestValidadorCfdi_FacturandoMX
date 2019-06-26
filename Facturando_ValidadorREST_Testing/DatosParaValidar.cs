using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Specialized;

namespace IdEx.Facturando_ValidadorREST_Testing
{
    public class DatosParaValidar
    {
        public string RfcDistribuidor { get; set; }
        public string IdDistribuidor { get; set; }

        public string Version       { get; set; }
        public string Xml           { get; set; }
        public string FileName      { get; set; }
        public string EnterpriseRfc { get; set; }
        public bool Identar         { get; set; }
        public bool ReportePdf      { get; set; }
        public string AmountEpsilon { get; set; }
        public string DocumentoStamp { get; set; }
        public string RfcEmpresa    { get; set; }
        public bool SupportFormatsOnDate { get; set; }
        // public bool ValidarSepomex  { get; set;}
        public bool ValidarSchema   { get; set;}
        // public bool ValidarCsd      { get; set;}
        // public bool ValidarLco      { get; set; }

        public NameValueCollection ExtraDataString { get; set; }
        public NameValueCollection ExtraDataNumericAndBool { get; set; }

        public string JsonDataToString ()
        {
            string answer = "{";
            JsonSerializer jsonserial = new JsonSerializer();

            answer = answer + "\"Version\": \"" + Version + "\", ";

            if (Xml != null)
            {
                answer = answer + " \"xml\":\"" + Xml + "\", ";
            }

            answer = answer + " \"FileName\": \"" + FileName + "\", " +
                                        " \"EnterpriseRfc\": \"" + EnterpriseRfc + "\", " +
                                        " \"Identar\": " + Identar.ToString().ToLower() + ", " +
                                        " \"ReportePdf\": " + ReportePdf.ToString().ToLower() + ", " +
                                        " \"AmountEpsilon\": " + AmountEpsilon + ", " +
                                        " \"DocumentToStamp\": " + DocumentoStamp + ", " +
                                        " \"SupportFormatsOnDate\": " + SupportFormatsOnDate.ToString().ToLower() + ", " +
                                        " \"RfcEmpresa\": \"" + RfcEmpresa + "\", " +
                                        //  " \"ValidarSepomex\": " + ValidarSepomex.ToString().ToLower() + ", " +
                                        // " \"ValidarSchema\": " + (ValidarSchema).ToString().ToLower() + " ";
                                        " \"DisableSchemaValidation\": " + (!ValidarSchema).ToString().ToLower() + " ";
                                        
                                    //  " \"ValidarCsd\": " + ValidarCsd.ToString().ToLower() + ", " +
                                    //  " \"ValidarLco\": " + ValidarLco.ToString().ToLower() + " ";

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


            return answer+"}";
        }
    }
}