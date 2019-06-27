<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/IdExSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IdEx.Facturando_ValidadorREST_Testing._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div >
        <h1>Realizar pruebas para componente Validador CFDI</h1>
        <p class="lead">A continuación proporciona los datos necesarios para realizar la prueba que requieres </p>
    </div>

    <div class="row">
            <div class="col-12"><h2>Elije las opciones para enviar la prueba</h2></div>
            <div class="col-4" style="text-align:right;">RfcDistribuidor: </div><div class="col-8"><asp:TextBox ID="TbxRfcDistribuidor" text="" runat="server"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">IdDistribuidor: </div><div class="col-8"><asp:TextBox ID="TbxIdDistribuidor" text="" runat="server"></asp:TextBox></div>

            <div class="col-4" style="text-align:right;">Version: </div><div class="col-8"><asp:TextBox ID="TbxVersion" runat="server" Text=""></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">Xml: </div><div class="col-8"><asp:FileUpload ID="FplNewXml" runat="server" /></div>
            <div class="col-4" style="text-align:right;">FileName: </div><div class="col-8"><asp:TextBox ID="TbxFilename" runat="server" Enabled="false"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">EnterpriseRfc: </div><div class="col-8"><asp:TextBox ID="TbxEnterpriseRfc" Text="" runat="server"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">Identar: </div><div class="col-8"><asp:CheckBox ID="CbxIdent" runat="server" Checked="false" /></div>
            <div class="col-4" style="text-align:right;">ReportePdf: </div><div class="col-8"><asp:CheckBox ID="CbxReportPdf" runat="server" Checked="false" /></div>
            <div class="col-4" style="text-align:right;">AmountEpsilon: </div><div class="col-8"><asp:TextBox ID="TbxAmountEpsilon" Text="" runat="server"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">DocumentoStamp: </div><div class="col-8"><asp:TextBox ID="TbxDocumentToStamp" Text="" runat="server"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">RfcEmpresa: </div><div class="col-8"><asp:TextBox ID="TbxRfcEmpresa" Text="" runat="server"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">SupportFormatsOnDate: </div><div class="col-8"><asp:CheckBox ID="CbxSupportFormatsOnDate" runat="server" Checked="false" /></div>
            <!-- <div class="col-4" style="text-align:right;">ValidarSepomex: </div><div class="col-8"><asp:CheckBox ID="CbxValidSepomex" runat="server" Checked="false" /></div> -->
            <div class="col-4" style="text-align:right;">ValidarSchema: </div><div class="col-8"><asp:CheckBox ID="CbxValidSchema" runat="server" Checked="false" /></div>
            <!-- <div class="col-4" style="text-align:right;">ValidarCsd: </div><div class="col-8"><asp:CheckBox ID="CbxValidCsd" runat="server" Checked="false" /></div> -->
            <!-- <div class="col-4" style="text-align:right;">ValidatLco: </div><div class="col-8"><asp:CheckBox ID="CbxVAlidLco" runat="server" Checked="false" /></div> -->
            <div class="col-4" style="text-align:right;">Solicitar Documento: </div><div class="col-8"><asp:CheckBox ID="CbxRequestDocument" runat="server" Checked="false" /></div>
        <div class="col-4" style="text-align:right;">Solicitar Certificado: </div><div class="col-8"><asp:CheckBox ID="CbxRequestCertificate" runat="server" Checked="false" /></div>
        <div class="col-4" style="text-align:right;">Solicitar Timbre: </div><div class="col-8"><asp:CheckBox ID="CbxRequestTimbre" runat="server" Checked="false" /></div>
            <div class="col-12">&nbsp;</div>
        <!-- 
            <div class="col-12">Agregar propiedades extras: </div>
            <div class="col-12">&nbsp;</div>
            <div class="col-12"><asp:Button ID="BtnAddExtra" class="btn btn-info" runat="server" Text="Nueva propiedad de texto" OnClick="BtnAddExtra_Click" /><asp:Label ID="LblExtraValues" Visible="true" runat="server" Text=""></asp:Label></div>
            <div class="col-12">&nbsp;</div>
            <asp:Panel ID="PnlExtraValues" ViewStateMode="Enabled" runat="server" >
            </asp:Panel>
            <div class="col-12">&nbsp;</div>
            <div class="col-12"><asp:Button ID="BtnAddExtra2" class="btn btn-info" runat="server" Text="Nueva propiedad de texto" OnClick="BtnAddExtra_Click" /></div>
            <div class="col-12">&nbsp;<br />&nbsp;</div>
            <div class="col-12"><asp:Button ID="BtnAddExtraNumeric" class="btn btn-info" runat="server" Text="Nueva propiedad de texto" OnClick="BtnAddExtraNumeric_Click" /><asp:Label ID="LblExtraNumericValues" Visible="true" runat="server" Text=""></asp:Label></div>
            <div class="col-12">&nbsp;</div>
            <asp:Panel ID="PnlExtraNumericValues" ViewStateMode="Enabled" runat="server" >
            </asp:Panel>
            <div class="col-12">&nbsp;</div>
            <div class="col-12"><asp:Button ID="BtnAddExtraNumeric2" class="btn btn-info" runat="server" Text="Nueva propiedad de texto" OnClick="BtnAddExtraNumeric_Click" /></div>
        -->
            <div class="col-12">&nbsp;<br />&nbsp;</div>
            <div class="col-12"><asp:Label ID="LblErrorMessage" runat="server" Text="" ></asp:Label></div>
            <div class="col-12"><asp:Button ID="BtnValidate" runat="server" Text="Realizar validación" OnClick="BtnValidate_Click" class="btn btn-primary"/></div>
            <div  class="col-12">
                <p>
                    Los datos serán enviados y se mostrará la respuesta devuelta a continuación: 
                </p>
            </div>
            <div class="col-2">
                Resultado devuelto: 
            </div>
            <div class="col-10">
                
                <!-- <asp:TextBox ID="TbxResult" runat="server" TextMode="MultiLine"  Rows="20"></asp:TextBox> -->
                <asp:Label ID="LblResult" runat="server" Text=""></asp:Label>
                <asp:Label ID="LblPdfString" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        <div class="col-2"></div>
        <div class="col-10"><asp:LinkButton ID="LnkDownloadPDF" runat="server" OnClick="LnkDownloadPDF_Click" CssClass="btn btn-info" Visible="false">Descargar PDF</asp:LinkButton></div>        

        
    </div>

</asp:Content>
