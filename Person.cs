using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [Serializable]
    class Person
    {
        private string name;
        private string surname;
        private DateTime birthday;
        
        public Person(string name_value, string surname_value, DateTime birthday_value)
        {
            name = name_value;
            surname = surname_value;
            birthday = birthday_value;
        }
        public Person()/*:this("Даниил", "Александров", new DateTime(2001, 11, 22)) { }*/
        {
            name = "Даниил";
            surname = "Александров";
            birthday = new DateTime(2001, 11, 22);
        }
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public DateTime Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = new DateTime(value.Year,value.Month,value.Day);
            }
        }
        
        public int ChangeYear
        {
            get
            {
                return birthday.Year;
            }
            set
            {
                birthday = new DateTime(value, birthday.Month, birthday.Day);
            }
        }

        public override string ToString()
        {
            return name + " " + surname + " " + birthday.ToString(); ;

        }
        
        public virtual string ToShortString()
        {
            return name + " " + surname;
        }

        //SystemDiagnosticStopWatch - для замера 



        // 2 Laba 
        public override bool Equals(Object obj)
        {
            Person person = obj as Person;
            if (name != person.name)
            {
                return false;
            }
            else if (surname != person.surname)
            {
                return false;
            }
            else if (birthday != person.birthday)
            {
                return false;
            }
            else return true;
        }

        public static bool operator ==(Person person1, Person person2)
        {
            return person1.Equals(person2);
        }
        public static bool operator !=(Person person1, Person person2)
        {
            return !person1.Equals(person2);
        }

        public override int GetHashCode()
        {
            int hashcode= name.GetHashCode();
            hashcode = 31 * hashcode + surname.GetHashCode();
            hashcode = 31 * hashcode + birthday.GetHashCode();
            return hashcode;
        }

       

        public Person DeepCopy()
        {
            return new Person(String.Copy(this.name), String.Copy(this.surname), new DateTime(this.birthday.Year, this.birthday.Month, this.birthday.Day));
        }

    }



}
