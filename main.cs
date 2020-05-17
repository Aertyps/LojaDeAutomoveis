using System;
using System.Linq;
using System.IO;
using System.Text;

class MainClass {
  public static void Main (string[] args) {
  
  int num = 0;
  bool op = true;
  Pessoa pessoa = new Pessoa();
  Console.Clear();
  Logo();
  Console.WriteLine ("\nFaça seu login ou Registre-se");

 /*para entrar como funcionario tente login fulano senha 1254
 para entrar como cliente faça seu registro ou tente julia 1234*/
   
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
          coluna = Arquivo.BuscarPessoa("pessoa.txt",Console.ReadLine());//Faco a busca do pessoa no arquivo retorna int
          pessoa = Arquivo.BuscarPessoa("pessoa.txt",pessoa,coluna);//preecho com os dados do arquivo retorna pessoa

          if(coluna == 0){
            Console.WriteLine ("\nLogin Incorreto ");
          }
        }
          
        while(confere){
            Console.WriteLine ("Digite sua senha");
            if(Console.ReadLine() == pessoa.GetSenha()){
              confere = false;
            }else{
              Console.WriteLine ("\nSenha Incorreta");
            }
        }
        
        if(pessoa.GetAcesso() == 0){//se a pessoa é cliente

          Cliente cliente = new Cliente(pessoa,0,0.0);//carrego cliente
          Venda(cliente);//vai para funcao cliente

        }else if(pessoa.GetAcesso() == 1){//se a pessoa é funcionario

          Funcionario funcionario = new Funcionario(pessoa);//carrego funcionario
          Loja(funcionario);//vai para funcao loja

        }
        
        op = false;

      }else if(num == 2){

        Cadastro(pessoa);//faz o cadastro da pessoa
        op = false;

      }else if(num == 3){

        op = false;

      }else{
        Console.WriteLine ("Digite um dos valores apresentados!!!\n");
      }

  }

 }

public static void Venda(Cliente c){
  
  int novoPedido = Arquivo.NovoNumeroPedido();
  double valorTotal = 0;
  Cliente cliente = new Cliente();
  cliente = c;
  bool op = true;
  int num = 0;

 Console.Clear();
 Console.WriteLine ("\nBem Vindo de Volta "+cliente.GetNome());
 //Console.WriteLine ("         "+novoPedido);
  while(op){
      Console.WriteLine ("\nQue tipo de Veiculo deseja Comprar Hoje?");
      Console.WriteLine ("\nDigite 1: para comprar Carro");
      Console.WriteLine ("Digite 2: para comprar uma Moto");
      Console.WriteLine ("Digite 0: para sair");
      num = Convert.ToInt32(Console.ReadLine());

      if(num == 1){

        op = VendaCarro(cliente,novoPedido);//caso finalize a venda e quebra esse while
        

      }else if(num == 2){

        op = VendaMoto(cliente,novoPedido);//filme origin
         
      }else if(num == 0){
          op = false;
          Arquivo.LimparArquivo("pedidoTemporario.txt");
      }else{

         Console.WriteLine ("digito invalido, digite 1 ou 2 ");
      }
  }

}

