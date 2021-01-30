using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    [Serializable]
    class Article : IRateAndCopy, IComparable, IComparer<Article>
    {
        public Person author { get; set; }
        public string article_name { get; set; }
        public double rate;

        public Article(Person person_value, string Article_Name_value, double rate_value)
        {
            author = person_value;
            article_name = Article_Name_value;
            rate = rate_value;
        }
        public Article()
        {
            author = new Person();
            article_name = "Without Name";
            rate = 9.9;
        }
        public override string ToString()
        {
            return author.Name + " " + author.Surname + " " + author.Birthday + " " + article_name + " " + rate;
        }

        
        public string Return_Article_Name()
        {
            return article_name;
        }

        // 2 Laba 
        public override bool Equals(Object obj)
        {
            Article article = obj as Article;
            if (author != article.author)
            {
                return false;
            }
            else if (article_name != article.article_name)
            {
                return false;
            }
            else if (rate != article.rate)
            {
                return false;
            }
            else return true;
        }

        public static bool operator ==(Article article1, Article article2)
        {
            return article1.Equals(article2);
        }
        public static bool operator !=(Article article1, Article article2)
        {
            return !article1.Equals(article2);
        }

        public override int GetHashCode()
        {
            int hashcode = author.GetHashCode();
            hashcode = hashcode * 31 + article_name.GetHashCode();
            hashcode = hashcode * 31 + rate.GetHashCode();
            return hashcode;
        }

        /// <summary>
        /// DeepCopy 
        /// </summary>
        /// <returns></returns>
        //public virtual Article DeepCopy()
        //{
        //    return new Article(this.author.DeepCopy(), String.Copy(this.article_name), this.rate);
        //}

        //object IRateAndCopy.DeepCopy()
        //{
        //    return new Article(this.author.DeepCopy(), String.Copy(this.article_name), this.rate);
        //}

        public object DeepCopy()
        {
            return new Article(this.author.DeepCopy(), String.Copy(this.article_name), this.rate);
        }

        double IRateAndCopy.Rating
        {
            get
            {
                return rate;
            }
        }


        /// <summary>
        /// Реализация интерфейсов
        /// </summary>
        public int CompareTo (object obj)
        {
            Article tmp_art = obj as Article;
            if (obj != null) return this.article_name.CompareTo(tmp_art.article_name);
            else throw new ArgumentException("Невозможно сравнить объекты типа Article и введенный объект.");
        }

        public int Compare(Article art1, Article art2)
        {
            return String.Compare(art1.author.Surname, art1.author.Surname);
        }
    }
}
