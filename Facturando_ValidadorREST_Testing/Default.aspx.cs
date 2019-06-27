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
    public partial class _Default : Page
    {
        public const string UuidExpresion = "^[0-9A-F]{8}\\-[0-9A-F]{4}\\-[0-9A-F]{4}\\-[0-9A-F]{4}\\-[0-9A-F]{12}$";
        public const string ElectronicMailExpression = "[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?";
        public const string RfcExpression = "^[A-Z,&,Ñ]{3,4}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[A-Z0-9]{2}[0-9A]$";
        public const string CurpExpression = "^[A-Z][AEIOUX][A-Z]{2}[0-9]{2}(0[1-9]|1[012])(0[1-9]|[12][0-9]|3[01])[MH]([ABCMTZ]S|[BCJMOT]C|[CNPST]L|[GNQ]T|[GQS]R|C[MH]|[MY]N|[DH]G|NE|VZ|DF|SP)[BCDFGHJ-NP-TV-Z]{3}[0-9A-Z][0-9]$";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            GenerateExtraFields();
            GenerateExtraNumericFields();
        }

        protected void BtnAddExtra_Click(object sender, EventArgs e)
        {

            string totalControls = LblExtraValues.Text;
            string[] totalControlsArray = null;

            if (LblExtraValues.Text.Length == 0)
            {
                LblExtraValues.Text = "1";
            }
            else
            {
                totalControlsArray = totalControls.Split(',');
                int newElement = totalControlsArray.Count() + 1;
                LblExtraValues.Text = LblExtraValues.Text + "," + newElement;
            }

            GenerateExtraFields();

        }

        private void LoadExtraValues()
        {

        }

        protected void BtnAddExtraNumeric_Click(object sender, EventArgs e)
        {

            string totalControls = LblExtraNumericValues.Text;
            string[] totalControlsArray = null;

            if (LblExtraValues.Text.Length == 0)
            {
                LblExtraValues.Text = "1";
            }
            else
            {
                totalControlsArray = totalControls.Split(',');
                int newElement = totalControlsArray.Count() + 1;
                LblExtraNumericValues.Text = LblExtraNumericValues.Text + "," + newElement;
            }

            GenerateExtraNumericFields();
        }

        private void GenerateExtraFields()
        {
            if (LblExtraNumericValues.Text.Length > 0)
            {
                string[] totalControlsArray = LblExtraNumericValues.Text.Split(',');
                Control nuevoValor = null;

                foreach (string controlIdentificator in totalControlsArray)
                {
                    nuevoValor = Page.LoadControl("WucExtraValue.ascx");
                    nuevoValor.ID = "ExtraValue_" + controlIdentificator;
                    this.PnlExtraNumericValues.Controls.Add(nuevoValor);
                }
            }
        }


        private void GenerateExtraNumericFields()
        {
            if (LblExtraValues.Text.Length > 0)
            {
                string[] totalControlsArray = LblExtraValues.Text.Split(',');
                Control nuevoValor = null;

                foreach (string controlIdentificator in totalControlsArray)
                {
                    nuevoValor = Page.LoadControl("WucExtraValue.ascx");
                    nuevoValor.ID = "ExtraValue_" + controlIdentificator;
                    this.PnlExtraValues.Controls.Add(nuevoValor);
                }
            }
        }


        protected void BtnValidate_Click(object sender, EventArgs e)
        {
            //if (FplNewXml.HasFile)
            //{
            string filename = "";
            String asBase64String = "";
            LblErrorMessage.Text = "";



            try
            {
                if (FplNewXml.HasFile)
                {
                    //filename = Guid.NewGuid().ToString("N") + Path.GetFileName(FplNewXml.FileName);
                    filename = Path.GetFileName(FplNewXml.FileName);

                    //FplNewXml.SaveAs(Server.MapPath("~\\Ejemplos\\") + filename);

                    //reading the information 

                    //byte[] AsBytes = File.ReadAllBytes(Server.MapPath("~\\Ejemplos\\") + filename);
                    byte[] asBytes = FplNewXml.FileBytes;
                    asBase64String = Convert.ToBase64String(asBytes);

                    //deleting file
                    //File.Delete(Server.MapPath("~\\Ejemplos\\") + filename);
                }
                else
                {
                    //no se manda ningún archivo
                    asBase64String = null;
                    filename = "";
                }
            }
            catch (Exception ex)
            {
                LblErrorMessage.Text = "Por favor elija un archivo.";
                // TbxResult.Text = " Ejecución sin archivo adjunto, elija un archivo. \r\n" + TbxResult.Text;
                LblResult.Text = " Ejecución sin archivo adjunto, elija un archivo. \r\n" + LblResult.Text;
                return;
            }



            DatosParaValidar validaMe = new DatosParaValidar();

            validaMe.RfcDistribuidor = TbxRfcDistribuidor.Text;
            validaMe.IdDistribuidor = TbxIdDistribuidor.Text;

            validaMe.Version = TbxVersion.Text;
            validaMe.Xml = asBase64String;
            validaMe.FileName = filename;
            validaMe.EnterpriseRfc = TbxEnterpriseRfc.Text;
            validaMe.Identar = CbxIdent.Checked;
            validaMe.ReportePdf = CbxReportPdf.Checked;
            validaMe.AmountEpsilon = TbxAmountEpsilon.Text;
            validaMe.DocumentoStamp = TbxDocumentToStamp.Text;
            validaMe.RfcEmpresa = TbxRfcEmpresa.Text;
            validaMe.SupportFormatsOnDate = CbxSupportFormatsOnDate.Checked;
            // validaMe.ValidarSepomex = CbxValidSepomex.Checked;
            validaMe.ValidarSchema = CbxValidSchema.Checked;
            // validaMe.ValidarCsd = CbxValidCsd.Checked;
            // validaMe.ValidarLco = CbxVAlidLco.Checked;
            
            if(CbxRequestDocument.Checked)
            {
                validaMe.Documento = new DPVDocumento();
            }
            else
            {
                validaMe.Documento = null;
            }

            if(CbxRequestCertificate.Checked)
            {
                validaMe.Certificado = new DPVCertificado();
            }
            else
            {
                validaMe.Certificado = null;
            }

            if (CbxRequestTimbre.Checked)
            {
                validaMe.Timbre = new DPVTimbre();
            }
            else
            {
                validaMe.Timbre = null;
            }

            ConsumidorValidador consumidorRest = new ConsumidorValidador();

            //Task<string> answer = null;
            //answer = consumidorRest.ConsumirValidador(validaMe);
            string answerString = consumidorRest.ConsumirValidador(validaMe);




            // TbxResult.Text = answer.Result;
            // TbxResult.Text = answerString;
            LblResult.Text = answerString.Replace(" ", "&nbsp;").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;").Replace("\r\n","<br/>");

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
                LnkDownloadPDF.Visible = true;
            }
            else
            {
                LblPdfString.Text = "";
                LnkDownloadPDF.Visible = false;
            }

            //Response.Clear();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("Content-Disposition", "attachment;filename=\"NuevoArchivoDeValidacion.pdf\"");

            //// edit this line to display ion browser and change the file name
            //Response.BinaryWrite(System.IO.File.ReadAllBytes("MyPdf.pdf"));

            //// gets our pdf as a byte array and then sends it to the buffer

            //Response.Flush();

            //}
            //else
            //{
            //    LblErrorMessage.Text = "Por favor elija un archivo.";
            //    TbxResult.Text = "Ejecución sin archivo adjunto, elija un archivo.--------------------\r\n" + TbxResult.Text ;
            //}
        }

        protected void LnkDownloadPDF_Click(object sender, EventArgs e)
        {
            Response.AddHeader("Content-Type", "application/pdf");
            //Response.AddHeader("Content-Length", base64Result.Length.ToString());
            Response.AddHeader("Content-Disposition", "inline;");
            Response.AddHeader("Cache-Control", "private, max-age=0, must-revalidate");
            Response.AddHeader("Pragma", "public");
            Response.BinaryWrite(Convert.FromBase64String(LblPdfString.Text));
        }
    }
}