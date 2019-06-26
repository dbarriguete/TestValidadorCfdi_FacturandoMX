using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Specialized;

namespace IdEx.Facturando_ValidadorREST_Testing
{
    public class ConsumidorBuscadorCfdi
    {
        static HttpClient client = new HttpClient();

        public string ConsumirFindCfdi(DatosBuscarCfdi datos)
        {
            //string apiURL = "http://webapi.factura-electronica-gratis.net.100-42-52-208.hgws28.hgwin.temp.domains/API/FindCfdi";
            string apiURL = "http://localhost:61136/API/FindCfdi";
            string answer = "";
            using (WebClient client = new WebClient())
            {
                //Create a new NameValueCollection instance to hold some custom parameters to be posted to the URL.
                NameValueCollection myNameValueCollection = new NameValueCollection();

                // Add necessary parameter/value pairs to the name/value container.
                myNameValueCollection.Add("data", datos.JsonDataToString());
                myNameValueCollection.Add("RfcDistribuidor", datos.RfcDistribuidor);
                myNameValueCollection.Add("IdDistribuidor", datos.IdDistribuidor);

                byte[] responsebytes = null;

                try
                {
                    responsebytes = client.UploadValues(apiURL, "POST", myNameValueCollection);
                    answer = Encoding.UTF8.GetString(responsebytes);
                }
                catch (Exception fault)
                {
                    answer = "Ultima ejecución: " + DateTime.Now + "ocurrió un error al procesar la solicitud: " + fault.Message + " Detalles: " + fault.StackTrace + answer;
                }

            }
            return answer;
        }


    }
}