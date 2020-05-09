using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> stud = new List<Student>();
            Student Bob = new Student {Name="Bob", Group ="Java"};
            Student Dan = new Student { Name = "Dan", Group = "Ruby" };
            Student Rex = new Student { Name = "Rex", Group = "Python" };
            Student Rob = new Student { Name = "Rob", Group = "HTML" };
            Student Jenny = new Student { Name = "Jenny", Group = "MySQL" };
            stud.Add(new Student { Name = "Bob", Group = "Java" });
            stud.Add(Dan);
            stud.Add(Rex);
            stud.Add(Rob);
            stud.Add(Jenny);
            DataContractSerializer dc = new DataContractSerializer(typeof(List<Student>));
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true};
            using (XmlDictionaryWriter xw = XmlDictionaryWriter.CreateDictionaryWriter(XmlWriter.Create("stud.xml")))
                dc.WriteObject(xw,stud);
            List<Student> new_stud = new List<Student>(); 
            using (XmlReader xr = XmlReader.Create("stud.xml"))
                new_stud =(List<Student>) dc.ReadObject(xr);
            foreach (Student i in new_stud)
                Console.WriteLine("{0} studies {1}", i.Name, i.Group);
            Console.ReadLine();
        }
        
        [DataContract]
        class Student
        {
            [DataMember]public string Name;
            [DataMember]public string Group;
        }
    }
}
