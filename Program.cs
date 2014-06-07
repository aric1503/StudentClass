using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClassHW
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Student> listOfStudents = new List<Student> {
                new Student("Amar Ikovic", "Praso", "aric1503@aubih.edu.ba"),
                new Student("Semir", "Masic", "srmc1636@aubih.edu.ba"),
                new Student("Dzenan", "Ganovic", "dngc1569@aubih.edu.ba"),
                new Student("Arvin", "Oprasic", "anoc1524@aubih.edu.ba"),
                new Student("Nedim", "Sarajlic", "nmsc4896@aubih.edu.ba"),
                new Student("Amina", "Mavric", "aamc1509@aubih.edu.ba")
                };

                listOfStudents.Sort();
                foreach (Student s in listOfStudents) {
                    Console.WriteLine(s.getStudentInfo());
                }
            }
            catch (CustomExeption)
            {
                Console.WriteLine("Please try again\n");
            }


            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
        }
    }

    class CustomExeption : Exception
    {
        public CustomExeption(string text, string value)
        {
            Console.WriteLine("Error: Value \"{0}\" is not valid. {1}\n", value, text);
            return;
        }
    }

    abstract class Person
    {
        protected string name, lastName;
        protected string Name {
            set {
                if(value.Length <= 2) {
                    throw new CustomExeption("Must be longer than 2", value);
                }

                char[] cArray = value.ToCharArray();
                foreach (char c in cArray)
                {
                    if (!char.IsLetter(c))
                    {
                       throw new CustomExeption("Can be only letter", value);
                    }
                }

                if (!char.IsUpper(cArray[0]))
                {
                    throw new CustomExeption("Name must start with an uppercase letter", value);
                }

                name = value;
            }
            get
            {
                return name;
            }
        }

        protected Person(string name, string lastName)
        {
            this.Name = name;
            this.lastName = lastName;
        }

        protected string getPersonInfo()
        {
            return Name + ", " + lastName;
        }
    }
    
    class Student : Person
    {
        public string email {get; set;}
        private string Location;
        public string location
        {
            get
            {
                if (Location == "SA")
                {
                    return "Sarajevo";
                }
                else if (Location == "TZ")
                {
                    return "Tuzla";
                }
                else
                {
                    return "Other";
                }
            }
            set
            {
                if (value == "SA" || value == "SARAJEVO" || value == "Sarajevo")
                {
                    Location = "Sarajevo";
                }
                else if (value == "TZ" || value == "TUZLA" || value == "Tuzla")
                {
                    Location = "Tuzla";
                }
                else
                {
                    Location = "NA";
                }
            }
        }
        public Student() : base("Amar Ikovic", "Prašo")
        {
            this.email = "aric1503@aubih.edu.ba";
            this.location = "Sarajevo";
        }

        ~Student() {

        }

        public Student(string name, string lastname, string email)
            : base(name, lastname)
        {
            this.email = email;
            this.location = "Sarajevo";
        }
        
        public string getStudentInfo()
        {
            return base.getPersonInfo() + ", " + this.email + ", " + this.location;
        }

        public override string ToString()
        {
            return getStudentInfo();
        }
    }
}
