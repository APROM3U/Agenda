<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadClient.aspx.cs" Inherits="Cadastro_CadClient" %>

<!DOCTYPE html>
<html lang="pt-br">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="stylesheet" href="css/style">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

    <title>ERP - Agenda</title>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Panel ID="pnlGeral" runat="server" HorizontalAlign="Center" CssClass="align-top">
                <br />
                <%-- FILTRO --%>
                <div class="container h-75 w-75">
                    <asp:Panel ID="pnlFiltro" runat="server">
                        <div class="container">
                            <div class="shadow p-3 mb-2 bg-info rounded border text-light">
                                <h5>Filtrar</h5>
                            </div>
                            <div class="col-form-label col-md-auto border rounded">
                                <div class="alert-heading alert-dark rounded mb-2">
                                    <h6>Código</h6>
                                </div>
                                <div class="h-auto">
                                    <label id="lblCodInicial">Inicial: </label>
                                    <asp:TextBox ID="txtInicial" runat="server" MaxLength="8" Width="15%" ToolTip="Código inicial" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="h-auto">
                                    <label id="lblCodFinal">&nbsp; Final: </label>
                                    <asp:TextBox ID="txtFinal" runat="server" MaxLength="8" Width="15%" ToolTip="Código final" TabIndex="2"></asp:TextBox>
                                </div>
                                <br />
                                <div class="h-auto">
                                    <asp:Button ID="btnFiltrar" Text="Filtrar" runat="server" Width="80px" ToolTip="Filtrar" OnClick="btnFiltrar_Click" />
                                </div>
                            </div>
                            <div class="text-left">
                                <asp:LinkButton ID="lkInicialCad" Text="Inserir novo" runat="server" OnClick="lkInserir_Click" ToolTip="Inserir novo registro"></asp:LinkButton>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <%-- CADASTRO --%>
                <asp:Panel ID="pnlCadastro" runat="server" Visible="false" HorizontalAlign="Center">
                    <div class="container-fluid h-100 w-100">
                        <div class="container-fluid border-dark h-100 w-100">
                            <div class="shadow p-3 mb-2 bg-info rounded border h-100 w-100 text-light">
                                <h5>Cadastro</h5>
                            </div>
                            <div class="col-form-label container-fluid border rounded h-100 w-100">
                                <div class="text-left h-auto">
                                    <label id="lblCodigo">&nbsp; Código:</label>
                                    <asp:TextBox ID="txtCodigo" runat="server" MaxLength="8" Width="80px" ToolTip="Codigo" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="text-left h-auto">
                                    <label id="lblNome">&nbsp;&nbsp;&nbsp; Nome:</label>
                                    <asp:TextBox ID="txtNome" runat="server" MaxLength="80" Width="90%" TabIndex="3" ToolTip="Nome" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="text-left h-auto">
                                    <label id="lblEmail">&nbsp;&nbsp;&nbsp; E-mail:</label>
                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="80" Width="90%" TabIndex="4" ToolTip="E-mail" Enabled="false" TextMode="Email"></asp:TextBox>
                                </div>
                                <div class="text-left h-auto">
                                    <label id="lblFone" class="align-items-baseline">&nbsp;Telefone:</label>
                                    <asp:TextBox ID="txtFone" runat="server" MaxLength="16" Width="18%" TabIndex="5" ToolTip="Telefone" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="h-auto">
                                    <asp:Button ID="btnGravar" runat="server" Width="80px" Text="Gravar" ToolTip="Gravar" OnClick="btnGravar_Click" />
                                    <asp:Button ID="btnCancelar" runat="server" Width="80px" Text="Cancelar" ToolTip="Cancelar" OnClick="btnCancelar_Click" />
                                    <asp:Button ID="btnAlterar" runat="server" Width="80px" Text="Alterar" ToolTip="Alterar" OnClick="btnAlterar_Click" />
                                    <asp:Button ID="btnLimpar" runat="server" Width="80px" Text="Limpar" ToolTip="Limpar" OnClick="btnLimpar_Click" />
                                    <asp:Button ID="btnExcluir" runat="server" Width="80px" Text="Excluir" ToolTip="Excluir" OnClick="btnExcluir_Click" />
                                    <asp:Button ID="btnNovo" runat="server" Width="80px" Text="Novo" ToolTip="Novo" OnClick="btnNovo_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                </asp:Panel>
                <%-- GRID --%>
                <asp:Panel ID="pnlGrid" runat="server" Visible="false">
                    <div class="container">
                        <div class="table table-hover table-dark rounded h-100">
                            <asp:GridView ID="gvCadastro" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvCadastro_SelectedIndexChanged"
                                HorizontalAlign="Center" Width="100%">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="true" SelectImageUrl="~/Imagens/SelectedRow.gif" ButtonType="Image" />
                                    <asp:BoundField DataField="id"
                                        HeaderText="Código" />
                                    <asp:BoundField DataField="nome_client"
                                        HeaderText="Nome" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField DataField="tel_client"
                                        HeaderText="Telefone" ConvertEmptyStringToNull="true" />
                                    <asp:BoundField DataField="email_client"
                                        HeaderText="E-mail" ItemStyle-HorizontalAlign="Left" ConvertEmptyStringToNull="true" />
                                </Columns>
                            </asp:GridView>
                            <br />
                        </div>
                    </div>
                </asp:Panel>
                <asp:HiddenField ID="hCodigo" runat="server" />
                <asp:HiddenField ID="hOperacao" runat="server" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
