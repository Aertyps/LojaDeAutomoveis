using System;
using System.Linq;
using System.IO;
using System.Text;


//...............................................................Classe Cliente
class Cliente:Pessoa{
  private int comprasRealizadas;
  private double valorTotalCompras;

   public Cliente(Pessoa p,int n2,double v){
    Pessoa pessoa = new Pessoa();
    pessoa = p;
    SetComprasRealizadas(n2);//
    SetValorTotalCompras(v);//manda o valor atual p somar com o antigo
    
  }

  public Cliente(){

  }

  public void SetComprasRealizadas(int nc){

    int novaCompra = nc;

    if(novaCompra > 0){

      comprasRealizadas += novaCompra;
    }
    
  }

  public int GetComprasRealizadas(){
    return comprasRealizadas;
  }

  public double GetValorTotalCompras(){
    return valorTotalCompras;
  }

  public void SetValorTotalCompras(double vt){

    double valorTotal = vt;

    if(valorTotal > 0){

      valorTotalCompras += valorTotal;
    }else{
       Console.WriteLine ("Valor total invalido!!!");
    }
    
  }

}