public static bool VendaCarro(Cliente c,int numPed){
  
  int numeroPedido = numPed;
  Console.Clear();//limpa a tela
  Cliente cliente = new Cliente();
  cliente = c;
  Carro carro = new Carro();
  Console.WriteLine ("\n..........Carros a Venda..........\n");
  Console.WriteLine (Arquivo.VeiculoAVenda("carros.txt",0));
  Console.WriteLine ("\nLegenda acima...........................");
  int num = 0;
  bool quebra = true;
  int linhas = Arquivo.NumeroLinhas("carros.txt");
  int[] codigos = new int[linhas];
  codigos = Arquivo.ItensColuna("carros.txt",12);
  int qtd = 0;
  
  while(quebra){


  bool temCodigo = true;

  while(temCodigo){//verifico se digitou um codigo existente
  
    Console.WriteLine ("Digite (0) para sair ou");
    Console.WriteLine ("Digite o codigo do veiculo desejado ");
    
    num = Convert.ToInt32(Console.ReadLine());

     for(int i = 0;i<linhas;i++){

      if(num == codigos[i]){
          
          quebra = false;
          temCodigo = false;
          carro.SetCodigo(num);
        }
      }

      if(num == 0){
        return true;
      }

      if(temCodigo){
        Console.WriteLine ("\ncodigo invalido ");
        
      }

  }

  double valor = Arquivo.BuscarValor("carros.txt",12,carro.GetCodigo());
  Console.WriteLine ("\nO valor unitario do veiculo é R$"+valor);
  Console.WriteLine ("\nInforme a quantidade :");
  qtd = Convert.ToInt32(Console.ReadLine());
  valor = valor*qtd;
  cliente.SetValorTotalCompras(valor);
  Console.WriteLine ("\nO valor total é R$"+valor);
  }

  if(num != 0){
  
     bool op = true;

     while(op){
       
        Console.WriteLine ("\nDeseja comprar outro veiculo :");
        Console.WriteLine ("Digite (1) para Finalizar compra");
        Console.WriteLine ("Digite (0) para continuar compras");
        int num2 = Convert.ToInt32(Console.ReadLine());
        
        string dia ="";
        DateTime data = DateTime.Now;
        if(data.Day <10){
           dia = "0"+data.Day;
        }else{
           dia = ""+data.Day;
        }

        string mes="";

        if(data.Month<10){
          mes ="0"+data.Month;
        }else{
          mes =""+data.Month;
        }
        
        string ano =""+data.Year;
        carro.SetCodigo(num);

        Pedido pedido = new Pedido(ano,dia,mes,numeroPedido,qtd,carro);
        pedido.SetCpf(cliente.GetCpf());
        pedido.SetValorTotalCompras(cliente.GetValorTotalCompras());
       
      
        if(num2 == 1){

            Pagamento();
            
            Arquivo.GerarPedido(pedido,"pedidos.txt");
            Arquivo.LimparArquivo("pedidoTemporario.txt");
             op = false;
             return false;//

        }else if(num2 == 0){
                Arquivo.GerarPedidoReserva(pedido, "pedidoTemporario.txt");
                op = false;

        }else{
             Console.WriteLine ("Opçao invalida");
        }
     }
    
    
  }
  return true;//p voltar a tela de vendas
}

public static bool VendaMoto(Cliente c, int numPed){

  int numeroPedido = numPed;
  Console.Clear();//limpa a tela
  Cliente cliente = new Cliente();
  cliente = c;
  Moto moto = new Moto();
  Console.WriteLine ("\n..........Motos a Venda..........\n");
  Console.WriteLine (Arquivo.VeiculoAVenda("motos.txt",1));
  Console.WriteLine ("\nLegenda acima...........................");
  int num = 0;
  bool quebra = true;
  int linhas = Arquivo.NumeroLinhas("motos.txt");
  int[] codigos = new int[linhas];
  codigos = Arquivo.ItensColuna("motos.txt",10);
  int qtd =0;
  while(quebra){


  bool temCodigo = true;

  while(temCodigo){//verifico se digitou um codigo existente
  
    Console.WriteLine ("Digite (0) para sair ou");
    Console.WriteLine ("Digite o codigo do veiculo desejado ");
    
    num = Convert.ToInt32(Console.ReadLine());

     for(int i = 0;i<linhas;i++){

      if(num == codigos[i]){
          
          quebra = false;
          temCodigo = false;
          moto.SetCodigo(num);
        }
      }

      if(num == 0){
        return true;
      }

      if(temCodigo){
        Console.WriteLine ("\ncodigo invalido ");
        
      }

  }

  double valor = Arquivo.BuscarValor("motos.txt",10,moto.GetCodigo());
  Console.WriteLine ("\nO valor unitario do veiculo é R$"+valor);
  Console.WriteLine ("\nInforme a quantidade :");
  qtd = Convert.ToInt32(Console.ReadLine());
  valor = valor*qtd;
  cliente.SetValorTotalCompras(valor);
  Console.WriteLine ("\nO valor total é R$"+valor);


  }

  if(num != 0){
  
     bool op = true;

     while(op){
        Console.WriteLine ("\nDeseja comprar outro veiculo :");
        Console.WriteLine ("Digite (1) para Finalizar compra");
        Console.WriteLine ("Digite (0) para continuar compras");
        int num2 = Convert.ToInt32(Console.ReadLine());

        string dia ="";
        DateTime data = DateTime.Now;
        if(data.Day <10){
           dia = "0"+data.Day;
        }else{
           dia = ""+data.Day;
        }

        string mes="";

        if(data.Month<10){
          mes ="0"+data.Month;
        }else{
          mes =""+data.Month;
        }
        
        string ano =""+data.Year;
        moto.SetCodigo(num);

        Pedido pedido = new Pedido(ano,dia,mes,numeroPedido,qtd,moto);
        pedido.SetCpf(cliente.GetCpf());
        pedido.SetValorTotalCompras(cliente.GetValorTotalCompras());

        if(num2 == 1){

            Pagamento();
            Arquivo.GerarPedido(pedido,"pedidos.txt");
            Arquivo.LimparArquivo("pedidoTemporario.txt");
            op = false;

            return false;//

        }else if(num2 == 0){

            Arquivo.GerarPedidoReserva(pedido, "pedidoTemporario.txt");
            op = false;

        }else{
             Console.WriteLine ("Opçao invalida");
        }
     }
    
    
  }
  return true;//p voltar a tela de vendas
}

