using System;
using System.Linq;
using System.IO;
using System.Text;

//...............................................................Classe Troca
class Troca:Pedido{

  private DateTime dataTroca;
  private string motivo;
  private double diferencaValor;
  
  public Troca(){

  }

  public DateTime GetDataTroca(){
    return dataTroca;
  }

  public void SetDataTroca(string ano,string dia,string mes){

      if(VerificaData(ano,4)){//...................................funcao statica de Pessoa

        if(VerificaData(dia,2)){

            if(VerificaData(mes,2)){

                dataTroca = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
            }else{
                    Console.WriteLine ("data invalida!!!");
                  }
      
        }else{
                Console.WriteLine ("data invalida!!!");
              }
      
    }else{
            Console.WriteLine ("data invalida!!!");
          }
  }

  public string GetMotivo(){
    return motivo;
  }

  public void SetMotivo(string m){

    string motivacao = m;

   if(motivacao.Length > 0){

     motivo = motivacao;

   }else{
     Console.WriteLine ("motivo invalido!!!");
   }
  }

  public double GetDiferenca(){
    return diferencaValor;
  }

  public void SetDiferenca(double d){

    double d2 = d;

    if(d2 > 0){

      diferencaValor = d2;

    }else{

      Console.WriteLine ("diferenca de valor invalida!!!");
      
    }
  }
}