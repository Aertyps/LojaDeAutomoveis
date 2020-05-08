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

 public Pessoa(){//parametros a definir

 }

 public string GetLogin(){
   return login;
 }

 public void SetLogin(string l){
   string valor = l;
   if(valor.Length > 4){//login maior que 4 digitos
     login = l;
    }else{
       Console.WriteLine ("Login invalido,quantidade de caracteres menor que  4 !!!");
    }
 
 }
 
public string GetSenha(){
   return senha;
 }

 public void SetSenha(string s){

   string valor = s;

   if(valor.Length == 4){//senha igual a 4 digitos

      senha = s;

    }else{

       Console.WriteLine ("senha invalida!!!");
    }
 
 }

 public string GetNome(){
   return nome;
 }

 public void SetNome(string n){

   if(VerificaPalavra(n)){
     nome = n;
    }else{
       Console.WriteLine ("Nome invalido!!!");
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
//...............................................................Classe Cliente
class Cliente:Pessoa{
  private int comprasRealizadas;
  private double valorTotalCompras;

   public Cliente(string n,string c,string a,string d,string m,string t,string l,string s,int n2,double v){
    SetNome(n);
    SetCpf(c);
    SetDataNascimento(a,d,m);
    SetTelefone(t);
    SetLogin(l);
    SetSenha(s);
    SetComprasRealizadas(n2);//
    SetValorTotalCompras(v);//manda o valor atual p somar com o antigo
    
  }

  public Cliente(){

  }

  public void SetComprasRealizadas(int nc){

    int novaCompra = nc;

    if(novaCompra > 0){

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

    double valorTotal = vt;

    if(valorTotal > 0){

      valorTotalCompras += valorTotal;
    }else{
       Console.WriteLine ("Valor total invalido!!!");
    }
    
  }

}
//...............................................................Classe Veiculo
class Veiculo{

  private string tipo;
  private DateTime dataFabricacao;
  private string placa;
  private double valor;
  private string cor;
  private string marca;
  private string motor;
  private string combustivel;

  public Veiculo(){

  }

  public string GetTipo(){
  
    return tipo;
  }

  public void SetTipo(string t){

    string entrada = t;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      tipo = entrada;
    }else{
       Console.WriteLine ("tipo invalido!!!");
    }
  }

  public string GetPlaca(){
    return placa;
  }

  public void SetPlaca(string p){

   string entrada = p;

   if(entrada.Length == 7)//maior que 2 digitos)
      {
        placa = entrada;
      }else{
         Console.WriteLine ("placa invalida!!!");
      }
  }

  public void SetDataFabricacao(string ano,string dia,string mes){

      if(Pessoa.VerificaData(ano,4)){//...................................funcao statica de Pessoa

        if(Pessoa.VerificaData(dia,2)){

            if(Pessoa.VerificaData(mes,2)){

                dataFabricacao = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
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

  public DateTime GetDataFabricacao(){
    return dataFabricacao;
  }

  public double GetValor(){
      return valor;
  }

  public void SetValor(double v){

    double valor1 = v;

    if(valor1 > 0){

        valor = v;
    }else{
       Console.WriteLine ("valor invalido!!!");
    }
  }

  public string GetCor(){
    return cor;
  }

  public void SetCor(string c){

    string entrada = c;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      cor = entrada;
    }else{
       Console.WriteLine ("cor invalida!!!");
    }
  }

  public string GetMarca(){
    return marca;
  }

  public void SetMarca(string m){

    string entrada = m;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      marca = m;
    }else{
       Console.WriteLine ("marca invalida!!!");
    }
  }

  public string GetMotor(){
    return motor;
  }

  public void SetMotor(string m){

    string entrada = m;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      motor = entrada;
    }else{
       Console.WriteLine ("motor invalido!!!");
    }
  }

    public string GetCombustivel(){
    return combustivel;
  }

  public void SetCombustivel(string c){

    string entrada = c;

    if(entrada.Length > 2)//maior que 2 digitos
    {
      combustivel = entrada;
    }else{
       Console.WriteLine ("combustivel invalido!!!");
    }
  }

}
//...............................................................Classe Carro
class Carro:Veiculo{

  private int qtdPortas;
  private bool carroceria;
  private int codigo;
  
  public Carro(string t,string a,string d,string ma,string p,double v,string c,string m,string mt,string cb,int qtd,bool crr,int cd){

    SetTipo(t);
    SetDataFabricacao(a,d,m);//ano dia mes
    SetPlaca(p);
    SetValor(v);
    SetCor(c);
    SetMarca(ma);
    SetMotor(mt);
    SetCombustivel(cb);
    SetQtdPortas(qtd);
    SetCarroceria(crr);
    SetCodigo(cd);

  }

  public Carro(){

  }

  public int GetQtdPortas(){
    return qtdPortas;
  }

  public void SetQtdPortas(int p){

    int porta = p;

    if(porta >= 2){
        qtdPortas= porta;
    }else{
       Console.WriteLine ("quantidade de portas invalida!!!");
    }
    
  }
  public int GetCodigo(){
    return codigo;
  }

  public void SetCodigo(int c){
    
    int cod = c;

    if(cod > 0){
        codigo = cod;
    }else{
       Console.WriteLine ("codigo invalido!!!");
    }
    
  }
  public bool GetCarroceria(){
    return carroceria;
  }

  public void SetCarroceria(bool c){
    carroceria = c;
  }

}
//...............................................................Classe moto
class Moto:Veiculo{

  private string tipoDeTanque;
  private string modelo;
  private int codigo;

  public Moto(string t,string a,string d,string ma,string p,double v,string c,string m,string mt,string cb,int cd,string tq, string md){

    SetTipo(t);
    SetDataFabricacao(a,d,m);//ano dia mes
    SetPlaca(p);
    SetValor(v);
    SetCor(c);
    SetMarca(ma);
    SetMotor(mt);
    SetCombustivel(cb);
    SetCodigo(cd);
    SetTipoDeTanque(tq);
    SetModelo(md);

  }

  public Moto(){

  }

  public string GetTipoDeTanque(){
    return tipoDeTanque;
  }

  public void SetTipoDeTanque(string t){

    string tanque = t;

    if(tanque.Length >= 2){
        tipoDeTanque = tanque;
    }else{
       Console.WriteLine ("Tanque invalido!!!");
    }
    
  }

  public int GetCodigo(){
    return codigo;
  }

  public void SetCodigo(int c){
    
    int cod = c;

    if(cod > 0){
        codigo = cod;
    }else{
       Console.WriteLine ("codigo invalido!!!");
    }
    
  }

  public string GetModelo(){
    return modelo;
  }

  public void SetModelo(string m){

    string md = m;

    if(md.Length >= 2){

        modelo = md;

    }else{

       Console.WriteLine ("modelo invalido!!!");
    }
   
  }
}

//...............................................................Classe Pedido
class Pedido:Cliente{

}

//...............................................................Classe Troca
class Troca:Pedido{

  private DateTime dataTroca;
  private string motivo;
  private double diferencaValor;
  
  public Troca(){

  }
  
  public DateTime GetDataTroca(){
    return dataTroca;
  }

  public void SetDataTroca(string ano,string dia,string mes){

      if(VerificaData(ano,4)){//...................................funcao statica de Pessoa

        if(VerificaData(dia,2)){

            if(VerificaData(mes,2)){

                dataTroca = new DateTime(Convert.ToInt32(ano),Convert.ToInt32(mes),Convert.ToInt32(dia));
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

  public string GetMotivo(){
    return motivo;
  }

  public void SetMotivo(string m){

    string motivacao = m;

   if(motivacao.Length > 0){

     motivo = motivacao;

   }else{
     Console.WriteLine ("motivo invalido!!!");
   }
  }

  public double GetDiferenca(){
    return diferencaValor;
  }

  public void SetDiferenca(double d){

    double d2 = d;

    if(d2 > 0){

      diferencaValor = d2;

    }else{

      Console.WriteLine ("diferenca de valor invalida!!!");
      
    }
  }
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
  //Veiculo v = new Veiculo();
  //v.SetDataFabricacao(Console.ReadLine(),Console.ReadLine(),Console.ReadLine());
  //Console.WriteLine (v.GetDataFabricacao()+"OK!!!");

 //Veiculo v = new Veiculo();
 //v.SetPlaca(Console.ReadLine());
 // Console.WriteLine (v.GetPlaca()+"OK!!!");
 }

}