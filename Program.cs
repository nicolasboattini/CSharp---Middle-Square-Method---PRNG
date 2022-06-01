
using System;
using System.IO;
using YamlDotNet.Core;
namespace MetodosAleatorios
{
    class Metodos
    {
        public static void ChiCuadrado(int[] seq, int inf, int sup)
        {
            int limA = inf, limB = sup;
            int x, y=0, z, fi;
            int diff = limB - limA;
            int n = seq.Length;
            int k2 = diff+1;
            double k = diff+1;
            double peii = 1 / k;            
            double enepei = n * peii;
            double gl = k - 1;
            double[] chiObs = new double[k2];
            /*Console.WriteLine("valor de pi " + peii.ToString());
            Console.WriteLine("Longitud de Seq " + n);
            Console.WriteLine("Valor de k " + k);
            Console.WriteLine("valor de npi " + enepei);
            Console.WriteLine("Valor de diff " + diff);
            Console.WriteLine("Grado de libertad " + gl);*/
            double chiobs = 0;

            for (x = limA; x <= limB; x++)
            { 
                fi = 0;
                for (z = 0; z < n; z++)
                {
                    if (seq[z] == x)
                    {
                        fi++;
                    }
                }
                if (y < k)
                {
                    chiObs[y] = (Math.Pow((fi - enepei), 2)) / enepei;                    
                    Console.WriteLine(" | " + x + " | " + fi + " | " + enepei + " | " + (fi - enepei) + " | " + (Math.Pow((fi - enepei), 2)) + " | " + (Math.Pow((fi - enepei), 2)) / enepei + " | ");
                    y++;
                }  
            }
            for (x=0;x<chiObs.Length; x++)
            {
                chiobs += chiObs[x]; 
            }
            Console.WriteLine("");
            Console.WriteLine("Ingrese Chi2 Esperado, según la tabla para " + gl + " grados de libertad y un 10% de margen de error");
            Console.WriteLine("Su respuesta: ");
            double chiEsp = double.Parse(Console.ReadLine());
            bool veri = chiEsp > chiobs;
            Console.WriteLine("");
            Console.WriteLine(chiEsp.ToString("0.###") + " > " + chiobs.ToString("0.###") + " ? : " + veri.ToString());
            if (veri)
            {
                Console.WriteLine("El chi2 calculado es menor al chi2 esperado," +
                    "por ello la hipótesis de que la serie de números dada es equiprobable resulta aceptada ");
            }
            else
            {
                Console.WriteLine("El chi2 calculado es mayor al chi2 esperado, " +
                   "por ello la hipótesis de que la serie de números dada es equiprobable resulta rechazada, " +
                   "debe generar una nueva serie mediante algún método conocido");
            }
            
            
        }
        public static int[] Msm()
        {
            String semilla, snumero2, snumero3;
            int tam1, tam2, i, x, diff, numero1, numero2, count, seed, z;
            int[] secuencia = new int[100];
            do
            {                
                Console.WriteLine("Escriba semilla de 4 dígitos: ");
                semilla = Console.ReadLine();
                tam1 = semilla.Length;
            } while ((tam1 != 4) || (semilla[0] == '0' || (semilla[1] == '0' & semilla[2] == '0') || semilla[3] == '0'));                              //Se verifica que la semilla sea obligatoriamente de 4 dígitos y no contenga 2 o más ceros
            numero1 = int.Parse(semilla);
            seed = numero1;                                  //Almacenamos la semilla como Constante entera para prevenir degeneración
            z = 0;
            for (i = 0; i <= 24; i++)
            {
                numero2 = numero1 * numero1;                 //Elevamos al cuadrado la semilla, o bien el cuadrado medio durante las iteraciones
                snumero2 = numero2.ToString();               //Convertimos el resultado obtenido en string para contar sus dígitos
                do
                {
                    tam2 = snumero2.Length;                 //1 .Contamos la cantidad de dígitos
                    diff = (8 - tam2);                      //Evaluamos la diferencia respecto al número 8
                    if (diff != 0)                          //Si tiene menos de 8 dígitos entonces
                    {
                        for (x = 0; x < diff; x++)
                        {
                            snumero2 = "0" + snumero2;      //Le agregamos los 0 al inicio que sean necesarios hasta llegar a 8 dígitos
                        }
                    }
                    snumero3 = snumero2.Substring(2, 4);    //Extraemos la subcadena de los 4 dígitos centrales que comprende desde los dígitos en la posición 2 hasta la 4
                    count = 0;
                    for (x = 0; x < 4; x++)
                    {
                        if (snumero3[x] == '0')
                        {
                            count++;              //Contamos cuantos 0 existen en la cadena de 4 dígitos
                        }
                    }
                    numero1 = int.Parse(snumero3);          //Convertimos a entero la cadena anterior
                    if (count >= 2)                         //Si la cadena posee más de dos números 0 entonces
                    {
                        numero1 += (seed * seed);           //Se multiplica el número actual por la semilla inicial para evitar degeneración
                        snumero2 = numero1.ToString();      //Se vuelve a convertir en cadena
                    }
                } while (count >= 2);                       //Y se vuelve a enviar al paso 1. para volver a verificar si aún sigue teniendo más de dos números 0 en la cadena.
                
                for (x = 0; x < 4; x++)
                {
                    if (z < 100)
                    {
                        secuencia[z] = (snumero3[x] - '0'); //Se almacena en la secuencia actual los 4 dígitos pseudoaleatorios obtenidos tomados de a 1     
                    }
                    z++;
                }
            }            
            return secuencia;
        }
        
