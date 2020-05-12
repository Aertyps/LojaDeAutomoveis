using System;
using System.Linq;
using System.IO;
using System.Text;

class Pedido:Pagamento
{
  public Pedido(string numped, string ano, string dia, string mes, string qnt, double valunit)
  {
    SetNumeroPedido(numped);
    SetDataPedido(ano,dia,mes);
    SetQnt(qnt);
    SetValUnit(valunit);
  }

  private DateTime dataPagamento;
  private string notaFiscal;
  private string tipoPagamento;
  private double valorTotal;
  //desconto? add desconto no pedido e subtrair do valor total

  public DateTime GetDataPagamento()
  {
    return dataPagamento;
  }

  public void SetDataPagamento(string ano, string dia, string mes)
  //copia de função estática de Pessoa p/ validar dado
  {
    if(Pessoa.VerificaData(ano,4))  
    {
      if(Pessoa.VerificaData(dia,2))
      {
        if(Pessoa.VerificaData(mes,2))
        {
          dataFabricacao = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
        }
        else
        {
          Console.WriteLine ("data invalida!!!");
        }
      }
      else
      {
        Console.WriteLine ("data invalida!!!");
      }      
    }
    else
    {
      Console.WriteLine ("data invalida!!!");
    }
  }

  public string GetNotaFiscal()
  {
    return notaFiscal;
  }

  public void SetNotaFiscal(string nf)
  {
    notaFiscal = nf;
  }

  public double GetValorTotal()
  {
    return valorTotal;
  }

  //public void qnt*valunit 
}