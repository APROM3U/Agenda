<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadClient.aspx.cs" Inherits="Cadastro_CadClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" runat="server" />
    <title>ERP</title>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <asp:Panel ID="pnlGeral" runat="server">
                <h2>ERP</h2>
                <%-- FILTRO --%>
                <asp:Panel ID="pnlFiltro" runat="server">
                    <div class="form1" style="width: 350px">
                        <div>
                            <h3>Filtrar
                            </h3>
                        </div>
                        <fieldset>
                            <legend>Código
                            </legend>
                            <div align="center">
                                <label for="id">Inicial:</label>
                                <asp:TextBox ID="txtInicial" runat="server" MaxLength="8" Width="80px" ToolTip="Codigo inicial" TabIndex="1"></asp:TextBox>
                            </div>
                            <div align="center">
                                <label for="id">&nbsp;&nbsp;Final:</label>
                                <asp:TextBox ID="txtFinal" runat="server" MaxLength="8" Width="80px" ToolTip="Codigo final" TabIndex="2"></asp:TextBox>
                            </div>
                            <br />
                            <div align="center">
                                <asp:Button ID="btnFiltrar" Text="Filtrar" runat="server" Width="60px" ToolTip="Filtrar" OnClick="btnFiltrar_Click" />
                            </div>
                        </fieldset>
                        <div align="left">
                            <asp:LinkButton ID="lkInserir" Text="Inserir novo" runat="server" OnClick="lkInserir_Click" ToolTip="Inserir novo registro"></asp:LinkButton>
                        </div>
                    </div>
                </asp:Panel>
                <%-- CADASTRO --%>
                <asp:Panel ID="pnlCadastro" runat="server" Visible="false" Width="700px">
                    <div>
                        <h3>Cadastro
                        </h3>
                    </div>
                    <div dir="ltr">
                        <fieldset>
                            <legend>Cadastro</legend>
                            <div align="left">
                            </div>
                            <div align="left">
                                <label for="id">&nbsp;&nbsp;Código:</label>
                                <asp:TextBox ID="txtCodigo" runat="server" MaxLength="8" Width="80px" ToolTip="Codigo" Enabled="false" TextMode="Number"></asp:TextBox>
                            </div>
                            <div align="left">
                                <label for="nome_client">&nbsp;&nbsp;&nbsp;&nbsp;Nome:</label>
                                <asp:TextBox ID="txtNome" runat="server" MaxLength="80" Width="550px" TabIndex="3" ToolTip="Nome" Enabled="false"></asp:TextBox>
                            </div>
                            <div align="left">
                                <label for="email_client">&nbsp;&nbsp;&nbsp;E-mail:</label>
                                <asp:TextBox ID="txtEmail" runat="server" MaxLength="80" Width="550px" TabIndex="4" ToolTip="E-mail" Enabled="false" TextMode="Email"></asp:TextBox>
                            </div>
                            <div align="left">
                                <label for="tel_client">Telefone:</label>
                                <asp:TextBox ID="txtFone" runat="server" MaxLength="20" Width="150px" TabIndex="5" ToolTip="Telefone" Enabled="false"></asp:TextBox>
                            </div>
                        </fieldset>
                    </div>
                    <div>
                        <br />
                        <asp:Button ID="btnGravar" runat="server" Width="70px" Text="Gravar" ToolTip="Gravar" OnClick="btnGravar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Width="70px" Text="Cancelar" ToolTip="Cancelar" OnClick="btnCancelar_Click" />
                        <asp:Button ID="btnAlterar" runat="server" Width="70px" Text="Alterar" ToolTip="Alterar" OnClick="btnAlterar_Click" />
                        <asp:Button ID="btnLimpar" runat="server" Width="70px" Text="Limpar" ToolTip="Limpar" OnClick="btnLimpar_Click" />
                        <asp:Button ID="btnExcluir" runat="server" Width="70px" Text="Excluir" ToolTip="Excluir" OnClick="btnExcluir_Click" />
                    </div>
                    <br />
                </asp:Panel>
                <%-- GRID --%>
                <asp:Panel ID="pnlGrid" runat="server" Width="1000px" HorizontalAlign="Center" Visible="false">
                    <div align="center">
                        <asp:GridView ID="gvCadastro" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCadastro_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ShowSelectButton="true" ButtonType="Button" HeaderImageUrl="~/Imagens/SelectedRow.gif" />
                                <asp:BoundField DataField="id"
                                    HeaderText="Código" ReadOnly="True" />
                                <asp:BoundField DataField="nome_client" ReadOnly="True"
                                    HeaderText="Nome" />
                                <asp:BoundField DataField="tel_client" ReadOnly="True"
                                    HeaderText="Telefone" />
                                <asp:BoundField DataField="email_client" ReadOnly="True"
                                    HeaderText="E-mail" />
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="odsConsulta" runat="server" SelectMethod="Pesquisar"
                            OldValuesParameterFormatString="original_{0}" TypeName="DALCadastro">
                            <SelectParameters>
                                <asp:Parameter Name="inicial" Type="Int32" />
                                <asp:Parameter Name="final" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </asp:Panel>
                <asp:HiddenField ID="hCodigo" runat="server" />
                <asp:HiddenField ID="hOperacao" runat="server" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
