using System;
using System.Linq;
using System.IO;
using System.Text;

class Cheque:Pagamento
{
  private DateTime dataVencimento;
  private double limiteCompra;

  public Cheque(Pagamento pgto string ano, string dia, string mes, double lmtcompra)
  {
    Pagamento pgto = new Pagamento();
    pagamento = pgto;
    SetDataVencimento(ano,dia,mes);
    SetLimiteCompra(lmtcompra);
  }

  public Cheque()
  {

  }

  public double GetLimiteCompra()
  {
    return limiteCompra;
  }

  public void SetLimiteCompra(double cred)
  {
    double limitecred = cred;
    if(limitecred > 0)
    {
      limiteCompra = limitecred;
    }
    else
    {
      Console.WriteLine("limite de compra insuficiente!");
    }
  }


  public DateTime GetDataVencimento()
  {
    return dataVencimento;
  } 

  public void SetDataVencimento(string ano,string dia,string mes)
   {
    if(VerificaData(ano,4))   {//...................................funcao statica de Pessoa
      if(VerificaData(dia,2))
      {
        if(VerificaData(mes,2))
        {                
          dataVencimento = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
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

}