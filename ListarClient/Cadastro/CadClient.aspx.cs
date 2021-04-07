using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cadastro_CadClient : Page
{
    #region Page Load

    private string strConexao = "Data Source = CENTER; Initial Catalog = projet; Integrated Security = True";
    private string msg = "";

    //private int _Codigo = 0;
    private int? _Ini = null;
    private int? _Fin = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (!IsPostBack)
            {
                txtInicial.Focus();
                Limpar();
            }

        }
        catch
        {

        }
    }

    #endregion

    #region Botões

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        if (!ValidaFiltro()) return;

        try
        {
            CarregaDados();
            mostrarPainel(true, true, false);
        }
        catch
        {

        }
    }

    protected void btnGravar_Click(object sender, EventArgs e)
    {
        if (!Validacao()) return;

        try
        {
            Gravar();
            CarregaDados();
        }
        catch
        {

        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        mostrarPainel(true, false, false);
    }

    protected void btnAlterar_Click(object sender, EventArgs e)
    {
        try
        {
            hOperacao.Value = "U";
            habilitarBtn(true, true, false, true, true);
            habilitarCad(true, true, true);
        }
        catch
        {

        }
    }

    protected void btnLimpar_Click(object sender, EventArgs e)
    {
        try
        {
            Limpar();
        }
        catch
        {

        }
    }


    protected void btnExcluir_Click(object sender, EventArgs e)
    {
        try
        {
            Excluir();
        }
        catch
        {

        }
    }

    protected void lkInserir_Click(object sender, EventArgs e)
    {
        try
        {
            hOperacao.Value = "I";
            Limpar();
            mostrarPainel(false, false, true);
            habilitarBtn(true, true, false, true, false);
            habilitarCad(true, true, true);
        }
        catch
        {

        }
    }

    #endregion

    #region Métodos

    protected void mostrarPainel(bool Filtro, bool Grid, bool Cad)
    {
        pnlFiltro.Visible = Filtro;
        pnlGrid.Visible = Grid;
        pnlCadastro.Visible = Cad;
    }

    protected void habilitarCad(bool Nome, bool Email, bool Fone)
    {
        txtNome.Enabled = Nome;
        txtEmail.Enabled = Email;
        txtFone.Enabled = Fone;
    }

    protected void habilitarBtn(bool Gravar, bool Cancelar, bool Alterar, bool Limpar, bool Excluir)
    {
        btnGravar.Visible = Gravar;
        btnCancelar.Visible = Cancelar;
        btnAlterar.Visible = Alterar;
        btnLimpar.Visible = Limpar;
        btnExcluir.Visible = Excluir;
    }

    protected void CarregaDados()
    {
        DataTable oDt = new DataTable();
        Conexao oConnect = new Conexao(strConexao);
        DALCadastro oConsulta = new DALCadastro(oConnect);

        if (_Ini == null) _Ini = 1;
        if (_Fin == null) _Fin = 99999999;

        var lista = oConsulta.Pesquisar(_Ini, _Fin);
        if (lista != null && lista.Rows.Count > 0)
        {
            this.gvCadastro.DataSource = lista;
            this.gvCadastro.DataBind();
        }
        else
        {
            this.msg = "Nenhum registro encontrado.";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem", "alert('" + msg + "'); ", true);
        }

    }

    protected void Limpar()
    {
        if (hOperacao.Value == "U")
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            txtFone.Text = "";
        }
        else
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtEmail.Text = "";
            txtFone.Text = "";
        }
    }

    protected void Gravar()
    {
        Cadastro cad = new Cadastro();
        Conexao con = new Conexao(strConexao);
        DALCadastro d = new DALCadastro(con);

        // Variáveis
        cad.Nome = txtNome.Text;
        cad.Email = txtEmail.Text;
        cad.Fone = txtFone.Text;

        try
        {
            switch (hOperacao.Value)
            {
                case "I":
                    d.Incluir(cad);
                    this.msg = "Cadastrado com sucesso! Registro número: ";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem", "alert('" + msg + cad.Id.ToString() + "'); ", true);
                    break;
                case "U":
                    cad.Id = Convert.ToInt32(txtCodigo.Text);
                    d.Alterar(cad);
                    this.msg = "Alterado com sucesso!";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem", "alert('" + msg + "'); ", true);
                    break;
            }

            Limpar();
            mostrarPainel(true, true, false);
        }
        catch (Exception)
        {

        }
        finally
        {

        }

    }

    protected void Excluir()
    {
        Conexao c = new Conexao(strConexao);
        DALCadastro d = new DALCadastro(c);
        Cadastro ctt = new Cadastro();

        try
        {
            if (hOperacao.Value != "D")
            {
                hOperacao.Value = "D";
                habilitarBtn(false, true, false, false, true);
            }
            else
            {
                d.Excluir(Convert.ToInt32(hCodigo.Value));
                Limpar();
                CarregaDados();
                mostrarPainel(true, true, false);
            }
        }
        catch
        {

        }
    }

    // Valida Salvar
    protected bool Validacao()
    {
        if (txtNome.Text == "" && txtFone.Text == "" && txtEmail.Text == "")
        {
            this.msg = "Informe o nome e um email ou telefone para contato";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem", "alert('" + msg + "'); ", true);
            return false;
        }
        else if (txtNome.Text == "" && (txtFone.Text != "" || txtEmail.Text != ""))
        {
            this.msg = "Informe o nome";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem", "alert('" + msg + "'); ", true);
            return false;
        }
        else if (txtFone.Text == "" && txtEmail.Text == "")
        {
            this.msg = "Informe um e-mail ou telefone para contato";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem", "alert('" + msg + "'); ", true);
            return false;
        }
        else return true;
    }

    // Valida Filtro
    protected bool ValidaFiltro()
    {
        if (!string.IsNullOrEmpty(txtInicial.Text)) _Ini = Convert.ToInt32(txtInicial.Text);
        else _Ini = 1;

        if (!string.IsNullOrEmpty(txtFinal.Text)) _Fin = Convert.ToInt32(txtFinal.Text);
        else _Fin = 99999999;

        if (_Ini > _Fin)
        {
            this.msg = "O código inicial não pode ser maior que o código final";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem", "alert('" + msg + "'); ", true);
            return false;
        }
        else if (txtInicial.Text != "" && txtFinal.Text == "")
        {
            this.msg = "Informe o código final";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem", "alert('" + msg + "'); ", true);
            return false;
        }
        else if (txtInicial.Text == "" && txtFinal.Text != "")
        {
            this.msg = "Informe o código inicial";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "Mensagem", "alert('" + msg + "'); ", true);
            return false;
        }
        else return true;
    }

    // Seleciona item na GRID
    protected void gvCadastro_SelectedIndexChanged(object sender, EventArgs e)
    {
        var grid = ((GridView)sender);
        int index = grid.SelectedRow.RowIndex;

        if (index >= 0)
        {
            hCodigo.Value = gvCadastro.Rows[index].Cells[1].Text;
            txtCodigo.Text = hCodigo.Value;

            txtNome.Text = gvCadastro.Rows[index].Cells[2].Text.ToUpper().Trim();

            if (gvCadastro.Rows[index].Cells[3].Text != "&nbsp;") txtFone.Text = gvCadastro.Rows[index].Cells[3].Text;
            else txtFone.Text = "";



            if (gvCadastro.Rows[index].Cells[4].Text != "&nbsp;") txtEmail.Text = gvCadastro.Rows[index].Cells[4].Text.ToLower();
            else txtEmail.Text = "";
        }

        mostrarPainel(false, true, true);
        habilitarBtn(false, true, true, false, false);
        habilitarCad(false, false, false);

    }

    #endregion

}