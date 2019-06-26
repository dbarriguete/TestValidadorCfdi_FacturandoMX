using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IdEx.Facturando_ValidadorREST_Testing
{
    public partial class TestFindCfdi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnFindCfdi_Click(object sender, EventArgs e)
        {
            LblErrorMessage.Text = "";

            DatosBuscarCfdi validaMe = new DatosBuscarCfdi();

            validaMe.RfcDistribuidor = TbxRfcDistribuidor.Text;
            validaMe.IdDistribuidor = TbxIdDistribuidor.Text;

            validaMe.Version = TbxVersion.Text;
            validaMe.RfcEmisor = TbxRfcEmisor.Text;
            validaMe.RfcReceptor = TbxRfcReceptor.Text;
            validaMe.Total = TbxTotal.Text;
            validaMe.Uuid = TbxUuid.Text;

            ConsumidorBuscadorCfdi consumidorRest = new ConsumidorBuscadorCfdi();

            //Task<string> answer = null;
            //answer = consumidorRest.ConsumirValidador(validaMe);
            string answerString = consumidorRest.ConsumirFindCfdi(validaMe);




            // TbxResult.Text = answer.Result;
            // TbxResult.Text = answerString;
            LblResult.Text = answerString.Replace(" ", "&nbsp;&nbsp;").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;").Replace("\r\n", "<br/>").Replace(",", ",<br/>");

            JToken token = null;
            try
            {

                JObject jsonObject = JObject.Parse(answerString);
                token = jsonObject.GetValue("ReportePdf");
            }
            catch (Exception fault)
            {
                // TbxResult.Text = TbxResult.Text + "\r\nEl valor devuelto no se puede interpretar, no es un JSON ";
                LblResult.Text = LblResult.Text + "\r\nEl valor devuelto no se puede interpretar, no es un JSON ";
            }

            if (token != null)
            {
                // JObject thisisme = null;
                LblPdfString.Text = token.Value<string>();
                // LnkDownloadPDF.Visible = true;
            }
            else
            {
                LblPdfString.Text = "";
                // LnkDownloadPDF.Visible = false;
            }

        }

        protected void LnkDownloadPDF_Click(object sender, EventArgs e)
        {

        }
    }
}