        public static int[] Lcm_Mcm(int j, int n, int o)
        {
            int limA = j;
            int limB = n;
            int mult = o;
            
            int x, a, c, m, p, d, pd, s;
            c = 0;
            bool z, r, v, q, w;                                  
            int[] tempSecuencia = new int[100000];
            int[] secuencia = new int[100];
            p = 10;                                                     //Base del Sistema
            d = 64;                                                     //Bits por palabras
            pd = (p * d) - 1;
            do
            {
                Console.WriteLine("Inserte Valor Válido de m: ");
                m = int.Parse(Console.ReadLine());

            } while (!IsPrime(m) && m <= pd);                         //Verifies that m is prime and < than pd-1

            do
            {
                q = true;
                w = true;
                Console.WriteLine("Inserte Valor Válido de a: ");
                a = int.Parse(Console.ReadLine());
                
                z = ((a % 2) != 0);
                //Verifies that a is impar
                r = ((a % 3) != 0);
                //Verifies that a isn't divisible by 3
                v = ((a % 5) != 0);
                //Verifies that a isn't divisible by 3
                /*if (m % 4 == 0)
                {
                    q = ((a - 1) % 4 == 0);
                    //Verifies (a-1) mod 4 = 0 if 4 is factor of m
                    //Tiene sentido comprobar esto si se supone que m es primo?

                }

                {
                    for (int i = 1; i <= m; i++)
                    {
                        if (m % i == 0 && IsPrime(i))
                        {
                            if (w == true)
                            {
                                w = ((a - 1) % i == 0);
                                //Verifies (a-1) mod b = 0 for each prime factor of m
                                //Verifica para b == 1 y b == m, si m es primo solo posee 2 factores
                                //Para que (a-1) mod b == 0, a = m^
                            }
                        }
                    }
                }*/
            
            } while (!(z && (r || v) && q && w));

            if (mult != 1)
            {
                do
                {
                    v= true;
                    Console.WriteLine("Inserte Valor Válido de c: ");
                    c = int.Parse(Console.ReadLine());
                    q = ((c % 8) == 5);
                    //Verifies c mod 8 = 5
                    w = ((c % 2) != 0);
                    //Verfies c is Impar
                    /*v = RelativelyPrime(c, m);
                    //Verifies c is Relatively Prime to m*/
                } while (!(q && w && v));
            }
            

            do
            {
                Console.WriteLine("Inserte Valor Válido de x: ");
                x = int.Parse(Console.ReadLine());
            } while (x < 0);

            tempSecuencia[0] = x;
            s = 0;

            for (int i = 0; i < 100000; i++)
            {
                tempSecuencia[i + 1] = ((a * tempSecuencia[i] + c) % m); //Implements Xi+1 = (a * Xi + c) mod m
                if (((tempSecuencia[i]>=limA) && (tempSecuencia[i]<=limB)) && s<100)
                {
                    secuencia[s] = tempSecuencia[i];
                    s++;
                    //Stores the number in the final sequence if it is between limA and limB
                } else if (s == 100)
                {
                    i = 99999;
                }
                
            }

            return secuencia;

         }

