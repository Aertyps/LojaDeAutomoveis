using System;
using System.Linq;
using System.IO;
using System.Text;

//...............................................................Classe Carro
class Carro:Veiculo{

  private int qtdPortas;
  private bool carroceria;
  private int codigo;
  
  public Carro(int qtd,bool crr,int cd){

    //Veiculo veiculo = new Veiculo();
    //veiculo = v;
    SetQtdPortas(qtd);
    SetCarroceria(crr);
    SetCodigo(cd);

  }

  public Carro(){

  }

  public int GetQtdPortas(){
    return qtdPortas;
  }

  public void SetQtdPortas(int p){

    int porta = p;

    if(porta >= 2){
        qtdPortas= porta;
    }else{
       Console.WriteLine ("quantidade de portas invalida!!!");
    }
    
  }
  public int GetCodigo(){
    return codigo;
  }

  public void SetCodigo(int c){
    
    int cod = c;

    if(cod > 0){
        codigo = cod;
    }else{
       Console.WriteLine ("codigo invalido!!!");
    }
    
  }
  public bool GetCarroceria(){
    return carroceria;
  }

  public void SetCarroceria(bool c){
    carroceria = c;
  }

}