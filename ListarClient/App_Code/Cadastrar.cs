/// <summary>
/// Descrição resumida de Cadastrar
/// </summary>
public class Cadastro
{
    #region Variáveis

    private int? _Id = null;
    private string _Nome = "";
    private string _Email = "";
    private string _Fone = "";
    public string msg = "";

    #endregion

    #region Get e Set

    public int? Id
    {
        get { return this._Id; }
        set { this._Id = value; }
    }

    public string Nome
    {
        get { return this._Nome; }
        set { this._Nome = value; }
    }

    public string Email
    {
        get { return this._Email; }
        set { this._Email = value; }
    }

    public string Fone
    {
        get { return this._Fone; }
        set { this._Fone = value; }
    }

    #endregion

    #region Construtor

    public Cadastro()
    {
        this._Id = null;
        this._Nome = "";
        this._Email = "";
        this._Fone = "";
    }

    public Cadastro(int? id, string nome, string email, string fone)
    {
        _Id = id;
        _Nome = nome;
        _Email = email;
        _Fone = fone;
    }

    #endregion

}