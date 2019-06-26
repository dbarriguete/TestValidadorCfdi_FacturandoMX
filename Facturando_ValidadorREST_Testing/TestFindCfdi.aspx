<%@ Page Title="" Language="C#" MasterPageFile="~/IdExSite.master" AutoEventWireup="true" CodeBehind="TestFindCfdi.aspx.cs" Inherits="IdEx.Facturando_ValidadorREST_Testing.TestFindCfdi" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div >
        <h1>Realizar pruebas para componente Buscador CFDI</h1>
        <p class="lead">A continuación proporciona los datos necesarios para realizar la prueba que requieres </p>
    </div>

    <div class="row">
            <div class="col-12"><h2>Elije las opciones para enviar la prueba</h2></div>
            <div class="col-4" style="text-align:right;">RfcDistribuidor: </div><div class="col-8"><asp:TextBox ID="TbxRfcDistribuidor" text="" runat="server"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">IdDistribuidor: </div><div class="col-8"><asp:TextBox ID="TbxIdDistribuidor" text="" runat="server"></asp:TextBox></div>

            <div class="col-4" style="text-align:right;">Version: </div><div class="col-8"><asp:TextBox ID="TbxVersion" runat="server" Text=""></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">RFCEmisor: </div><div class="col-8"><asp:TextBox ID="TbxRfcEmisor" Text="" runat="server"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">RFCReceptor: </div><div class="col-8"><asp:TextBox ID="TbxRfcReceptor" Text="" runat="server"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">Uuid: </div><div class="col-8"><asp:TextBox ID="TbxUuid" Text="" runat="server"></asp:TextBox></div>
            <div class="col-4" style="text-align:right;">Total: </div><div class="col-8"><asp:TextBox ID="TbxTotal" Text="" runat="server"></asp:TextBox></div>

            <div class="col-12">&nbsp;</div>

            <div class="col-12">&nbsp;<br />&nbsp;</div>
            <div class="col-12"><asp:Label ID="LblErrorMessage" runat="server" Text="" ></asp:Label></div>
            <div class="col-12"><asp:Button ID="BtnFindCfdi" runat="server" Text="Buscar Cfdi" OnClick="BtnFindCfdi_Click" class="btn btn-primary"/></div>
            <div  class="col-12">
                <p>
                    Los datos serán enviados y se mostrará la respuesta devuelta a continuación: 
                </p>
            </div>
            <div class="col-2">
                Resultado devuelto: 
            </div>
            <div class="col-10">
                <asp:Label ID="LblResult" runat="server" Text=""></asp:Label>
                <asp:Label ID="LblPdfString" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        <div class="col-2"></div>
        <div class="col-10"></div>
    </div>
</asp:Content>

