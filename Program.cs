using System.IO;

namespace Assignment2_3_1
{
    internal class Program
    {
        // Write a console application to create a text file and save your basic details like name, age, address ( use dummy data).
        // Read the details from same file and print on console.
        static void Main(string[] args)
        {
            string name = "Elijah";
            string age = "30";
            string address = "Place In US";
            string filePath =  @"Test.txt";
            List<string> infoList = new List<string>();
            List<Person> personList = new List<Person>();

            /* Uses streamwriter and reader from Microsoft .NET doc of File example
            if (File.Exists(filePath))
            {
               using(StreamWriter sw = new StreamWriter(filePath))
               {
                    sw.WriteLine($"Name: {name}");
                    sw.WriteLine($"Age: {age}");
                    sw.WriteLine($"Address: {address}");
                }
            }

            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            */

            // Writes to file initially
            File.WriteAllText(filePath, $"{ name },{ age },{ address }");

            // Reads file and puts into list
            infoList = File.ReadAllLines(filePath).ToList();

            // Puts information from infolist list for newPerson in person class instantiation and writes to console  
            foreach (string line in infoList)
            {
                string[] splitLine = line.Split(',');
                Person newPerson = new Person();
                newPerson.Name = splitLine[0];
                newPerson.Age = splitLine[1];
                newPerson.Address = splitLine[2];
                personList.Add(newPerson);
                Console.WriteLine($"Name: { splitLine[0] }");
                Console.WriteLine($"Age: { splitLine[1] }");
                Console.WriteLine($"Address: { splitLine[2] }");
            }

            // List of outputs for person
            List<string> output = new List<string>();

            // Adds to output list
            foreach (var person in personList)
            {
                output.Add($"{ person.Name }L,{ person.Age }L,{person.Address}L");
            }

            // Appends line Writes to file with output list elements
            File.AppendAllText(filePath, Environment.NewLine);
            File.AppendAllLines(filePath, output);

            // For test purpose, would normally use a method or loop
            
            // Read the new txt file with added line
            infoList = File.ReadAllLines(filePath).ToList();
            
            // Write to console new lines
            foreach (string line in infoList)
            {
                string[] splitLine = line.Split(',');
                Console.WriteLine($"Name: {splitLine[0]}");
                Console.WriteLine($"Age: {splitLine[1]}");
                Console.WriteLine($"Address: {splitLine[2]}");
            }

        }
    }
}
