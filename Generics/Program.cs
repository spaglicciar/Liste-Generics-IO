using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Users\\spagliccia\\Desktop\\Esercizio\\";
            string fileName = "Esercizio.txt";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fullPath = Path.Combine(path, fileName);

            if (!File.Exists(fullPath))
            {
                File.Create(fullPath);
            }

            List<Persona> listP = new List<Persona>();
            Persona p3 = new Persona("Mario", "Rossi", DateTime.Now);

            Persona[] persone = new Persona[]
            {
                new Persona("Gigi", "Buffon", DateTime.Now),
                new Persona("Cristian", "Vieri", DateTime.Now)
            };

            //Aggiungo tutto l'array di persone nella lista
            listP.AddRange(persone);
            listP.Add(p3);

            StringBuilder sb = new StringBuilder();

            foreach (var p in listP)
            {
                sb.AppendLine(p.ToString());
            }

            File.WriteAllText(fullPath, sb.ToString());

            string result = File.ReadAllText(fullPath);

            Console.WriteLine(result);

            FileStream fs = File.Open(fullPath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);

            byte[] bytes = Encoding.ASCII.GetBytes(sb.ToString());

            fs.Write(bytes, 0, bytes.Length);

            fs.Close();


            XmlSerializer serializer = new XmlSerializer(typeof(Persona));

            fullPath = Path.Combine(path, "Esercizio.xml");


            FileStream fs1 = File.Open(fullPath, FileMode.OpenOrCreate);

            serializer.Serialize(fs1, p3);

            fs1.Close();

            fullPath = Path.Combine(path, "Esercizio2.xml");

            FileStream fs2 = File.Open(fullPath, FileMode.OpenOrCreate);

            Persona p4 = (Persona)serializer.Deserialize(fs2);

            fs2.Close();
            Console.WriteLine(p4);


            XmlSerializer listSerializer = new XmlSerializer(typeof(List<Persona>));
            fullPath = Path.Combine(path, "Esercizio3.xml");

            using (FileStream fs3 = File.Open(fullPath, FileMode.Create))
            {
                listSerializer.Serialize(fs3, listP);
            }

            XmlSerializer arraySerializer = new XmlSerializer(typeof(Persona[]));
            //fullPath = Path.Combine(path, "Esercizio4.xml");
            Persona[] test;
            using (FileStream fs3 = File.Open(fullPath, FileMode.Open))
            {
                test = (Persona[])arraySerializer.Deserialize(fs3);
            }

            foreach(var p in test)
            {
                Console.WriteLine(p);
            }
           

            Console.ReadLine();

            Dictionary<string, Dictionary<string, string>> pippo;
        }
    }
}
