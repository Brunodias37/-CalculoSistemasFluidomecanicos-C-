using System;

class Program 
{

    //public static float Q =0.2f;
    //public static float L = 750f;
    //public static float D = 0.4f;
    //public static float k = 0.005f;
    //public static float v = ((float)(1.01*(Math.Pow(10,-6))));
    //public static float g = 9.81f;
    //public static float RE;
    //public static float PI = ((float)Math.PI);
    public static double Q =0.18;
    public static double L = 2.200;
    public static double D = 0.5;
    public static double k = (1.4*(Math.Pow(10,-3)));
    public static double v = (1*(Math.Pow(10,-6)));
    public static double g = 9.81f;
    public static double RE;
    public static double PI = (Math.PI);
    
    public static void Main (string[] args) 
    {
      
      static double CalculoRE()
      {
        return  (4*Q)/(PI*D*v);
      }

      static double Laminar()
      {
        Console.WriteLine("Laminar");
        return  64/RE;
      }

     static double Liso()
      {
       Console.WriteLine("Liso");
        var a = Math.Pow(RE,0.9);
       var calc = 5.62/a;
        var b = -2*Math.Log(calc,10);
        var c = Math.Pow(b,-2);
       Console.Write("f: ");
        return c;
      }

     static double Rugoso()
      {
       Console.WriteLine("Rugoso");
        var a = 3.75*D;
        var calc = k/a;
        var b = -2*Math.Log(calc,10);
        var c = Math.Pow(b,-2);
       Console.Write("f: ");
        return (c);
      }
  
     static double Misto()
      {
       Console.WriteLine("Misto");
        var a = 3.75*D;
        var b = (k/a);
        var c = Math.Pow(RE,0.9);
        var d = 5.62/c;
        var e = b+d;
        var f = -2*Math.Log(e,10);
        var g = Math.Pow(f,-2);  
       Console.Write("f: ");
       return g;
      }

      static double DH(double rest)
      {
        var q = Math.Pow(Q,2);
        var cima = 8*rest*L*q;
        var piquadrado = Math.Pow(PI,2);
        var d_aquinta = Math.Pow(D,5);
        var baixo = piquadrado* d_aquinta * g;
        var result = cima/baixo;
        Console.Write("DH: "); 
        return result;
      }

      static double Intermed(double re)
      {
        var cima = Math.Pow(re,0.9);
        var baixo = D/k;
        var result = cima/baixo;
        
        if(result <= 31){return Liso();}
        else if(result >= 448){return Rugoso();}
        else{return Misto();}
        
      }
  
      static double condicao(double re)
      {
        if(re <= 2500){return Laminar();}
        else if(re >= 4000){Console.Write("Turbulento ");return Intermed(re);}
        else{return 0.0f;}    
      }
      
      RE = CalculoRE();             
       Console.WriteLine(RE);          
      var b = condicao(RE);
      Console.WriteLine(b);  
      var c = DH(b);
      Console.WriteLine(c);      
      
    }
  

  
  
}