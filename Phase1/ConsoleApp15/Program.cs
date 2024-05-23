using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace ConsoleApp15
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
             * Serialize using Binary Formatter giving error cause been removed in lasted .net version 
             * 
            Animal browser = new Animal("Browser", 35, 36, 1);
            Stream stream = File.Open("AnimalData.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(stream, browser);
            stream.Close();

            browser = null;

            stream = File.Open("AnimalData.dat", FileMode.Open);
            bf = new BinaryFormatter();

            browser = (Animal)bf.Deserialize(stream);

            Console.WriteLine(browser.ToString());
            */

            Animal browser = new Animal("Browser", 35, 36, 1);

            XmlSerializer serializer = new XmlSerializer(typeof(Animal));
            using (TextWriter tw = new StreamWriter(@"C:\Users\Lenovo\Desktop\browser.xml"))
            {
                serializer.Serialize(tw, browser);
            }
            browser = null;

            XmlSerializer deserializer = new XmlSerializer (typeof(Animal));
            TextReader reader = new StreamReader(@"C:\Users\Lenovo\Desktop\browser.xml");
            
            object obj = deserializer.Deserialize(reader);
            browser = (Animal)obj;
            reader.Close();

            Console.WriteLine(browser.ToString());

            List<Animal> theAnimals = new List<Animal>
            {
                new Animal("Mario", 3, 3, 3),
                new Animal("Luigi", 3, 3, 3),
                new Animal("Peach", 3, 3, 3)
            };

            using (Stream fs = new FileStream(@"C:\Users\Lenovo\Desktop\animals.xml",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Animal>));
                serializer2.Serialize(fs, theAnimals);
            }

            theAnimals = null;

            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Animal>));

            using (FileStream fs2 = File.OpenRead(@"C:\Users\Lenovo\Desktop\animals.xml"))
            {
                theAnimals = (List<Animal>)serializer3.Deserialize(fs2);
            }
            
            foreach(Animal a in theAnimals)
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
}