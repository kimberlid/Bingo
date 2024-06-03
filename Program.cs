using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //  Sortear as bolas e exibir o número sorteado
        List<int> numerosSorteados = new List<int>();
        Random random = new Random();
        for (int i = 1; i <= 75; i++)
        {
            numerosSorteados.Add(i);
        }

        // Embaralhar os numeros
        for (int i = 0; i < numerosSorteados.Count; i++)
        {
            int j = random.Next(i, numerosSorteados.Count);
            int temp = numerosSorteados[i];
            numerosSorteados[i] = numerosSorteados[j];
            numerosSorteados[j] = temp;
        }

        Console.WriteLine("Numeros sorteados:");
        foreach (int numero in numerosSorteados)
        {
            Console.Write(numero + " ");
        }
        Console.WriteLine();

        // Criação da cartela
        int[,] cartela = new int[5, 5];
        HashSet<int> numerosUsados = new HashSet<int>();

        for (int coluna = 0; coluna < 5; coluna++)
        {
            int min = coluna * 15 + 1;
            int max = min + 14;

            for (int linha = 0; linha < 5; linha++)
            {
                if (coluna == 2 && linha == 2) 
                {
                    cartela[linha, coluna] = 0;
                    continue;
                }

                int numero;
                do
                {
                    numero = random.Next(min, max + 1);
                } while (numerosUsados.Contains(numero));

                numerosUsados.Add(numero);
                cartela[linha, coluna] = numero;
            }
        }

        // Exibir a cartela
        Console.WriteLine("Sua cartela:");
        for (int linha = 0; linha < 5; linha++)
        {
            for (int coluna = 0; coluna < 5; coluna++)
            {
                if (coluna == 2 && linha == 2)
                    Console.Write("XX".PadLeft(3));
                else
                    Console.Write(cartela[linha, coluna].ToString().PadLeft(3));
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        // Simular de uma jogada
        Console.WriteLine("Pressione qualquer tecla para iniciar");
        Console.ReadKey();

        HashSet<int> numerosCartela = new HashSet<int>();
        for (int linha = 0; linha < 5; linha++)
        {
            for (int coluna = 0; coluna < 5; coluna++)
            {
                if (coluna != 2 || linha != 2)
                {
                    numerosCartela.Add(cartela[linha, coluna]);
                }
            }
        }

        Console.WriteLine("Numeros sorteados durante a jogada:");
        foreach (int numero in numerosSorteados)
        {
            Console.WriteLine("Numero sorteado: " + numero);
            if (numerosCartela.Contains(numero))
            {
                Console.WriteLine("Numero esta na cartela");
                numerosCartela.Remove(numero);
            }

            if (numerosCartela.Count == 0)
            {
                Console.WriteLine("Muito bem. Voce completou a cartela!!!!!");
                break;
            }
        }
    }
}