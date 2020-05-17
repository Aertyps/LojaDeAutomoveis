using System;
using System.Linq;
using System.IO;
using System.Text;

//...............................................................Classe moto
class Moto:Veiculo{

  private string tipoDeTanque;
  private string modelo;
  private int codigo;

  public Moto(Veiculo v,int cd,string tq, string md){

    Veiculo veiculo = new Veiculo();
    veiculo = v;
    SetCodigo(cd);
    SetTipoDeTanque(tq);
    SetModelo(md);

  }

  public Moto(){

  }

  public string GetTipoDeTanque(){
    return tipoDeTanque;
  }

  public bool SetTipoDeTanque(string t){

    string tanque = t;

    if(tanque.Length >= 2){
        tipoDeTanque = tanque;
        return true;
    }else{
       Console.WriteLine ("Tanque invalido!!!");
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

  public string GetModelo(){
    return modelo;
  }

  public bool SetModelo(string m){

    string md = m;

    if(md.Length >= 2){

        modelo = md;
        return true;

    }else{

       Console.WriteLine ("modelo invalido!!!");
       return false;
    }
   
  }
}