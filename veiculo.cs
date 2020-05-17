using System;
using System.Linq;
using System.IO;
using System.Text;

//...............................................................Classe Veiculo
class Veiculo{

  private string tipo;
  private DateTime dataFabricacao;
  private string placa;
  private double valor;
  private string cor;
  private string marca;
  private string motor;
  private string combustivel;
  private string nome;

  public Veiculo(){

  }

  public string GetTipo(){
  
    return tipo;
  }

  public bool SetTipo(string t){

    string entrada = t;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      tipo = entrada;
      return true;

    }else{
       Console.WriteLine ("tipo invalido!!!");
       return false;
    }
  }

   public string GetNome(){
  
    return nome;
  }

  public bool SetNome(string n){

    string entrada = n;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      nome = entrada;
      return true;
    }else{
       Console.WriteLine ("nome invalido!!!");
       return false;
    }
  }

  public string GetPlaca(){
    return placa;
  }

  public bool SetPlaca(string p){

   string entrada = p;

   if(entrada.Length == 7)//maior que 2 digitos)
      {
        placa = entrada;
        return true;
      }else{
         Console.WriteLine ("placa invalida!!!");
         return false;
      }
  }

  public bool SetDataFabricacao(string ano){

    if(Pessoa.VerificaData(ano,4)){//...................................funcao statica de Pessoa

        dataFabricacao = new DateTime(Convert.ToInt32(ano),10,10);
        return true;
        }else{
            Console.WriteLine ("data invalida!!!");
            return false;
          }
  }

  public DateTime GetDataFabricacao(){
    return dataFabricacao;
  }

  public double GetValor(){
      return valor;
  }

  public bool SetValor(double v){

    double valor1 = v;

    if(valor1 > 0){

        valor = v;
        return true;
    }else{
       Console.WriteLine ("valor invalido!!!");
       return false;
    }
  }

  public string GetCor(){
    return cor;
  }

  public bool SetCor(string c){

    string entrada = c;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      cor = entrada;
      return true;
    }else{
       Console.WriteLine ("cor invalida!!!");
       return false;
    }
  }

  public string GetMarca(){
    return marca;
  }

  public bool SetMarca(string m){

    string entrada = m;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      marca = m;
      return true;
    }else{
       Console.WriteLine ("marca invalida!!!");
       return false;
    }
  }

  public string GetMotor(){
    return motor;
  }

  public bool SetMotor(string m){

    string entrada = m;

    if(entrada.Length > 1)//maior que 2 digitos
    {
      motor = entrada;
      return true;
    }else{
       Console.WriteLine ("motor invalido!!!");
       return false;
    }
  }

    public string GetCombustivel(){
    return combustivel;
  }

  public bool SetCombustivel(string c){

    string entrada = c;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      combustivel = entrada;
      return true;
    }else{
       Console.WriteLine ("combustivel invalido!!!");
       return false;
    }
  }

}