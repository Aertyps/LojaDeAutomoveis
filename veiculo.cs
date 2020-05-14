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

  public void SetTipo(string t){

    string entrada = t;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      tipo = entrada;
    }else{
       Console.WriteLine ("tipo invalido!!!");
    }
  }

   public string GetNome(){
  
    return nome;
  }

  public void SetNome(string n){

    string entrada = n;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      nome = entrada;
    }else{
       Console.WriteLine ("nome invalido!!!");
    }
  }

  public string GetPlaca(){
    return placa;
  }

  public void SetPlaca(string p){

   string entrada = p;

   if(entrada.Length == 7)//maior que 2 digitos)
      {
        placa = entrada;
      }else{
         Console.WriteLine ("placa invalida!!!");
      }
  }

  public void SetDataFabricacao(string ano){

    if(Pessoa.VerificaData(ano,4)){//...................................funcao statica de Pessoa

        dataFabricacao = new DateTime(Convert.ToInt32(ano),10,10);

        }else{
            Console.WriteLine ("data invalida!!!");
          }
  }

  public DateTime GetDataFabricacao(){
    return dataFabricacao;
  }

  public double GetValor(){
      return valor;
  }

  public void SetValor(double v){

    double valor1 = v;

    if(valor1 > 0){

        valor = v;
    }else{
       Console.WriteLine ("valor invalido!!!");
    }
  }

  public string GetCor(){
    return cor;
  }

  public void SetCor(string c){

    string entrada = c;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      cor = entrada;
    }else{
       Console.WriteLine ("cor invalida!!!");
    }
  }

  public string GetMarca(){
    return marca;
  }

  public void SetMarca(string m){

    string entrada = m;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      marca = m;
    }else{
       Console.WriteLine ("marca invalida!!!");
    }
  }

  public string GetMotor(){
    return motor;
  }

  public void SetMotor(string m){

    string entrada = m;

    if(entrada.Length > 1)//maior que 2 digitos
    {
      motor = entrada;
    }else{
       Console.WriteLine ("motor invalido!!!");
    }
  }

    public string GetCombustivel(){
    return combustivel;
  }

  public void SetCombustivel(string c){

    string entrada = c;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      combustivel = entrada;
    }else{
       Console.WriteLine ("combustivel invalido!!!");
    }
  }

}