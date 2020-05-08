using System;
using System.Linq;
using System.IO;
using System.Text;

class MainClass {
  public static void Main (string[] args) {
    
  Console.WriteLine ("\n..........Loja de Automoveis Online..........");
  Console.WriteLine ("....Compre seu veiculo sem sair de casa......\n");
  Console.WriteLine ("Faça seu login ou Registre-se\n");
  Console.WriteLine ("Digite 1: para Logar");
  Console.WriteLine ("Digite 2: para se Registrar");
  Console.WriteLine ("Tudo ok!!!, continue....");
  Leitura("cliente.txt");
  Funcionario p = new Funcionario();
 }


 public static void Leitura(string arquivo){//arquivo-->dados.txt
    
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    string palavras ="";

    while(!sr.EndOfStream){
      string str = sr.ReadLine();
    
      for(int i2 = 0;i2<str.Length; i2++)
      {
       
       if(str[i2] ==' '){
         Console.WriteLine(palavras);///dados
          i++;
          palavras = "";
       }else{
          palavras +=str[i2];
       }
      
      }
      Console.WriteLine(palavras);//ultimo dado
      
    }
    Console.WriteLine(i);
    sr.Close();
    meuArq.Close();
  }

 public static void Escrita(string frase,string arquivo){//arquivo = "dados.txt"
   
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);

    StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);

    string str = frase;
    sw.WriteLine(str);
    
    sw.Close();
    meuArq.Close();
 }


}