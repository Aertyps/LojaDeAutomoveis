using System;
using System.Linq;
using System.IO;
using System.Text;

class Dinheiro:Pagamento
{
  private double valorPagamento;

  public Dinheiro(Pagamento pgto, double vlrpgto)
  {
    Pagamento pagamento = new Pagamento();
    pagamento = pgto;
    SetValorPagamento(vlrpgto);
  }

  public Dinheiro()
  {

  }

  public double GetValorPagamento()
  {
    return valorPagamento;
  }

  public void SetValorPagamento(double valor)
  {
    double checkvalor = valor;
    if(checkvalor > 0)
    {
      valorPagamento = checkvalor;
    }
    else
    {
      Console.WriteLine("valor de pagamento inválido!");
    }
  }
}