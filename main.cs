using System;
using System.Linq;

//...............................................................Classe Pessoa

class Pessoa{
 private string nome;
 private string cpf;
 private DateTime dataNascimento;
 private int telefone;
 private string login;
 private string senha;

 public string GetLogin(){
   return login;
 }

 public void SetLogin(string l){
   string valor = l;
   if(valor.Length > 4){//login maior que 4 digitos
     login = l;
    }
 
 }
 
public string GetSenha(){
   return senha;
 }

 public void SetSenha(string s){
   string valor = s;
   if(valor.Length == 4){//senha igual a 4 digitos
     senha = s;
    }
 
 }

 public string GetNome(){
   return nome;
 }

 public void SetNome(string n){

   if(VerificaPalavra(n)){
     nome = n;
    }
 
 }
 
  public string GetCpf(){
   return cpf;
 }

 public void SetCpf(string c){

   if(VerificarCpf(c)){
      cpf = c;
   }
   
 }

 public DateTime GetDataNascimento(){
   return dataNascimento;
 }
 
 public void SetDataNascimento(string ano,string dia,string mes){

  if(VerificaData(ano,4)){

    if(VerificaData(dia,2)){

      if(VerificaData(mes,2)){

          dataNascimento = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
      }
   
    }
    
  }
   
 }

public int GetTelefone(){
  return telefone;
}

public void SetTelefone(string t){
  if(VerificaTelefone(t)){
    telefone = Convert.ToInt32(t);
  }
 
}

public static bool VerificaData(string data,int tam){

  string valor = data;

    if( valor.Length == tam && valor.All(char.IsDigit)){//verifica se tem so numero

      return true;

    }else{

      return false;
    }

}

public static bool VerificaPalavra(string letra){

  string valor = letra;

    if( valor.Length != 0 && valor.All(char.IsLetter)){//verifica se tem so letra

      return true;

    }else{

      return false;
    }

}

public static bool VerificaTelefone(string tel){

  string valor = tel;

    if( valor.Length == 9 && valor.All(char.IsDigit)){//verifica se tem so numero

      return true;

    }else{

      return false;
    }

}

public int GetIdade(){

    return CalcularIdade(dataNascimento);
}

public static int CalcularIdade(DateTime ano){

    int anoNasc = ano.Year;// pego o ano do nascimento
    DateTime data = DateTime.Now;//pego a data agora
    return (data.Year - anoNasc);//subtraio o ano de agora pelo nascimento
}

public static bool VerificarCpf(string cpFentrada) {
    string entrada = cpFentrada;
    int[] cpf = new int[11];
    int[] digto1 = new int[10];
    int ind = 10,soma = 0,digVerif1 = 0;
  
    if(entrada.Length == 11)
    {
      for(int i = 0;i < 11; i++)
      {
       cpf[i] = (int)char.GetNumericValue(entrada[i]);
      
      }

      for(int i2 = 0;i2 < 9; i2++)
      {
       digto1[i2] = cpf[i2]*ind;
       ind--;
       soma += digto1[i2];
      }

      Console.WriteLine ("A soma do primeiro digito deu "+soma);
      digVerif1 = (soma -((soma/11)*11));

      if(digVerif1 >= 2){
        digVerif1 = (11 - digVerif1);
      }else{
        digVerif1 = 0;
      }
    
     if(cpf[9] == digVerif1)
     {

        Console.WriteLine ("O primeiro digito verificador é "+digVerif1+" confere!");

        ind = 11;
        soma = 0;
        for(int i3 = 0;i3 < 10; i3++)
        {
        digto1[i3] = cpf[i3]*ind;
        ind--;
        soma += digto1[i3];
        }

        Console.WriteLine ("\nA soma do segundo digito deu "+soma);
        digVerif1 = (soma -((soma/11)*11));

        if(digVerif1 >= 2){
          digVerif1 = (11 - digVerif1);
        }else{
          digVerif1 = 0;
        }

       if(cpf[10] == digVerif1)
        {
         Console.WriteLine ("O segundo digito verificador é "+digVerif1+" esta correto!");
         return true;

        }else{
          Console.WriteLine ("O segundo digito verificador é "+cpf[10]+" esta incorreto!");
          Console.WriteLine ("deveria ser "+digVerif1);
          return false;
        }

     }else{
        Console.WriteLine ("O primeiro digito verificador é "+cpf[9]+" esta incorreto!");
        Console.WriteLine ("deveria ser "+digVerif1);
        return false;
     }

    }else{
      Console.WriteLine ("numero de digitos do cpf incorreto");
       return false;
    }
  
  }

}
//...............................................................Classe Funcionario
class Funcionario:Pessoa{
  protected string departamento;
  protected DateTime dataAdmissao;
  private DateTime horarioEntrada;
  private DateTime horarioSaida;

