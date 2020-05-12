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

  public static int BuscarCliente(string arquivo,string l){//faz a busca
    string login = l;
    //Cliente cliente = new Cliente();

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
  

   public static Cliente BuscarCliente(string arquivo,Cliente c,int col){//arquivo-->dados.txt
   
    string arq = arquivo;
    Cliente cliente = new Cliente();
    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(meuArq, Encoding.UTF8);

    int i = 0;
    int coluna1 = 0;
    int coluna = col;
    string palavras ="";
    string ano ="";
    string dia ="";
    string mes ="";
    
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

 public static void Escrita(string arquivo,Cliente c){//arquivo = "dados.txt"
    
    Cliente cliente = new Cliente();
    string str ="";
    string mes ="";
    string dia ="";
    cliente = c;
    string ano = ""+cliente.GetDataNascimento().Year;

    if(cliente.GetDataNascimento().Day < 10){//corrigir um erro na escrita

       dia = "0"+cliente.GetDataNascimento().Day;

    }else{

       dia = ""+cliente.GetDataNascimento().Day;
    }

    if(cliente.GetDataNascimento().Month < 10){//corrigir um erro na escrita

       mes = "0"+cliente.GetDataNascimento().Month;

    }else{
      
       mes = ""+cliente.GetDataNascimento().Month;
    }

    string nom = cliente.GetNome();
    string nom2 = "";

    str = ConteudoDeArquivo(arquivo);//pego os dados do cliente.txt

    for(int i = 0;i < nom.Length ; i++)//reorganizando nome
      { 

          if(nom[i] == ' '){

            nom2 +='-';

          }else{

            nom2 +=nom[i];

          }
        
      }

    FileStream meuArq = new FileStream(arquivo, FileMode.Open, FileAccess.Write);

    StreamWriter sw = new StreamWriter(meuArq, Encoding.UTF8);
   
    str += ""+nom2+" "+cliente.GetCpf()+" "+ano+" "+dia+" "+mes+" "+cliente.GetTelefone()+" "+cliente.GetLogin()+" "+cliente.GetSenha()+" "+0+" "+1;
   

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
    string  veiculos = "";
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

}