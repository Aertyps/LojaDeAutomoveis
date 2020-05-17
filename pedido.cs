using System;
using System.Linq;
using System.IO;
using System.Text;

//...............................................................Classe Pedido
class Pedido:Cliente{

  private DateTime dataPedido;
  private int numeroPedido;
  private int qtd;
  private int codigo;
//-veicullo: Carro/Moto
  public Pedido(){

  }

  public Pedido(string a,string d,string m,int numero,int qtd,Carro c){
    SetDataPedido( a, d, m);
    SetNumeroPedido(numero);
    SetQtd(qtd);
    Carro carro = new Carro();
    carro = c;
    SetCodigo(carro.GetCodigo());
    
  }

   public Pedido(string a,string d,string m,int numero,int qtd,Moto moto){
    SetDataPedido( a, d, m);
    SetNumeroPedido(numero);
    SetQtd(qtd);
    //Moto moto1 = new Moto();
   // moto1 = moto;
    SetCodigo(moto.GetCodigo());
  }

  public int GetCodigo(){
    return codigo;
  }

  public DateTime GetDataPedido(){
    return dataPedido;
  }

  public int GetNumeroPedido(){
    return numeroPedido;
  }

  public int GetQtd(){
    return qtd;
  }

  public void SetDataPedido(string ano,string dia,string mes){

      if(VerificaData(ano,4)){//...................................funcao statica de Pessoa

        if(VerificaData(dia,2)){

            if(VerificaData(mes,2)){

                dataPedido = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
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

  public void SetQtd(int qt){

    int q = qt;
    if(q > 0){

      qtd = q;

    }else{
      Console.WriteLine ("quantidade invalida!!!");
    }
  }

  public void SetCodigo(int cod){

    int q = cod;
    
    if(q > 0){

      codigo = q;

    }else{
      Console.WriteLine ("codigo invalido!!!");
    }
  }

   public void SetNumeroPedido(int p){

    if(p > 0){

      numeroPedido = p;

    }else{
      Console.WriteLine ("quantidade invalida!!!");
    }
  }
  
}