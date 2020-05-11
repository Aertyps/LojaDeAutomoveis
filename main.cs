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
          cliente = Arquivo.BuscarCliente("cliente.txt",cliente,coluna);//preecho com os dados do arquivo

          if(coluna == 0){
            Console.WriteLine ("\nLogin Incorreto ");
          }
        }
          
        while(confere){
            Console.WriteLine ("Digite sua senha");
            if(Console.ReadLine() == cliente.GetSenha()){
              confere = false;
            }else{
              Console.WriteLine ("\nSenha Incorreta");
            }
        }
        

        Venda(cliente);//vai para funcao cliente
        op = false;

      }else if(num == 2){

        Cadastro(cliente);//faz o cadastro
        op = false;

      }else if(num == 3){

        op = false;

      }else{
        Console.WriteLine ("Digite um dos valores apresentados!!!\n");
      }

  }

 }

public static void Venda(Cliente c){

  Cliente cliente = new Cliente();
  cliente = c;
  bool op = true;
  int num = 0;

 Console.Clear();
 Console.WriteLine ("\nBem Vindo de Volta "+cliente.GetNome());

  while(op){
      Console.WriteLine ("\nQue tipo de Veiculo deseja Comprar Hoje?");
      Console.WriteLine ("\nDigite 1: para comprar Carro");
      Console.WriteLine ("Digite 2: para comprar uma Moto");
      Console.WriteLine ("Digite 0: para sair");
      num = Convert.ToInt32(Console.ReadLine());

      if(num == 1){

        op = VendaCarro(cliente);//caso finalize a venda e quebra esse while
        

      }else if(num == 2){

         VendaMoto(cliente);
         
      }else if(num == 0){

          op = false;
          
      }else{

         Console.WriteLine ("digito invalido, digite 1 ou 2 ");
      }
  }

}

public static bool VendaCarro(Cliente c){
  Console.Clear();//limpa a tela
  Cliente cliente = new Cliente();
  cliente = c;
  Console.WriteLine ("\n..........Carros a Venda..........\n");
  Console.WriteLine (Arquivo.VeiculoAVenda("carros.txt",0));
  Console.WriteLine ("\nLegenda acima...........................");
  int num = 0;
  bool quebra = true;
  int linhas = Arquivo.NumeroLinhas("carros.txt");
  int[] codigos = new int[linhas];
  codigos = Arquivo.ItensColuna("carros.txt",12);

  while(quebra){

  Console.WriteLine ("Digite (0) para sair ou");
  Console.WriteLine ("\nDigite o codigo do veiculo desejado ");
  
  num = Convert.ToInt32(Console.ReadLine());

  for(int i = 0;i<linhas;i++){
    if(num == codigos[i]){
     
      quebra = false;
    }else{
    //   Console.WriteLine (codigos[i]);
     // Console.WriteLine ("\ncodigo invalido ");
    }
  }

  Console.WriteLine ("\nInforme a quantidade :");
  int qtd = Convert.ToInt32(Console.ReadLine());
  }

  if(num != 0){
  
     bool op = true;

     while(op){
        Console.WriteLine ("\nDeseja comprar outro veiculo :");
        Console.WriteLine ("Digite (1) para Finalizar compra");
        Console.WriteLine ("Digite (0) para continuar compras");
        int num2 = Convert.ToInt32(Console.ReadLine());

        if(num2 == 1){

            Pagamento();
             op = false;
             return false;//

        }else if(num2 == 0){

            op = false;

        }else{
             Console.WriteLine ("Opçao invalida");
        }
     }
    
    
  }
  return true;//p voltar a tela de vendas
}

public static void VendaMoto(Cliente c){
  Console.Clear();//limpa a tela
  Cliente cliente = new Cliente();
  cliente = c;
  Console.WriteLine ("\n..........Motos a Venda..........\n");
  Console.WriteLine (Arquivo.VeiculoAVenda("motos.txt",1));
  Console.WriteLine ("\nLegenda acima.........;)");
  Console.WriteLine ("\nDigite o codigo do veiculo desejado ");
  Console.WriteLine ("Digite (0) para sair");
  int num = Convert.ToInt32(Console.ReadLine());

}

public static void Cadastro(Cliente c){

  Cliente cliente = new Cliente();
  cliente = c;

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
  }

  public static void Pagamento(){
      bool op = true;

      while(op){
        Console.WriteLine ("\nInforme o tipo de pagamento");
        Console.WriteLine ("\nDigite (1) para dinheiro");
        Console.WriteLine ("Digite (2) para cartao");
        Console.WriteLine ("Digite (3) para cheque");

        int num = Convert.ToInt32(Console.ReadLine());

        if(num == 1){

          Console.WriteLine ("\nVenda Finalizada");
          Console.WriteLine ("Obrigado pela preferencia!");
          op = false;

        }else if(num == 2){

          Console.WriteLine ("\nDigite o numero de parcelas");
          int parcelas = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine ("\nVenda Finalizada");
          Console.WriteLine ("Obrigado pela preferencia!");
          op = false;

        }else if(num == 3){

          Console.WriteLine ("\nVenda Finalizada");
          Console.WriteLine ("Obrigado pela preferencia!");
          op = false;

        }else{
          Console.WriteLine ("Opçao invalida!!");
        }

      }
      

      
  }

}