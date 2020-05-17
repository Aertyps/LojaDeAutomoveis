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

  public bool SetQtdPortas(int p){

    int porta = p;

    if(porta >= 2){
        qtdPortas= porta;
        return true;
    }else{
       Console.WriteLine ("quantidade de portas invalida!!!");
       return false;
    }
    
  }
  public int GetCodigo(){
    return codigo;
  }

  public bool SetCodigo(int c){
    
    int cod = c;

    if(cod > 0){
        codigo = cod;
        return true;
    }else{
       Console.WriteLine ("codigo invalido!!!");
       return false;
    }
    
  }
  public bool GetCarroceria(){
    return carroceria;
  }

  public bool SetCarroceria(bool c){
    carroceria = c;
    return true;
  }

}