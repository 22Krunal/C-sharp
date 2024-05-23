using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp14
{
    public class Program
    {
        static void Main(string[] args)
        {
            string textFilePath4 = @"C:\Users\Lenovo\Desktop\testFile4.txt";
            FileInfo datFile = new FileInfo(textFilePath4);

            BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());

            string rndText = "Random Text";
            int myAge = 35;
            double height = 35.4;

            bw.Write(rndText);
            bw.Write(myAge);
            bw.Write(height);
            bw.Close();

            BinaryReader br = new BinaryReader(datFile.OpenRead());

            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadDouble());
            br.Close();



            /*
             * Read/write in file through streamWriteer and streamReader
             * 
            string textFilePath3 = @"C:\Users\Lenovo\Desktop\testFile3.txt";

            StreamWriter sw = new StreamWriter(textFilePath);

            sw.Write("This is a random.");
            sw.WriteLine("Sentence...");
            sw.Write("This is another Sentence");
            sw.Close();

            StreamReader sr = new StreamReader(textFilePath);
            Console.WriteLine("Peek : {0} ",
                Convert.ToChar(sr.Peek()));

            Console.WriteLine("1st String : {0}",
                sr.ReadLine());

            Console.WriteLine("Everything eles : {0}",
                sr.ReadToEnd());

            sr.Close();  

            */


            /*
             * File read / write with byte stream
             * 
            string textFilePath2 = @"C:\Users\Lenovo\Desktop\testFile2.txt";
            FileStream fs = File.Open(textFilePath2,
                FileMode.Create);

            string rndString = "This is random string";
            byte[] rsByteArray = Encoding.Default.GetBytes(rndString);

            fs.Write(rsByteArray, 0, rsByteArray.Length);

            fs.Position = 0;

            byte[] fileByteArray = new byte[rsByteArray.Length];

            int cnt = 0;
            foreach (byte b in rsByteArray)
            {
                Console.Write(b);
                cnt++;
            }
            Console.WriteLine("---{0}----", cnt);
            for(int i = 0; i < rsByteArray.Length; i++)
            {
                fileByteArray[i] = (byte)fs.ReadByte();
            }

            Console.WriteLine(Encoding.Default.GetString(fileByteArray));
            fs.Close();
            */
            /*
             * Directory and file manipulation
             * 
            DirectoryInfo currDir = new DirectoryInfo(".");
            Console.WriteLine(currDir.CreationTime);

            DirectoryInfo Dir = new DirectoryInfo(@"C:\Users\Lenovo");

            Console.WriteLine(Dir.FullName);
            Console.WriteLine(Dir.Name);
            Console.WriteLine(Dir.Parent);
            Console.WriteLine(Dir.Attributes);
            Console.WriteLine(Dir.CreationTime);

            DirectoryInfo DataDir = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\tempNew");

            DataDir.Create();

            Directory.Delete(@"C:\Users\Lenovo\Desktop\tempNew");


            string[] customers =
            {
                "Virat Kohli",
                "Michel Jordan",
                "Critiano Ronaldo",
                "Nikola Tesla",
                "Kobi Brian"
            };

            string textFilePath = @"C:\Users\Lenovo\Desktop\testfile1.txt";

            File.WriteAllLines(textFilePath, customers);

            foreach(string cust in File.ReadAllLines(textFilePath))
            {
                Console.WriteLine($"Mamba Mindset: {cust}");
            }

            DirectoryInfo myDataDir = new DirectoryInfo(@"C:\Users\Lenovo\Desktop");

            FileInfo[] txtFiles = myDataDir.GetFiles("*.txt", SearchOption.AllDirectories);

            Console.WriteLine(txtFiles.Length);

            foreach(FileInfo file in txtFiles)
            {
                Console.WriteLine(file.Name);
            }

            */

        }
    }
}