using System;
using System.Linq;
using System.IO;
using System.Text;
//...............................................................Classe Funcionario
class Funcionario:Pessoa{
  protected string departamento;
  protected DateTime dataAdmissao;
  private DateTime horarioEntrada;
  private DateTime horarioSaida;

  public Funcionario(string n,string c,string a,string d,string m,string t,string l,string s,string dp,string a2,string d2,string m2, string h1,string s1, string h2,string s2){
    SetNome(n);
    SetCpf(c);
    SetDataNascimento(a,d,m);
    SetTelefone(t);
    SetLogin(l);
    SetSenha(s);
    SetDepartamento(dp);
    SetDataAdmissao(a2,d2,m2);
    SetHorarioEntrada(h1,s1);
    SetHorarioSaida(h2,s2);
  }

  public Funcionario(){

  }

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