using System;
using System.Linq;
using System.IO;
using System.Text;

class MainClass {
  public static void Main (string[] args) {
  
  int num = 0;
  bool op = true;
  Cliente cliente = new Cliente();
  
  Console.WriteLine ("\n..........Loja de Automoveis Online..........");
  Console.WriteLine ("....Compre seu veiculo sem sair de casa......\n");
  Console.WriteLine ("Faça seu login ou Registre-se\n");
   
  while(op){

    Console.WriteLine ("Digite 1: para Logar");
    Console.WriteLine ("Digite 2: para se Registrar");
    num = Convert.ToInt32(Console.ReadLine());

    if((num!= 1 )&&(num!=2)){

      Console.WriteLine ("Digite 1 ou 2 para prosseguir!!!");

    }else{
      if(num == 1){
        Console.WriteLine ("Digite seu Login");
        int coluna = Arquivo.BuscarCliente("cliente.txt",Console.ReadLine());//Faco a busca do cliente no arquivo
        cliente = Arquivo.BuscarCliente("cliente.txt",cliente,coluna);
        Console.WriteLine ("\nBem Vindo de Volta "+cliente.GetNome());
        Console.WriteLine ("\nQue tipo de Veiculo deseja Comprar Hoje?");
        Console.WriteLine ("\nDigite 1: para comprar Carro");
        Console.WriteLine ("Digite 2: para comprar uma Moto");

      }else if(num == 2){

        Console.WriteLine ("\nDigite seu Nome\n");
        cliente.SetNome(Console.ReadLine());

        Console.WriteLine ("Digite seu Cpf\n");
        cliente.SetCpf(Console.ReadLine());

        Console.WriteLine ("Digite sua Data de Nascimento :");
        Console.WriteLine ("Digite o dia de nascimento - 2 digitos\n");
        string dia = Console.ReadLine();
        
        Console.WriteLine ("\nDigite o mes - 2 digitos");
        string mes = Console.ReadLine();

        Console.WriteLine ("\nDigite o ano");
        string ano = Console.ReadLine();
        cliente.SetDataNascimento(ano,dia,mes);

        Console.WriteLine ("\nDigite seu Telefone");
        cliente.SetTelefone(Console.ReadLine());

        Console.WriteLine ("\nDigite seu Login");
        cliente.SetLogin(Console.ReadLine());

        Console.WriteLine ("\nDigite sua Senha - 4 digitos");
        cliente.SetSenha(Console.ReadLine());

        Arquivo.Escrita("cliente.txt",cliente);
      }
      op = false;
    }
  }

  

 }


}