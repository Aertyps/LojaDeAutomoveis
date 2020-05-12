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

  public void SetTipoDeTanque(string t){

    string tanque = t;

    if(tanque.Length >= 2){
        tipoDeTanque = tanque;
    }else{
       Console.WriteLine ("Tanque invalido!!!");
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

  public string GetModelo(){
    return modelo;
  }

  public void SetModelo(string m){

    string md = m;

    if(md.Length >= 2){

        modelo = md;

    }else{

       Console.WriteLine ("modelo invalido!!!");
    }
   
  }
}