  public void SetDepartamento(string d){

    string entrada = d;

    if(entrada.Length > 4)//maior que 4 digitos
    {
      departamento = d;
    }else{
      Console.WriteLine ("departamento invalido!!!");
    }
  }

  public string SetDepartamento(){

    return departamento;
  }

  public void SetDataAdmissao(string ano,string dia,string mes){

      if(VerificaData(ano,4)){//...................................funcao statica de Pessoa

        if(VerificaData(dia,2)){

            if(VerificaData(mes,2)){

                dataAdmissao = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
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
  public DateTime GetDataAdmissao(){
    return dataAdmissao;
  }

  public void SetHorarioEntrada(string h,string m){

    string hora = h;
    string minutos = m;
    DateTime data = DateTime.Now;

    if(VerificaData(hora,2)){//dois digitos hora

      if(VerificaData(minutos,2)){//dois digitos minuto

       horarioEntrada = new DateTime(data.Year, data.Day,data.Month, Convert.ToInt32(hora), Convert.ToInt32(minutos), 0);

      }else{

           Console.WriteLine ("minutos invalidos!!!");

      }

    }else{
       Console.WriteLine ("hora invalida!!!");
    }
    
  }

  public DateTime GetHorarioEntrada(){
    return horarioEntrada;
  }

  public void SetHorarioSaida(string h,string m){

    string hora = h;
    string minutos = m;
    DateTime data = DateTime.Now;

    if(VerificaData(hora,2)){//dois digitos hora

      if(VerificaData(minutos,2)){//dois digitos minuto

       horarioSaida = new DateTime(data.Year, data.Day,data.Month, Convert.ToInt32(hora), Convert.ToInt32(minutos), 0);

      }else{

           Console.WriteLine ("minutos invalidos!!!");

      }

    }else{
       Console.WriteLine ("hora invalida!!!");
    }

  }

  public DateTime GetHorarioSaida(){
    return horarioSaida;
  }

  public int GetTempodeCasa(){
 
    return CalcularIdade(dataAdmissao);
  }

}
//...............................................................Classe Cliente
class Cliente:Pessoa{
  private int comprasRealizadas;
  private double valorTotalCompras;

  public void SetComprasRealizadas(int nc){

    int novaCompra = nc;

    if(novaCompra > comprasRealizadas){

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

    int valorTotal = vt;

    if(valorTotal > 0){

      valorTotalCompras += valorTotal;
    }
    
  }

}
//...............................................................Classe Veiculo
class Veiculo{

}
//...............................................................Classe Carro
class Carro:Veiculo{

}
//...............................................................Classe moto
class Moto:Veiculo{

}
//...............................................................Classe Troca
class Troca{

}

class MainClass {
  public static void Main (string[] args) {
    
    Console.WriteLine ("Tudo ok continue!!!");
   
   // Pessoa.VerificarCpf(Console.ReadLine());//teste cpf
  // if(Pessoa.VerificaTelefone(Console.ReadLine())){  Console.WriteLine ("Hello World");}
  // if(Pessoa.VerificaPalavra(Console.ReadLine())){  Console.WriteLine ("OK!!!");}
 // Pessoa p = new Pessoa();  
 // p.SetDataNascimento(Console.ReadLine(),Console.ReadLine(),Console.ReadLine());
 // Console.WriteLine (p.GetDataNascimento()+"OK!!!");
 //Funcionario f = new Funcionario(); 
 //f.SetHorarioEntrada(Console.ReadLine(),Console.ReadLine());
 //f.SetHorarioSaida(Console.ReadLine(),Console.ReadLine());


 }

}