        public static bool IsPrime(int number) //Comprueba si un número es Primo (extraído de internet)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static int Gcd(int a, int b)     //Método utilizado para comprobar primos relativos (Extraido de internet)
        {
            int t;
            while (b != 0)
            {
                t = a;
                a = b;
                b = t % b;
            }
            return a;
        }

        public static bool RelativelyPrime(int a, int b) //Comprueba si dos números son primos entre sí (Extraído de internet)
        {
            return Gcd(a, b) == 1;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int limA = 0;
            int limB = 50;
            int b;
            Console.WriteLine("1. Método del Cuadrado Medio (MSM)");
            Console.WriteLine("2. Método Congruencial Lineal (Mixto) (LCM)");
            Console.WriteLine("3. Método Congruencial Multiplicativo (MCM)");
            Console.WriteLine("Su eleccion: ");
            int a = int.Parse(Console.ReadLine());
            int[] sequence;
            switch(a){
                case 1:
                    Console.Clear();
                    Console.WriteLine("Método del Cuadrado Medio (MSM)");
                    sequence = Metodos.Msm();
                    Console.Clear();
                    Console.WriteLine("Imprimiendo retorno: ");
                    for (int x = 0; x < sequence.Length; x++)
                    {
                        Console.Write($"  {sequence[x]}");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Aplicando ChiCuadrado a la Secuencia...");
                    Metodos.ChiCuadrado(sequence, 0, 9);
                    break;

                case 2:
                    Console.WriteLine("Desea establecer un rango específico? Por defecto toma numeros enteros de 0 - 50");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    do
                    {
                        Console.WriteLine("Su eleccion: ");
                        b = int.Parse(Console.ReadLine());
                    } while (b < 1 && b > 2);
                    if (b == 1)
                    {
                        Console.WriteLine("Límite inferior: ");
                        limA = int.Parse(Console.ReadLine());
                        do
                        {
                            Console.WriteLine("Límite Superior, debe ser mayor al inferior: ");
                            limB = int.Parse(Console.ReadLine());
                        } while (limB <= limA);
                    }
                    Console.Clear();
                    Console.WriteLine("Método Congruencial Lineal (LCM)");
                    sequence = Metodos.Lcm_Mcm(limA,limB,0);
                    Console.Clear();
                    Console.WriteLine("Imprimiendo retorno: ");
                    for (int x = 0; x < sequence.Length; x++)
                    {
                        Console.Write($"  {sequence[x]}");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Aplicando ChiCuadrado a la Secuencia...");
                    Metodos.ChiCuadrado(sequence, limA, limB);
                    break;

                case 3:
                    Console.WriteLine("Desea establecer un rango específico? Por defecto toma numeros enteros de 0 - 50");
                    Console.WriteLine("1. Si");
                    Console.WriteLine("2. No");
                    do
                    {
                        Console.WriteLine("Su eleccion: ");
                        b = int.Parse(Console.ReadLine());
                    } while (b < 1 && b > 2);
                    if (b == 1)
                    {
                        Console.WriteLine("Límite inferior: ");
                        limA = int.Parse(Console.ReadLine());
                        do
                        {
                            Console.WriteLine("Límite Superior, debe ser mayor al inferior: ");
                            limB = int.Parse(Console.ReadLine());
                        } while (limB <= limA);
                    }                    
                    Console.Clear();
                    Console.WriteLine("Método Congruencial Multiplicativo (MCM)");
                    sequence = Metodos.Lcm_Mcm(limA, limB, 1);
                    Console.Clear();
                    Console.WriteLine("Imprimiendo retorno: ");
                    for (int x = 0; x < sequence.Length; x++)
                    {
                        Console.Write($"  {sequence[x]}");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Aplicando ChiCuadrado a la Secuencia...");
                    Metodos.ChiCuadrado(sequence, limA, limB);
                    break;

            }            
        }
    }

}

