using System;
using System.Data;
using System.IO;


//Napisz program, który tablicę o wymiarach 10 × 10 wypełnioną jedynkami zapisuje do pliku tekstowego dane.txt,
//a następnie zapisane dane odczytuje z pliku dane.txt i wyświetla.
//Obsłuż sytuację, w której plik dane.txt nie będzie istniał i w związku z tym jego odczytanie nie będzie możliwe.

class ObslugaWyjatkow
{
    static void Main()
    {
        string fileName = "dane.txt";

        if (!File.Exists(fileName))
        {
            Console.WriteLine("PLik {0} nie istnieje.", fileName);
            Console.WriteLine("Tworzenie nowego pliku...");

            int[,] data = new int[10, 10];
            for (int i = 0; i < 10;  i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    data[i, j] = 1;
                }
            }

            SaveToFile(fileName, data);
            Console.WriteLine("Plik {0} został utworzony i wypełniony danymi.", fileName);
        }
        else
        {
            int[,] data = ReadFromFile(fileName);
            Console.WriteLine("Dane odczytane z pliku {0}: ", fileName);
            DisplayData(data);
        }
    }

    static void SaveToFile(string fileName, int[,] data)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            for (int i = 0; i < 10;  i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    writer.Write(data[i, j] + " ");
                }
                writer.WriteLine();
            }
        }
    }

    static int[,] ReadFromFile(string fileName)
    {
        int[,] data = new int[10, 10];
        using (StreamReader reader = new StreamReader(fileName))
        {
            for (int i =0; i < 10; i++)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 10; j++)
                {
                    data[i, j] = int.Parse(values[j]);
                }
            }
        }
        return data;
    }

    static void DisplayData(int[,] data)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0;j < 10; j++)
            {
                Console.WriteLine(data[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}