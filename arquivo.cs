using System;
using System.Linq;
using System.IO;
using System.Text;

class Arquivo{

   public static Cliente LeituraCliente(string arquivo,Cliente c){//arquivo-->dados.txt

    Cliente cliente = new Cliente();
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    string palavras ="";
    string ano ="";
    string dia ="";
   

    while(!sr.EndOfStream){
      string str = sr.ReadLine();
    
      for(int i2 = 0;i2<str.Length; i2++)
      {
       
       if(str[i2] ==' '){
         //Console.WriteLine(palavras);///dados
          i++;

          if(i == 1){
           cliente.SetNome(palavras);

          }else if(i == 2){

            cliente.SetCpf(palavras);

          }else if(i == 3){

            ano = palavras;

          }else if(i == 4){
            
            dia = palavras;
          }else if(i == 5){

            cliente.SetDataNascimento(ano,dia,palavras);
          }else if(i == 6){

            cliente.SetTelefone(palavras);
          }else if(i == 7){

            cliente.SetLogin(palavras);
          }else if(i == 8){

            cliente.SetSenha(palavras);
          }else if(i == 9){

            cliente.SetComprasRealizadas(Convert.ToInt32(palavras));
          }

          palavras = "";

       }else{

          if(str[i2] =='-'){

            palavras +=' ';

          }else{

             palavras +=str[i2];
          }
         
       }
      
      }
      //Console.WriteLine(palavras);//ultimo dado
      cliente.SetValorTotalCompras(Convert.ToSingle(palavras));
    }
    //Console.WriteLine(i);
    sr.Close();
    meuArq.Close();

    return cliente;
  }

