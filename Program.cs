
using System;
using System.IO;
using YamlDotNet.Core;

String semilla, snumero2, snumero3;
int tam1, tam2, i, x, diff, numero1, numero2, count, seed, z;
int[] secuencia = new int[100];
do
{
    Console.WriteLine("Escriba semilla: ");
    semilla = Console.ReadLine();
    tam1 = semilla.Length;
} while (tam1 != 4);                              //Se verifica que la semilla sea obligatoriamente de 4 dígitos

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
                count = count + 1;              //Contamos cuantos 0 existen en la cadena de 4 dígitos
            }
        }
        numero1 = int.Parse(snumero3);          //Convertimos a entero la cadena anterior
        if (count >= 2)                         //Si la cadena posee más de dos números 0 entonces
        {
            numero1 = numero1 * seed;           //Se multiplica el número actual por la semilla inicial para evitar degeneración
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

Console.WriteLine("Secuencia de Numero final:"); //Se imprime la secuencia final
for (x = 0; x < 100; x++)
{
    Console.WriteLine(" " + secuencia[x] + " |");
}
