using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace ConsoleApp1
{
    [Serializable]
    class Edition: INotifyPropertyChanged
    {
        protected string edition_name;
        protected DateTime date;
        protected int circulation;

        public event PropertyChangedEventHandler PropertyChanged;

        public Edition(string edition_name_value, DateTime date_value, int circulation_value)
        {
            edition_name = edition_name_value;
            date = date_value;
            circulation = circulation_value;
        }

        public Edition()
        {
            edition_name = "No_Name";
            date = new DateTime(0001, 01, 01);
            circulation = 0;
        }

        public string Edition_Name
        {
            get { return edition_name; }
            set { edition_name = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { 
                date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date"));
            }
        }

        public int Circulation
        {
            get { return circulation; }
            set 
            { 
                if (value < 0)
                {
                    throw new Exception("Тираж не может быть отрицательным.");
                }
                circulation = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Circulation"));
            }
        }

        public virtual object DeepCopy()
        {
            return (object)new Edition(this.edition_name, new DateTime(this.date.Year, this.date.Month, this.date.Day), this.circulation);
        }

        public override bool Equals(Object obj_tmp)
        {
            Edition obj = obj_tmp as Edition;
            if (edition_name != obj.edition_name) return false;
            else if (date != obj.date) return false;
            else if (circulation != obj.circulation) return false;
            return true;
        }

        public static bool operator ==(Edition edition1, Edition edition2)
        {
            return edition1.Equals(edition2);
        }
        public static bool operator !=(Edition edition1, Edition edition2)
        {
            return !edition1.Equals(edition2);
        }

        public override int GetHashCode()
        {
            int hashcode = edition_name.GetHashCode();
            hashcode = 31 * hashcode + date.GetHashCode();
            hashcode = 31 * hashcode + circulation.GetHashCode();
            return hashcode;
        }

        public override string ToString()
        {
            return edition_name + " " + date.ToString() + " " + circulation.ToString(); 
        }


    }
}