  public static int BuscarPessoa(string arquivo,string l){//faz a busca
  
    string login = l;
  
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    int coluna = 0;
    string palavras ="";

    while(!sr.EndOfStream){
      coluna++;
      string str = sr.ReadLine();
      i = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {
       
       if(str[i2] ==' '){
          i++;
          if(i == 7){
           if(login == palavras){
                return coluna;
            }  
         }

          palavras="";

       }else{
         palavras+=str[i2];
       }  

      }

    }
    return 0;
  }
  

public static Pessoa BuscarPessoa(string arquivo,Pessoa p,int col){//arquivo-->dados.txt
   
    string arq = arquivo;
    Pessoa pessoa = new Pessoa();
    FileStream meuArq = new FileStream(arq, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    int coluna1 = 0;
    int coluna = col;
    string palavras ="";
    string ano ="";
    string dia ="";
    //string mes ="";
    
    while(!sr.EndOfStream){

      coluna1++;
      string str = sr.ReadLine();

      if(coluna == coluna1){

        for(int i2 = 0;i2<str.Length; i2++)
        {
        
            if(str[i2] ==' '){
              i++;

            if(i == 1){
              pessoa.SetNome(palavras);

            }else if(i == 2){

              pessoa.SetCpf(palavras);

            }else if(i == 3){

              ano = palavras;

            }else if(i == 4){
              
              dia = palavras;

            }else if(i == 5){

              pessoa.SetDataNascimento(ano,dia,palavras);

            }else if(i == 6){

              pessoa.SetTelefone(palavras);

            }else if(i == 7){

              pessoa.SetLogin(palavras);

            }else if(i == 8){

              pessoa.SetSenha(palavras);

            }

            palavras = "";

        }else{

            if(str[i2] =='-'){

              palavras +=' ';

            }else{

              palavras +=str[i2];
            }
          
        }
        
        }
        //ultimo dado
        pessoa.SetAcesso(palavras);
      }
    
    }
    sr.Close();
    meuArq.Close();

    return pessoa;
  }

   public static Cliente BuscarCliente(string arquivo,Cliente c,int col){//arquivo-->dados.txt
   
    string arq = arquivo;
    Cliente cliente = new Cliente();
    FileStream meuArq = new FileStream(arq, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    int coluna1 = 0;
    int coluna = col;
    string palavras ="";
    string ano ="";
    string dia ="";
    //string mes ="";
    
    while(!sr.EndOfStream){

      coluna1++;
      string str = sr.ReadLine();

      if(coluna == coluna1){

        for(int i2 = 0;i2<str.Length; i2++)
        {
        
            if(str[i2] ==' '){
              i++;

            if(i == 1){
              cliente.SetNome(palavras);

            }else if(i == 2){

              cliente.SetCpf(palavras);

            }else if(i == 3){

              ano = palavras;

            }else if(i == 4){
              
              dia = palavras;

            }else if(i == 5){

              cliente.SetDataNascimento(ano,dia,palavras);

            }else if(i == 6){

              cliente.SetTelefone(palavras);

            }else if(i == 7){

              cliente.SetLogin(palavras);

            }else if(i == 8){

              cliente.SetSenha(palavras);

            }else if(i == 9){

              cliente.SetComprasRealizadas(Convert.ToInt32(palavras));
            }

            palavras = "";

        }else{

            if(str[i2] =='-'){

              palavras +=' ';

            }else{

              palavras +=str[i2];
            }
          
        }
        
        }
        //Console.WriteLine(palavras);//ultimo dado
        cliente.SetValorTotalCompras(Convert.ToSingle(palavras));
      }
    
    }
    sr.Close();
    meuArq.Close();

    return cliente;
  }

 public static void Cadastro(string arquivo,Pessoa p){//arquivo = "dados.txt"
    
    Pessoa pessoa = new Pessoa();
    string str ="";
    string mes ="";
    string dia ="";
    pessoa = p;
    string ano = ""+pessoa.GetDataNascimento().Year;

    if(pessoa.GetDataNascimento().Day < 10){//corrigir um erro na escrita

       dia = "0"+pessoa.GetDataNascimento().Day;

    }else{

       dia = ""+pessoa.GetDataNascimento().Day;
    }

    if(pessoa.GetDataNascimento().Month < 10){//corrigir um erro na escrita

       mes = "0"+pessoa.GetDataNascimento().Month;

    }else{
      
       mes = ""+pessoa.GetDataNascimento().Month;
    }

    string nom = pessoa.GetNome();
    string nom2 = "";

    str = ConteudoDeArquivo(arquivo);//pego os dados do pessoa.txt,para nao apaga os dados existentes

    for(int i = 0;i < nom.Length ; i++)//reorganizando nome,coloco traço no lugar dos espacos pra facilitar leitura
      { 

          if(nom[i] == ' '){

            nom2 +='-';

          }else{

            nom2 +=nom[i];

          }
        
      }

    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);

    StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
   
    str += ""+nom2+" "+pessoa.GetCpf()+" "+ano+" "+dia+" "+mes+" "+pessoa.GetTelefone()+" "+pessoa.GetLogin()+" "+pessoa.GetSenha()+" "+0;
   

    sw.WriteLine(str);
    
    sw.Close();
    meuArq.Close();
 }

public static string ConteudoDeArquivo(string arquivo)
  {
      StreamReader streamReader = new StreamReader(arquivo);
      string text = streamReader.ReadToEnd();
      streamReader.Close();
      return text;
  }

  public static string VeiculoAVenda(string arquivo,int tipo2){//arquivo-->dados.txt
   
    int tipo = tipo2; 
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
    int espaco = 0;
    string  veiculos = "";

    if(tipo == 0){

      veiculos ="(1) Nome  \n(2) Tipo  \n(3) Ano de Fabricacao \n(4) Placa \n(5) Cor \n(6) Marca \n(7) Motor \n(8) Combustivel\n(9) Portas \n(10)Carroceria \n(11)Valor \n(12)Codigo\n\n";

    }else if(tipo == 1){

      veiculos ="(1) Nome  \n(2) Tipo  \n(3) Ano de Fabricacao \n(4) Placa \n(5) Cor \n(6) Marca \n(7) Motor \n(8) Combustivel\n(9)  Valor \n(10) Codigo\n\n";
    }
    
    veiculos+="\n..................................................................................................................\n";
    
    while(!sr.EndOfStream){
      string str = sr.ReadLine();
      string palavras ="";
      espaco = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {

        if(str[i2] ==' '){

          espaco++;
          veiculos +="("+espaco+")"+palavras+"  ";
          palavras="";

       }else{
         palavras+=str[i2];
       }  

      }
      veiculos +="("+(espaco + 1)+")"+palavras+"  ";
      veiculos+="\n..................................................................................................................\n";
    }      
    sr.Close();
    meuArq.Close();
    
    return veiculos;
  }

  public static int[] ItensColuna(string arquivo,int c){//arquivo-->dados.txt
   
    int coluna = c; 
    int[] vetor = new int[NumeroLinhas(arquivo)];
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
    int espaco = 0;
   // string  veiculos = "";
    int i = 0;

    while(!sr.EndOfStream){
      string str = sr.ReadLine();
      string palavras ="";
      espaco = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {

        if(str[i2] ==' '){
          espaco++;
          if(coluna == espaco){
             vetor[i] = Convert.ToInt32(palavras);
          }
          palavras="";

       }else{
         palavras+=str[i2];
       }  

      }
      espaco++;
      if(coluna == espaco){
             vetor[i] = Convert.ToInt32(palavras);
          }
      i++;
     
    }      
    sr.Close();
    meuArq.Close();
    
    return vetor;
  }

  public static int NumeroLinhas(string arquivo){//arquivo-->dados.txt
   
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
    int linhas = 0;
   
    while(!sr.EndOfStream){
      string str = sr.ReadLine();
      linhas++;
    }

    sr.Close();
    meuArq.Close();
    
    return linhas;
  }

  public static string ListarPedidos(){
    
    FileStream meuArq = new FileStream("pedidos.txt", FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);
    int espaco = 0;
    string  pedido = "";

    pedido ="(1) Numero do Pedido  \n(2) Cpf  \n(3) Quantidade \n(4) Data  \n(5) Codigo do veiculo \n(6) Valor Total";
    
    
    pedido+="\n..................................................................................................................\n";
    
    while(!sr.EndOfStream){
      string str = sr.ReadLine();
      string palavras ="";
      espaco = 0;

      for(int i2 = 0;i2<str.Length; i2++)
      {

        if(str[i2] ==' '){

          espaco++;
          pedido +="("+espaco+")"+palavras+"  ";
          palavras="";

       }else{
         palavras+=str[i2];
       }  

      }
      pedido +="("+(espaco + 1)+")"+palavras+"  ";
      pedido+="\n..................................................................................................................\n";
    }      
    sr.Close();
    meuArq.Close();
    
    return pedido;
  }

  public static void CadastrarVeiculo(string arquivo,Carro c){//cadastro de veiculo
    
    Carro carro = new Carro();
    string str ="";
    carro = c;
    string ano = ""+carro.GetDataFabricacao().Year;
    int carroceria = Convert.ToInt32(carro.GetCarroceria());

    str = ConteudoDeArquivo(arquivo);//pego os dados do carro.txt,para nao apaga os dados existentes

    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);

    StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
   
    str += ""+carro.GetNome()+" "+carro.GetTipo()+" "+ano+" "+carro.GetPlaca()+" "+carro.GetCor()+" "+carro.GetMarca()+" "+carro.GetMotor()+" "+carro.GetCombustivel()+" "+carro.GetQtdPortas()+" "+carroceria+" "+carro.GetValor()+" "+carro.GetCodigo();
   

    sw.WriteLine(str);
    
    sw.Close();
    meuArq.Close();
 }

