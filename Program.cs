
using System;
using System.IO;
using YamlDotNet.Core;
namespace MetodosAleatorios
{
    class Metodos
    {
        public static int[] MSM()
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

            Console.WriteLine("Cantidad de digitos: " + tam1);
            numero1 = int.Parse(semilla);
            seed = numero1;                                  //Almacenamos la semilla como Constante entera para prevenir degeneración
            Console.WriteLine(0 + ". " + semilla);
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

                Console.WriteLine(i + 1 + ". " + snumero3); //Se imprime por pantalla el resultado de la iteración actual
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

        public static int[] LCM()
        {
            int x, a, c, m, p, d, k, pd;
            bool z, r, v, q, w, s;
            int[] secuencia = new int[100];
            p = 2;                                                  //Base del Sistema
            d = 64;                                                 //Bits por palabras
            pd = p ^ (d - 1);
            do
            {
                Console.WriteLine("Inserte Valor Válido de m: ");
                m = int.Parse(Console.ReadLine());

            } while (!IsPrime(m) && m > pd);

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
                if (m % 4 == 0)
                {
                    q = ((a - 1) % 4 == 0);
                    //Verifies (a-1) mod 4 = 0 if 4 is factor of m
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
                            }
                        }
                    }
                }
            
            } while (!(z && (r || v) && q && w));

            do
            {
                Console.WriteLine("Inserte Valor Válido de c: ");
                c = int.Parse(Console.ReadLine());
                q = ((c % 8) == 5);
                //Verifies c mod 8 = 5
                w = ((c % 2) != 0);
                //Verfies c is Impar
                v = RelativelyPrime(c, m);
                //Verifies c is Relatively Prime to m
            } while (q && w && v);

            do
            {
                Console.WriteLine("Inserte Valor Válido de x: ");
                x = int.Parse(Console.ReadLine());
            } while (x < 0);

            secuencia[0] = x;

            for (int i = 0; i < 99; i++)
            {
                secuencia[i + 1] = ((a * secuencia[i] + c) % m);
                //Implements Xi+1 = (a * Xi + c) mod m
            }

            return secuencia;

         }

        public static bool IsPrime(int number)
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

        public static int Gcd(int a, int b)
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

        public static bool RelativelyPrime(int a, int b)
        {
            return Gcd(a, b) == 1;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. MSM");
            Console.WriteLine("2. LCM");
            Console.WriteLine("Su eleccion: ");
            int a = int.Parse(Console.ReadLine());
            int[] sequence;
            switch(a){
                case 1:
                    Console.Clear();
                    sequence = Metodos.MSM();
                    Console.Clear();
                    Console.WriteLine("Imprimiendo retorno: ");
                    for (int x = 0; x < sequence.Length; x++)
                    {
                        Console.Write($"  {sequence[x]}");
                    }
                break;

                case 2:
                    Console.Clear();
                    sequence = Metodos.LCM();
                    Console.Clear();
                    Console.WriteLine("Imprimiendo retorno: ");
                    for (int x = 0; x < sequence.Length; x++)
                    {
                        Console.Write($"  {sequence[x]}");
                    }
                break;

            }            
        }
    }


}

