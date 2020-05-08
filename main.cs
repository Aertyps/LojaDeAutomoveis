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
  Arquivo.Leitura("cliente.txt");//sem instanciar
 
 }

}