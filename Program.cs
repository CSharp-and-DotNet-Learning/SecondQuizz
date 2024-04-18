using System;
using System.Runtime.CompilerServices;

namespace SecondQuizz;

public class SecondQuizz
{
    static string[] country = ["Albanie", "Allemagne", "Andorre", "Autriche", "Belgique", "Biélorussie", "Bosnie-Herzégovine", "Bulgarie", "Chypre", "Croatie"];
    static string[] capitalCity = { "Tirana", "Berlin", "Andorre-la-Vieille", "Vienne", "Bruxelles", "Minsk", "Sarajevo", "Sofia", "Nicosie", "Zagreb" };

    public static void Main()
    {
        (int numberOne, int numberTwo, int numberThree) = SecondQuizz.EnterThreeNumbers(1, country.Length);
        SecondQuizz.Game(numberOne, numberTwo, numberThree);
    }

    public static void Game(params int[] index)
    {
        int score = 0;
        int nbGame = index.Length;

        for (int i = 0; i < index.Length; i++)
        {
            if (index[i] <= 0 || index[i] > 10)
            {
                Console.WriteLine($"Désolé vous ne pouvez utiliser que des nombres qui vont de 1 à 10.");
                System.Environment.Exit(1);
            }
        }

        for (int l = 0; l < nbGame; l++)
        {
            int adjustedIndex = index[l] - 1;
            bool isCorrect = SecondQuizz.AskQuestion(adjustedIndex);
            if (isCorrect)
                score++;
            if (nbGame == l + 1)
                Console.WriteLine($"Bravo votre score est de : {score}.");
        }
    }

    public static bool AskQuestion(int index)
    {
        Console.WriteLine($"\n Quelle est la capital de {country[index]} ?");
        string? rep = Console.ReadLine();
        if (capitalCity[index].Equals(rep, StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Bravo !");
            return true;
        }
        Console.WriteLine($"Mauvaise réponse. La réponse était {capitalCity[index]}.");
        return false;
    }

    /*
    public static (int, int, int) GenerateThreeNumber()
    {
        Random rand = new Random();
        int numberOne = rand.Next(1, 11);
        int numberTwo = rand.Next(1, 11);
        int numberThree = rand.Next(1, 11);
        
        while (numberOne == numberTwo)
            numberTwo = rand.Next(1, 11);
 
        while (numberOne == numberThree)
            numberThree = rand.Next(1, 11);

        while (numberTwo == numberThree)
            numberThree = rand.Next(1, 11);

        return (numberOne, numberTwo, numberThree);
    }
    */

    public static (int, int, int) EnterThreeNumbers(int min, int max)
    {
        int numberOne = EnterNumber(min, max);
        int numberTwo = EnterNumber(min, max);
        int numberThree = EnterNumber(min, max);

        return (numberOne, numberTwo, numberThree);
    }

    static int EnterNumber(int min, int max)
    {
        int result;
        do
        {
            Console.WriteLine($"Entrez un nombre entre {min} et {max} ?");
            string? input = Console.ReadLine();
            result = Int32.Parse(input);
        } while (result < min || result > max);

        return result;
    }

}