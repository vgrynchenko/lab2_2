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


