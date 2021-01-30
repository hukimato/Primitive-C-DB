using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;

namespace ConsoleApp1
{
    [Serializable]
    class Magazine : Edition, IRateAndCopy, IEnumerable
    {
        private Frequency frequency;
        private List<Person> persons;
        private List<Article> articles;
        public class MagazineEnumerator : IEnumerator
        {
            List<Article> articles;
            List<Person> persons;
            int position = -1;
            public MagazineEnumerator(List<Article> articles_value, List<Person> persons_value)
            {
                this.articles = articles_value;
                this.persons = persons_value;
            }
            public object Current
            {
                get
                {
                    if (position < 0 || position >= articles.Count) throw new InvalidOperationException();
                    return articles[position];
                }
            }
            public bool MoveNext()
            {
                for (; ; )
                {
                    position++;
                    if (position == articles.Count - 1) return false;
                    Article tmp_artic = articles[position] as Article;
                    if (!persons.Contains(tmp_artic.author))
                    {
                        return true;
                    }
                }
            }
            public void Reset()
            {
                position = -1;
            }
        }
        
        public Magazine(string edition_name_value, Frequency frequency_value, DateTime magazine_birthday_value, int circulation_value)
        {
            edition_name = edition_name_value;
            frequency = frequency_value;
            date = magazine_birthday_value;
            circulation = circulation_value;
            articles = new List<Article>();
            persons = new List<Person>();
        }
        public Magazine()
        {
            edition_name = "NoName";
            frequency = Frequency.Weekly;
            date = new DateTime(1111, 11, 11);
            circulation = 0;
            articles = new List<Article>();
            persons = new List<Person>();
        }
        public string Set_Name
        {
            get
            {
                return edition_name;    
            }
            set
            {
                edition_name = value;
            }
        }
        public Frequency Set_Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
            }
        }
        public DateTime Set_Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }
         public int Set_Circulation
        {
            get
            {
                return circulation;
            }
            set
            {
                circulation = value;
            }
        }
        public List<Article> Set_Articles
        {
            get
            {
                return articles;
            }
            set
            {
                //Array.Resize(ref articles, value.Length);
                articles = value;
            }
        }

        public List<Person> Persons
        {
            get
            {
                return persons;
            }
            set
            {
                persons = value;
            }
        }


        public double avRate
        {
            get
            {
                double sumrate = 0;
                int counter = 0;
                foreach (var element in articles)
                {
                    string tmp = element.ToString();
                    string[] split = tmp.Split(' ');
                    sumrate += Convert.ToDouble(split[split.Length - 1]);
                    counter++;
                }
                return sumrate / counter;
            }

        }

        public Edition Edition 
        { 
            get
            {
                Edition ret = new Edition(this.edition_name, new DateTime(this.date.Year, this.date.Month, this.date.Day), this.circulation);
                return ret;
            }
            set
            {
                edition_name = value.Edition_Name;
                date = value.Date;
                circulation = value.Circulation;
            }
        }

        public IEnumerable<Article> Get_Hier_Rate(double min_rate)
        {
            for (int i =0; i < articles.Count;i++)
            {
                Article tmp_art = articles[i] as Article;
                if (tmp_art.rate > min_rate)// почему не работает автореализуемое свойство 
                {
                    yield return tmp_art;
                }
            }
        }

        public IEnumerable<Article> Get_String_Contains (string str) 
        {
            for (int i = 0; i < articles.Count; i++)
            {
                Article tmp_art = articles[i] as Article;
                if (tmp_art.article_name.Contains(str))// почему не работает автореализуемое свойство 
                {
                    yield return tmp_art;
                }
            }
        }

        public IEnumerable<Article> Get_Articles()
        {
            for (int i =0; i< articles.Count;i++)
            {
                Article tmp_artic = articles[i] as Article;
                if (persons.Contains(tmp_artic.author))
                {
                    yield return tmp_artic;
                }
            }
        }

        public IEnumerable<Person> Get_Persons()
        {
            ArrayList authors = new ArrayList();
            for (int i = 0; i < articles.Count; i++)
            {
                Article tmp_art = articles[i] as Article;
                authors.Add(tmp_art.author);
            }
            for (int i = 0; i < persons.Count;i++)
            {
                if (authors.Contains(persons[i]))
                {
                    Person ret = persons[i] as Person;
                    yield return ret;
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            MagazineEnumerator enm = new MagazineEnumerator(articles,persons);
            return enm;
        }

        public bool this[Frequency freq]
        {
            get
            {
                return freq == frequency;
            }
        }

        public void AddArticles(Article[] new_articles)
        {
            //Article[] res = new Article[articles.Length + new_articles.Length];
            //articles.CopyTo(res, 0);
            //int tmp= articles.Count;
            //Array.Resize(ref articles, articles.Count + new_articles.Length);
            //new_articles.CopyTo(articles, tmp);
            //articles = res;
            for (int i = 0; i < new_articles.Length;i++)
            {
                articles.Add(new_articles[i]);
            }
        }

        public void AddArticle(Article new_articles)
        {
            //Article[] res = new Article[articles.Length + new_articles.Length];
            //articles.CopyTo(res, 0);
            //int tmp= articles.Count;
            //Array.Resize(ref articles, articles.Count + new_articles.Length);
            //new_articles.CopyTo(articles, tmp);
            //articles = res;

            articles.Add(new_articles);

        }

        public void AddPersons(Person[] new_persons)
        {
            for (int i = 0; i < new_persons.Length; i++)
            {
                persons.Add(new_persons[i]);
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var element in this.persons)
            {
                str += element.ToString() + "\n";
            }

            foreach (var element in this.articles)
            {
                str += element.ToString() + "\n";
            }

            return edition_name + " " + frequency + " " + date.ToString() + " " + circulation + "" + "\nСТАТЬИ: \n" + str ;
        }

        public virtual string ToShortString()
        {
            return edition_name + " " + frequency + " " + date.ToString() + " " + circulation + " " + avRate;
        }


        // 2 Laba 
        public override bool Equals(Object obj)
        {
            Magazine magazine = obj as Magazine;
            if (edition_name != magazine.edition_name)
            {
                return false;
            }
            else if (frequency != magazine.frequency)
            {
                return false;
            }
            else if (date != magazine.date)
            {
                return false;
            }
            else if (circulation != magazine.circulation)
            {
                return false;
            }
            for (int i = 0; i< articles.Count;i++)
            {
                if (articles[i] != magazine.articles[i]) return false;
            }
            return true;
        }

        public static bool operator ==(Magazine mag1, Magazine mag2)
        {
            return mag1.Equals(mag2);
        }
        public static bool operator !=(Magazine mag1, Magazine mag2)
        {
            return !mag1.Equals(mag2);
        }

        public override int GetHashCode()
        {
            int hashcode = edition_name.GetHashCode();
            hashcode = hashcode * 21 + frequency.GetHashCode();
            hashcode = hashcode * 21 + date.GetHashCode();
            hashcode = hashcode * 21 + circulation.GetHashCode();
            for (int i = 0; i < articles.Count; i++)
            {
                hashcode = hashcode + articles[i].GetHashCode();
            }
            return hashcode;
        }


        // Правильный DeepCopy 
        //public override object DeepCopy()
        //{
        //    Magazine mag_cpy = new Magazine(String.Copy(this.edition_name), this.frequency, new DateTime(this.date.Year, this.date.Month, this.date.Day), this.circulation);
        //    for (int i = 0; i < this.articles.Count; i++)
        //    {
        //        mag_cpy.articles.Add(this.articles[i]);
        //    }
        //    return mag_cpy;
        //}


        double IRateAndCopy.Rating
        {
            get
            {
                return 0;
            }
        }


        public void ArticleNameSort()
        {
            articles.Sort();
        }

        public void ArticleRateSort()
        {
            ArticleComparer cmpr = new ArticleComparer();
            articles.Sort(cmpr);
        }

        public void ArtilceAuthorSurnameSort()
        {
            IComparer<Article> cmpr = new Article();
            articles.Sort(cmpr);
        }

        public new Magazine DeepCopy()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Magazine ret;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                ret = (Magazine)binaryFormatter.Deserialize(memoryStream);
            }
            return ret;
        }

        public bool Save(string filename)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                using (FileStream stream = new FileStream(filename, FileMode.Append))
                {
                    binaryFormatter.Serialize(stream, this);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Load(string filename)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Magazine magazine;
            try
            {
                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    magazine = (Magazine)binaryFormatter.Deserialize(stream);
                    edition_name = magazine.edition_name;
                    date = magazine.date;
                    circulation = magazine.circulation;
                    frequency = magazine.frequency;
                    persons.Clear();
                    articles.Clear();
                    foreach (Person i in magazine.persons)
                        persons.Add(i.DeepCopy());
                    foreach (Article i in magazine.articles)
                        articles.Add((Article)i.DeepCopy());
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Save(string filename, Magazine obj)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                using (FileStream stream = new FileStream(filename, FileMode.Append))
                {
                    binaryFormatter.Serialize(stream, obj);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool Load(string filename, ref Magazine obj)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                using (FileStream stream = new FileStream(filename, FileMode.Open))
                {
                    obj = (Magazine)binaryFormatter.Deserialize(stream);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Чтобы добавить новую статью в список, введите строку в формате: Имя Фамилия ГГГГ.MM.ДД Название Рейтинг");
            string str = Console.ReadLine();
            string[] strings = str.Split(' ');
            Person new_author = new Person(strings[0], strings[1], Convert.ToDateTime(strings[2]));
            Article new_article = new Article(new_author, strings[3], Convert.ToDouble(strings[4]));
            this.AddArticle(new_article);
            return true;
            //try
            //{
            //    Console.WriteLine("Чтобы добавить новую статью в список, введите строку в формате: Имя Фамилия ГГГГ.MM.ДД Название Рейтинг");
            //    string str = Console.ReadLine();
            //    string[] strings = str.Split(' ');
            //    Person new_author = new Person(strings[0], strings[1], Convert.ToDateTime(strings[2]));
            //    Article new_article = new Article(new_author, strings[3],Convert.ToDouble(strings[4]));
            //    this.AddArticle(new_article);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

    }
}
