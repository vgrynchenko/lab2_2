using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_2g
{
    class Contact
    {
        private string Name, TelNumber, DateOfBirth;
        public Contact(string name = "", string date = "", string phone = "")
        {
            name = name.Trim();
            if (!String.IsNullOrEmpty(name))
                name = Char.ToUpper(name[0]) + name.Substring(1);
            this.Name = name;
            this.TelNumber = phone.Trim();
            this.DateOfBirth = date.Trim();
        }
        public override string ToString()
        {
            string res = String.Concat(this.Name, "\t\t", this.DateOfBirth, "\t\t", this.TelNumber, "\n");
            return res;
        }
        public string getName()
        {
            return this.Name;
        }
        public string getDate()
        {
            return this.DateOfBirth;
        }
        public string getTelNumber()
        {
            return this.TelNumber;
        }
        public static bool operator <(Contact first, Contact second)
        {
            int minLength = 0;
            bool is_first_smaller;
            if (first.getName().Length <= second.getName().Length)
            {
                minLength = first.getName().Length;
                is_first_smaller = true;
            }
            else
            {
                minLength = second.getName().Length;
                is_first_smaller = false;
            }
            for (int i = 0; i < minLength; i++)
            {
                if ((int)first.getName()[i] < (int)second.getName()[i])
                {
                    return true;
                }
                else if ((int)first.getName()[i] > (int)second.getName()[i])
                {
                    return false;
                }

            }
            if (first.getName().Length == second.getName().Length)
            {
                is_first_smaller = false;
            }
            return is_first_smaller;
        }
        public static bool operator >(Contact first, Contact second)
        {
            int minLength = 0;
            bool is_first_bigger;
            if (first.getName().Length <= second.getName().Length)
            {
                minLength = first.getName().Length;
                is_first_bigger = false;
            }
            else
            {
                minLength = second.getName().Length;
                is_first_bigger = true;
            }
            for (int i = 0; i < minLength; i++)
            {
                if ((int)first.getName()[i] > (int)second.getName()[i])
                {
                    return true;
                }
                else if ((int)first.getName()[i] < (int)second.getName()[i])
                {
                    return false;
                }

            }
            if (first.getName().Length == second.getName().Length)
            {
                is_first_bigger = false;
            }
            return is_first_bigger;
        }
        public static bool operator ==(Contact first, Contact second)
        {
            return (first.getName() == second.getName());
        }
        public static bool operator >=(Contact first, Contact second)
        {
            return (first == second || first > second);
        }
        public static bool operator <=(Contact first, Contact second)
        {
            return (first == second || first < second);
        }
        public static bool operator !=(Contact first, Contact second)
        {
            return !(first.getName() == second.getName());
        }
    }
    class Directory
    {
        private ArrayList Book = new ArrayList();
        private int Length
        {
            get
            {
                return this.Book.Count;
            }
            set
            {
                Length = this.Book.Count;
            }
        }
        public Directory(params Contact[] contacts)
        {
            foreach (Contact note in contacts)
            {
                this.Book.Add(note);
            }
        }
        public void AddElements(params Contact[] values)
        {
            foreach (Contact note in values)
            {
                this.Book.Add(note);
            }
        }
        public void AddElement(Contact el)
        {
            this.Book.Add(el);
        }
        public void DelElement(Contact el)
        {
            if (this.Book.Contains(el))
            {
                this.Book.Remove(el);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public object this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Book.Count)
                {
                    return this.Book[i];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (i >= 0 && i < this.Book.Count)
                {
                    this.Book[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public override string ToString()
        {
            string result = "Name\t\tDate of birth\t\tPhone number\n";
            foreach (Contact element in this.Book)
            {
                result = String.Concat(result, Convert.ToString(element));
            }
            return result;
        }
        public string NameFinder(string key)
        {
            foreach (Contact note in this.Book)
            {
                if (note.getName() == key)
                {
                    return String.Concat("Контакт, который вы искали:\n", Convert.ToString(note));
                }
            }
            return "Искомый контак не найден!";
        }
        public string DateFinder(string key)
        {
            foreach (Contact note in this.Book)
            {
                if (note.getDate() == key)
                {
                    return String.Concat("Контакт, который вы искали:\n", Convert.ToString(note));
                }
            }
            return "Искомый контак не найден!";
        }
        public string PhoneFinder(string key)
        {
            foreach (Contact note in this.Book)
            {
                if (note.getTelNumber() == key)
                {
                    return String.Concat("Контакт, который вы искали:\n", Convert.ToString(note));
                }
            }
            return "Искомый контак не найден!";
        }
        public void Sort()
        {
            Contact[] auxBook = new Contact[this.Book.Count];
            int j = 0;
            Contact tmp = new Contact();
            foreach (Contact el in this.Book)
            {
                auxBook[j] = el;
                j++;
            }
            for (int count = 0; count < this.Length; count++)
            {
                for (int i = 0; i < this.Length - 1; i++)
                {
                    if (auxBook[i] > auxBook[i + 1])
                    {
                        tmp = auxBook[i];
                        auxBook[i] = auxBook[i + 1];
                        auxBook[i + 1] = tmp;
                    }
                }
            }
            for (int i = 0; i < this.Book.Count; i++)
            {
                this.Book[i] = auxBook[i];
            }

        }
    }
  class Program
    {


        static void Main(string[] args)
        {
           
            Contact num1 = new Contact("Petrov", "15.11.1997", "+380934444365");
            Contact num2 = new Contact("Vasilenko", "12.02.1960", "+380675447834");
            Contact num3 = new Contact("Korolenko", "22.06.1965", "+380980708007");
            Contact num4 = new Contact("Oleynik", "06.10.1978", "+380980708007");
            Contact num5 = new Contact("Afon", "23.05.1995", "+38096578885");
            Directory newDir = new Directory( num1, num2, num3, num4, num5);
            Console.WriteLine(newDir);
            newDir.Sort();
            Console.WriteLine(newDir);
            Console.WriteLine(newDir.NameFinder("Oleynik"));
            Console.WriteLine(newDir.PhoneFinder("+3809765444"));
            Console.WriteLine(newDir.DateFinder("23.05.1995"));

            Console.ReadKey();
        }
    }
}



