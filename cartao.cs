using System;
using System.Linq;
using System.IO;
using System.Text;

class Cartao:Pagamento
{
  private string tipoCartao;
  private int parcelas;
  private string numCartao;

  public Cartao(Pagamento pgto, string tpcartao, int parc, string ncart)
  {
    Pagamento pagamento = new Pagamento();
    pagamento = pgto;
    SetTipoCartao(tpcartao);
    SetParcelas(parc);
    SetNumCartao(ncart);
  }
  public Cartao()
  {

  }

  public string GetTipoCartao()
  {
    return tipoCartao;
  }

  public void SetTipoCartao(string tp)
  {
    tipoCartao = tp;
  }

  public int GetParcelas()
  {
    return parcelas;
  }

  public void SetParcelas(int p)
  {
    int parc = p;
    if(parc > 0)
    {
      parcelas=parc;
    }
    else
    {
      Console.WriteLine("numero de parcelas inválidas!");
    }
  }

  public string GetNumCartao()
  {
    return numCartao;
  }

  public void SetNumCartao(string numc)
  {
    string numero = numc;

    if(Convert.ToInt32(numero)>0 && numero.Length == 16)
    {
      numCartao = numero;
    }
    else
    {
      Console.WriteLine("numero de cartão inválido, obs.: 16 numeros");
    }
  }

}
