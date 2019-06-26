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
    public partial class TestAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAccount_Click(object sender, EventArgs e)
        {

            LblErrorMessage.Text = "";

            DatosEstadoDeCuenta validaMe = new DatosEstadoDeCuenta();

            validaMe.RfcDistribuidor = TbxRfcDistribuidor.Text;
            validaMe.IdDistribuidor = TbxIdDistribuidor.Text;

            ConsumidorEstadoDeCuenta consumidorRest = new ConsumidorEstadoDeCuenta();

            //Task<string> answer = null;
            //answer = consumidorRest.ConsumirValidador(validaMe);
            string answerString = consumidorRest.ConsumirEstadoDeCuenta(validaMe);

            // TbxResult.Text = answer.Result;
            // TbxResult.Text = answerString;
            LblResult.Text = answerString.Replace(" ", "&nbsp;&nbsp;").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;").Replace("\r\n", "<br/>").Replace(",",",<br/>");

        }
    }
}