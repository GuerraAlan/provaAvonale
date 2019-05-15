using System;
using System.Collections.Generic;
using System.Linq;

namespace Avonale_Lista
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gera uma lista de 100 elementos aleatorios
            Random _rand = new Random();
            List<int> randList = Enumerable.Range(0, 100)
                        .Select(r => _rand.Next(100))
                        .ToList();

            media(randList);

            Console.WriteLine("\n\nLista Original");
            randList.ForEach(elemento => Console.Write(elemento + " "));
            Console.WriteLine("\n\nLista Invertida");
            inverterLista(randList, 0).ForEach(elemento => Console.Write(elemento + " "));
            Console.ReadKey();
        }

        public static void media(List<int> listaMedia)
        {
            List<int> lista = calcularMedia(listaMedia, 0, 0);

            Console.WriteLine("A média é: " + lista[0] + ".\nForam encontrados " + (lista.Count - 1) + " Elementos maiores que a média.");
            lista.RemoveAt(0);
            Console.WriteLine("Os elementos encontrados foram:");
            lista.Sort();
            lista.ForEach(elemento => Console.Write(elemento + "\t"));

        }

        private static List<int> calcularMedia(List<int> lista, int count, int soma)
        {
            int elemento = lista[count];
            soma += elemento;

            if (count == lista.Count - 1)
            {
                return new List<int> { soma / count };
            }
            else
            {
                List<int> maiores = calcularMedia(lista, count + 1, soma);
                if (maiores[0] < elemento)
                {
                    maiores.Add(elemento);
                }
                return maiores;
            }
        }

        public static List<int> inverterLista(List<int> lista, int count)
        {
            if (count == lista.Count - 1)
            {
                return new List<int>() { lista[count] };
            }
            else
            {
                List<int> listaInvertida = inverterLista(lista, count + 1);
                listaInvertida.Add(lista[count]);
                return listaInvertida;
            }
        }

    }
}
