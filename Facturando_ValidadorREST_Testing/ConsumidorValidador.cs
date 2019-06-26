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
    public class ConsumidorValidador
    {
        public string ConsumirValidador(DatosParaValidar datos)
        {
            //string apiURL = "http://webapi.factura-electronica-gratis.net.100-42-52-208.hgws28.hgwin.temp.domains/API/ValidateCfdi";
            string apiURL = "http://localhost:61136/API/ValidateCfdi";
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
                catch(Exception fault)
                {
                    answer = "Ultima ejecución: "+ DateTime.Now + "ocurrió un error al procesar la solicitud: "+fault.Message +" Detalles: "+fault.StackTrace +answer;
                }
                
            }
            return answer;
        }


        //Intento 1
        //public async Task<string> ConsumirValidadorAsync( DatosParaValidar datosParaValidar )
        //{
        //    string apiURL = "http://webapi.factura-electronica-gratis.net.100-42-52-208.hgws28.hgwin.temp.domains/API/ValidateCfdi";

        //    // Create a new WebClient instance.
        //    WebClient myWebClient = new WebClient();
        //    //HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, apiURL);
        //    // StringContent contentMessage = null;
            

        //    //// Create a new NameValueCollection instance to hold some custom parameters to be posted to the URL.
        //    //NameValueCollection myNameValueCollection = new NameValueCollection();

        //    //// Add necessary parameter/value pairs to the name/value container.
        //    //myNameValueCollection.Add("data", datosParaValidar.JsonDataToString());
        //    //myNameValueCollection.Add("RfcDistribuidor", datosParaValidar.RfcDistribuidor);
        //    //myNameValueCollection.Add("IdDistribuidor", datosParaValidar.IdDistribuidor);

        //    Dictionary<string,string> values = new Dictionary<string, string>();
        //    values.Add("data", datosParaValidar.JsonDataToString());
        //    values.Add("RfcDistribuidor", datosParaValidar.RfcDistribuidor);
        //    values.Add("IdDistribuidor", datosParaValidar.IdDistribuidor);

        //    FormUrlEncodedContent content = new FormUrlEncodedContent(values);

        //    HttpResponseMessage response = await client.PostAsync(apiURL, content);

        //    string responseString = await response.Content.ReadAsStringAsync();

        //    //string answer = Encoding.ASCII.GetString(responseArray);
        //    return responseString;
        //}


        static HttpClient client = new HttpClient();

        //static void ShowProduct(Product product)
        //{
        //    Console.WriteLine($"Name: {product.Name}\tPrice: " +
        //        $"{product.Price}\tCategory: {product.Category}");
        //}

        //static async Task<Uri> SendDataToValidator(Product product)
        //{

        //    client.PostAsync("http://");
        //    HttpResponseMessage response = await client.PostAsJsonAsync(
        //        "api/products", product);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}



        //static async Task<Uri> CreateProductAsync(Product product)
        //{
            
        //    HttpResponseMessage response = await client.PostAsJsonAsync(
        //        "api/products", product);
        //    response.EnsureSuccessStatusCode();

        //    // return URI of the created resource.
        //    return response.Headers.Location;
        //}

        //static async Task<Product> GetProductAsync(string path)
        //{
        //    Product product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        product = await response.Content.ReadAsAsync<Product>();
        //    }
        //    return product;
        //}

        //static async Task<Product> UpdateProductAsync(Product product)
        //{
        //    HttpResponseMessage response = await client.PutAsJsonAsync(
        //        $"api/products/{product.Id}", product);
        //    response.EnsureSuccessStatusCode();

        //    // Deserialize the updated product from the response body.
        //    product = await response.Content.ReadAsAsync<Product>();
        //    return product;
        //}

        //static async Task<HttpStatusCode> DeleteProductAsync(string id)
        //{
        //    HttpResponseMessage response = await client.DeleteAsync(
        //        $"api/products/{id}");
        //    return response.StatusCode;
        //}

        //static void Main()
        //{
        //    RunAsync().GetAwaiter().GetResult();
        //}

        //static async Task RunAsync()
        //{
        //    // Update port # in the following line.
        //    client.BaseAddress = new Uri("http://localhost:64195/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        //    try
        //    {
        //        // Create a new product
        //        Product product = new Product
        //        {
        //            Name = "Gizmo",
        //            Price = 100,
        //            Category = "Widgets"
        //        };

        //        var url = await CreateProductAsync(product);
        //        Console.WriteLine($"Created at {url}");

        //        // Get the product
        //        product = await GetProductAsync(url.PathAndQuery);
        //        ShowProduct(product);

        //        // Update the product
        //        Console.WriteLine("Updating price...");
        //        product.Price = 80;
        //        await UpdateProductAsync(product);

        //        // Get the updated product
        //        product = await GetProductAsync(url.PathAndQuery);
        //        ShowProduct(product);

        //        // Delete the product
        //        var statusCode = await DeleteProductAsync(product.Id);
        //        Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }

        //    Console.ReadLine();
        //}
    }
}