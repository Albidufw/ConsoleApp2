using System;
using System.Collections.Generic;
using System.IO;

namespace AssignmentTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fruitArray =
            {
                "melon",
                "apple",
                "guava",
                "apricot",
                "banana",
                "grape",
                "avocado"
            };

            //Dictionary som kategoriserar fruits till deras första bokstav och sparar dem
            Dictionary<char, List<string>> filteredFruitsByLetter = GetFruitsByCharacter(fruitArray);

            //Visar första bokstaven för deras första bokstav
            Console.WriteLine("Showing fruits with individual characters");

            //Upprepar genom dictionary för att skriva ut fruits för varje tecken
            foreach (var kvp in filteredFruitsByLetter)
            {
                Console.WriteLine($"Character '{kvp.Key}':");
                //Upprepar genom lista av fruits för tecken
                foreach (string item in kvp.Value)
                {
                    Console.WriteLine($"   {item}");
                }

                //Sparar listan av fruits till ett directory om den innehåller fruits
                if (kvp.Value.Count > 0)
                {
                    EstablishFolderAndKeepList(kvp.Key.ToString(), kvp.Value);
                }
            }

            Console.ReadKey();
        }

        //metod för att sortera fruits för deras första bokstav
        static Dictionary<char, List<string>> GetFruitsByCharacter(string[] fruit)
        {
            Dictionary<char, List<string>> filteredFruitsByLetter = new Dictionary<char, List<string>>();

            foreach (string item in fruit)
            {
                //få första tecken för fruits
                char firstCharacter = (item[0]);

                //ifall dictionary inte innehåller tecknet, lägg till det
                if (!filteredFruitsByLetter.ContainsKey(firstCharacter))
                {
                    filteredFruitsByLetter[firstCharacter] = new List<string>();
                }

                //lägg till fruit till listan som korresponderar med det första tecknet
                filteredFruitsByLetter[firstCharacter].Add(item);
            }

            return filteredFruitsByLetter;
        }

        //metod för att skapa ett directory som sparar lista av fruits i en txt fil
        static void EstablishFolderAndKeepList(string folderName, List<string> list)
        {
            // skapa directory ifall det inte redan finns
            string pathtofolder = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (!Directory.Exists(pathtofolder))
            {
                Directory.CreateDirectory(pathtofolder);
            }

            //spara listan i en txt fil i directory
            string filePath = Path.Combine(pathtofolder, "fruitList.txt");
            File.WriteAllLines(filePath, list);

            Console.WriteLine($"List saved to {filePath}");
        }
    }
}