  public static void CadastrarMoto(string arquivo,Moto c){//cadastro moto
    
    Moto moto = new Moto();
    string str ="";
    moto = c;
    string ano = ""+moto.GetDataFabricacao().Year;
    

    str = ConteudoDeArquivo(arquivo);//pego os dados do moto.txt,para nao apaga os dados existentes

    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);

    StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
   
    str += ""+moto.GetNome()+" "+moto.GetTipo()+" "+ano+" "+moto.GetPlaca()+" "+moto.GetCor()+" "+moto.GetMarca()+" "+moto.GetMotor()+" "+moto.GetCombustivel()+" "+moto.GetValor()+" "+moto.GetCodigo();
   

    sw.WriteLine(str);
    
    sw.Close();
    meuArq.Close();
 }

 public static void CadastrarCartao( string arquivo Cartao card)
 {
  Cartao cartao = new Cartao();
  string str = "";
  cartao = card;
  string ano = ""+cartao.GetDataPagamento().Year;
  string mes ="";
  string dia ="";

  if(cartao.GetDataPagamento().Day < 10)
  {
    dia = "0"+cartao.GetDataPagamento().Day;
  }
  else
  {
    dia = ""+cartao.GetDataPagamento().Day;
  }
  if(cartao.GetDataPagamento().Month < 10)
   {
    mes = "0"+cartao.GetDataPagamento().Month;

   }
  else
  {  
    mes = ""+cartao.GetDataPagamento().Month;
  }

  str = ConteudoDeArquivo(arquivo);
  FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);
  StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);

  str+= "NF:"+cartao.GetNotaFiscal()+" ValorTotal:R$"+cartao.GetValorTotal()+"Cartao:"+cartao.GetTipoCartao()+" - Parcelas:"+cartao.GetParcelas()+" - Número do cartão:"+cartao.GetNumCartao();

  sw.WriteLine(str);  
  sw.Close();
  meuArq.Close();
 }

}