public static void Cadastro(Pessoa p){

  Pessoa pessoa = new Pessoa();
  pessoa = p;

  Console.WriteLine ("\nDigite seu Nome");
        pessoa.SetNome(Console.ReadLine());

        Console.WriteLine ("\nDigite seu Cpf");
        pessoa.SetCpf(Console.ReadLine());

        Console.WriteLine ("Digite sua Data de Nascimento :");
        Console.WriteLine ("\nDigite o dia de nascimento - 2 digitos");
        string dia = Console.ReadLine();
        
        Console.WriteLine ("\nDigite o mes - 2 digitos");
        string mes = Console.ReadLine();

        Console.WriteLine ("\nDigite o ano - 4 digitos");
        string ano = Console.ReadLine();
        pessoa.SetDataNascimento(ano,dia,mes);

        Console.WriteLine ("\nDigite seu Telefone(celular) - sem ddd");
        pessoa.SetTelefone(Console.ReadLine());

        Console.WriteLine ("\nDigite seu Login - maior que 4 digitos");
        pessoa.SetLogin(Console.ReadLine());

        Console.WriteLine ("\nDigite sua Senha - 4 digitos");
        pessoa.SetSenha(Console.ReadLine());

        Arquivo.Cadastro("pessoa.txt",pessoa);//insiro os dados no pessoa.txt
  }

  public static void Pagamento(){
      bool op = true;

      while(op){
        Console.WriteLine ("\nQual sera a forma de pagamento");
        Console.WriteLine ("\nDigite (1) para dinheiro");
        Console.WriteLine ("Digite (2) para cartao");
        Console.WriteLine ("Digite (3) para cheque");

        int num = Convert.ToInt32(Console.ReadLine());

        if(num == 1){

          Console.WriteLine ("\nVenda Finalizada");
          Console.WriteLine ("Obrigado pela preferencia!");
          op = false;

        }else if(num == 2){

          RegistrarCartao();
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

public static void Loja(Funcionario f){

    Funcionario funcionario = new Funcionario();
    funcionario = f;

    if(funcionario.GetNivel() == 0){
      bool op = true;

      while(op){

        Console.WriteLine ("\nDigite a ação desejada");
        Console.WriteLine ("Digite (1) para cadastrar um novo veículo");
        Console.WriteLine ("Digite (2) para verificar os pedidos");
        Console.WriteLine ("Digite (3) para sair");
         int num = Convert.ToInt32(Console.ReadLine());

         if(num == 1){

            CadastroVeiculos();

         }else  if(num == 2){

            VerificarPedidos();

         }else if(num == 3){

          op = false;

         }else{

            Console.WriteLine ("\nDigite novamente!!");
         }
      }

    }else if(funcionario.GetNivel() == 1){

    }

  }

  public static void CadastroVeiculos(){

    bool op = true;
    while(op){

        Console.WriteLine ("\nEscolha o tipo de cadastro");
        Console.WriteLine ("\nDigite (1) para cadastrar um Carro");
        Console.WriteLine ("Digite (2) para cadastra uma Moto");
        Console.WriteLine ("Digite (3) para sair");
        int num = Convert.ToInt32(Console.ReadLine());

        if(num == 1){

          RegistrarCarro();

        }else if(num == 2){

          RegistrarMoto();

        }else if(num == 3){

          op = false;

        }else {
            Console.WriteLine ("\ntipo de cadastro invalido!!");
        }
    }

  }

  public static void VerificarPedidos(){
    
     Console.WriteLine ("\nLista de Pedidos");
     string pedido = Arquivo.ListarPedidos(); //carrego os pedidos  
     Console.WriteLine (pedido);
     
  }

  public static void RegistrarCarro(){

   Carro carro = new Carro();
   Console.WriteLine ("\nInforme o nome do carro");
   carro.SetNome(Console.ReadLine());
   Console.WriteLine ("\nInforme o numero de portas");
   carro.SetQtdPortas(Convert.ToInt32(Console.ReadLine()));
   Console.WriteLine ("\nTem carroceria (s) para sim ou (n) para não?");
   string c = Console.ReadLine();
   
   if(c == "s"){
     carro.SetCarroceria(true);
   }else if(c== "n"){
      carro.SetCarroceria(false);
   }
   
   Console.WriteLine ("\nInforme o codigo");
   carro.SetCodigo(Convert.ToInt32(Console.ReadLine()));

   Console.WriteLine ("\nInforme o tipo de Carro");
   carro.SetTipo(Console.ReadLine());

   Console.WriteLine ("\nInforme o ano de fabricação");
   carro.SetDataFabricacao(Console.ReadLine());

   Console.WriteLine ("\nInforme a placa");
   carro.SetPlaca(Console.ReadLine());

   Console.WriteLine ("\nInforme o valor");
   carro.SetValor(Convert.ToSingle(Console.ReadLine()));

   Console.WriteLine ("\nInforme a cor");
   carro.SetCor(Console.ReadLine());

   Console.WriteLine ("\nInforme a marca");
   carro.SetMarca(Console.ReadLine());

   Console.WriteLine ("\nInforme o motor");
   carro.SetMotor(Console.ReadLine());

   Console.WriteLine ("\nInforme o combustivel");
   carro.SetCombustivel(Console.ReadLine());
  
   Arquivo.CadastrarVeiculo("carros.txt",carro);
   
  } 

  public static void RegistrarMoto(){
   Moto moto = new Moto();
   Console.WriteLine ("\nInforme o nome do moto");
   moto.SetNome(Console.ReadLine());

  Console.WriteLine ("\nInforme o Tipo");
   moto.SetTipo(Console.ReadLine());

   Console.WriteLine ("\nInforme o codigo");
   moto.SetCodigo(Convert.ToInt32(Console.ReadLine()));

   Console.WriteLine ("\nInforme o tipo de tamque da moto");
   moto.SetTipoDeTanque(Console.ReadLine());

   Console.WriteLine ("\nInforme o ano de fabricação");
   moto.SetDataFabricacao(Console.ReadLine());

   Console.WriteLine ("\nInforme a placa");
   moto.SetPlaca(Console.ReadLine());

   Console.WriteLine ("\nInforme o modelo");
   moto.SetModelo(Console.ReadLine());

   Console.WriteLine ("\nInforme o valor");
   moto.SetValor(Convert.ToSingle(Console.ReadLine()));

   Console.WriteLine ("\nInforme a cor");
   moto.SetCor(Console.ReadLine());

   Console.WriteLine ("\nInforme a marca");
   moto.SetMarca(Console.ReadLine());

   Console.WriteLine ("\nInforme o motor");
   moto.SetMotor(Console.ReadLine());

   Console.WriteLine ("\nInforme o combustivel");
   moto.SetCombustivel(Console.ReadLine());
  
   Arquivo.CadastrarMoto("motos.txt",moto);
  }


  public static void RegistrarCartao()
  {
    
   Cartao  card= new Cartao();
   Console.WriteLine ("\nInforme o tipo do carro, ex:visa, mastercard...");
   card.SetTipoCartao(Console.ReadLine());
   Console.WriteLine ("\nInforme o numero de parcelas");
   card.SetParcelas(Convert.ToInt32(Console.ReadLine()));
   Console.WriteLine ("\nInforme o numero do cartão");
   card.SetNumCartao(Console.ReadLine());
  
   Arquivo.CadastrarCartao("cartao.txt",card);
   
  }

public static void Logo(){
      Console.WriteLine(
                                         
                          "\n              ,.       .                                 ,,--.     .                       "+
                          "\n             / |   . . |- ,-. ,-,-. ,-. .  , ,-. . ,-.   |`, | ,-. |  . ,-. ,-.            "+
                          "\n            /~~|-. | | |  | | | | | | | | /  |-' | `-.   |   | | | |  | | | |-'            "+
                          "\n          ,'   `-' `-^ `' `-' ' ' ' `-' `'   `-' ' `-'   `---' ' ' `' ' ' ' `-'            "+
                      "\n                                                                                               "+     
                      "\n     ____________                                                                              "+
                      "\n   .T............T.                                                                            "+
                      "\n   | .----------. |                                                                            "+
                      "\n   | |',' ',' , | |           _......_             .''''''''''.                                "+
                      "\n   | `----------' |        _+'        `+_        .'            '.                              "+
                      "\n  _|.-. _...._ .-.|_     _|.-. _...._ .-.|_     _|.-. _...._ .-.|_        ───────────▀▄        "+
                      "\n (_)`-' __[]__ `-'(_)   (_)`-' __{}__ `-'(_)   (_)`-' __||__ `-'(_)       ──█▄▄▄▄▄███▀▄─▄▄     "+
                      "\n(....__|      |__....) (....__|      |__....) (....__|      |__....)      ▄▀──▀▄─▀▀█▀▀▄▀──▀▄   "+
                      "\n | |    ~~~~~~    | |   | |    ~~~~~~    | |   | |    ~~~~~~    | |       ▀▄▀▀█▀▀████─▀▄──▄▀   "+
                      "\n `-'              `-'   `-'              `-'   `-'              `-'       ──▀▀──────────▀▀"
  );
}
}