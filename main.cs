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
  Console.WriteLine ("\n\n....Compre seu veiculo sem sair de casa......");
  Console.WriteLine ("\nFaça seu login ou Registre-se");
   
  while(op){

    Console.WriteLine ("\nDigite 1: para Logar");
    Console.WriteLine ("Digite 2: para se Registrar");
    Console.WriteLine ("Digite 3: para sair");
    num = Convert.ToInt32(Console.ReadLine());

      if(num == 1){
        
        int coluna = 0;
        bool confere = true;

        while(coluna == 0){

          Console.WriteLine ("Digite seu Login");
          coluna = Arquivo.BuscarCliente("cliente.txt",Console.ReadLine());//Faco a busca do cliente no arquivo
          cliente = Arquivo.BuscarCliente("cliente.txt",cliente,coluna);

          if(coluna == 0){
            Console.WriteLine ("\nLogin Incorreto ");
          }

          
          while(confere){
            Console.WriteLine ("Digite sua senha");
            if(Console.ReadLine() == cliente.GetSenha()){
              confere = false;
            }else{
              Console.WriteLine ("\nSenha Incorreta");
            }
          }
        }

        Console.WriteLine ("\nBem Vindo de Volta "+cliente.GetNome());
        Console.WriteLine ("\nQue tipo de Veiculo deseja Comprar Hoje?");
        Console.WriteLine ("\nDigite 1: para comprar Carro");
        Console.WriteLine ("Digite 2: para comprar uma Moto");
        op = false;

      }else if(num == 2){

        Console.WriteLine ("\nDigite seu Nome");
        cliente.SetNome(Console.ReadLine());

        Console.WriteLine ("\nDigite seu Cpf");
        cliente.SetCpf(Console.ReadLine());

        Console.WriteLine ("Digite sua Data de Nascimento :");
        Console.WriteLine ("\nDigite o dia de nascimento - 2 digitos");
        string dia = Console.ReadLine();
        
        Console.WriteLine ("\nDigite o mes - 2 digitos");
        string mes = Console.ReadLine();

        Console.WriteLine ("\nDigite o ano - 4 digitos");
        string ano = Console.ReadLine();
        cliente.SetDataNascimento(ano,dia,mes);

        Console.WriteLine ("\nDigite seu Telefone - sem ddd");
        cliente.SetTelefone(Console.ReadLine());

        Console.WriteLine ("\nDigite seu Login - maior que 4 digitos");
        cliente.SetLogin(Console.ReadLine());

        Console.WriteLine ("\nDigite sua Senha - 4 digitos");
        cliente.SetSenha(Console.ReadLine());

        Arquivo.Escrita("cliente.txt",cliente);//insiro os dados no cliente.txt

      }else if(num == 3){

        op = false;

      }else{
        Console.WriteLine ("Digite um dos valores apresentados!!!\n");
      }
      
    
  }

  

 }


}