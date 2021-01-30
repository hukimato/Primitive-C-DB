using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    delegate KeyValuePair<TKey, TValue> GenerateElement<TKey, TValue>(int j);
    delegate TKey KeySelector<TKey>(Magazine mg);

    class Program
    {
        //------------------------------------------------------------------------------------------------------Лабораторная №5---------------------------------------------------------------------------------------------------------
        static void Main(string[] args)
        {
            Random rand = new Random();
            KeySelector<string> selector = delegate (Magazine input)
            {
                return (input.GetHashCode()/rand.Next(1,20)).ToString();
            };


            //Создать объект типа T с непустым списком элементов, для которого
            //предусмотрен ввод данных с консоли.Создать полную копию объекта с
            //помощью метода, использующего сериализацию, и вывести исходный
            //объект и его копию
            Magazine m1 = new Magazine("Edition1", Frequency.Yearly, new DateTime(2020, 10, 02), 10101);

            List<Article> new_articles = new List<Article>();
            new_articles.Add(new Article(new Person("Daniil", "Aleksandrov", new DateTime(2001, 11, 22)), "Article1", 9.1));
            new_articles.Add(new Article(new Person("Zeus", "Ult", new DateTime(0001, 01, 01)), "Article3", 1.0));
            new_articles.Add(new Article(new Person("Alex", "Alex", new DateTime(1990, 12, 01)), "Article2", 9.0));
            new_articles.Add(new Article(new Person("qweqwe", "qweqwe", new DateTime(2000, 08, 18)), "Article4", 9.8));
            m1.Set_Articles = new_articles;

            Magazine copied = m1.DeepCopy();

            Console.WriteLine(m1.ToString());
            Console.WriteLine(copied.ToString());


            //Предложить пользователю ввести имя файла:
            // если файла с введенным именем нет, приложение должно сообщить об этом и создать файл;
            // если файл существует, вызвать метод Load(string filename) для инициализации объекта T данными из файла.

            Console.WriteLine("Введите название файла: ");
            string file = Console.ReadLine();

            Magazine m2 = new Magazine();

            FileInfo userFile = new FileInfo(file);
            if (!userFile.Exists)
            {
                Console.WriteLine("Файл не найден. Он будет создан.");
                userFile.Create();
            }
            else
            {

                m2.Load(file);
            }

            //Вывести объект.

            Console.WriteLine(m2.ToString());

            //Для этого же объекта T сначала вызвать метод AddFromConsole(), затем
            //метод Save(string filename).Вывести объект T.
            Console.WriteLine("------------------------------");
            m2.AddFromConsole();
            m2.Save(file);
            Console.WriteLine(m2.ToString());

            //Вызвать последовательно
            // статический метод Load(string filename, T obj), передав как
            //параметры ссылку на тот же самый объект T и введенное ранее имя файла;
            // метод AddFromConsole();
            // статический метод Save(string filename, T obj).
            Console.WriteLine("------------------------------");
            Magazine.Load(file, ref m2);
            m2.AddFromConsole();
            Magazine.Save(file, m2);
            Console.WriteLine(m2.ToString());

















            //------------------------------------------------------------------------------------------------------Лабораторная №4---------------------------------------------------------------------------------------------------------










            ////Создать два объекта MagazineCollection<string> с разными названиями.
            //MagazineCollection<string> mag_col1 = new MagazineCollection<string>(selector);
            //mag_col1.CollectionName = "mag_col1";
            //MagazineCollection<string> mag_col2 = new MagazineCollection<string>(selector);
            //mag_col2.CollectionName = "mag_col2";






            ////Создать объект типа Listener и подписать его на события
            ////MagazinesChanged из обоих объектов MagazineCollection<string>.
            //Listener listener = new Listener();
            //mag_col1.MagazineChenged += listener.MagazineChanged;
            //mag_col2.MagazineChenged += listener.MagazineChanged;







            ////3.Внести изменения в MagazineCollection<string>:
            ////     добавить элементы в коллекции;
            ////     изменить значения разных свойств элементов, входящих в коллекцию;
            ////     заменить один из элементов коллекции;
            ////     изменить данные в элементе, который был удален из коллекции при замене элемента.
            //Magazine m1 = new Magazine("Edition1", Frequency.Yearly, new DateTime(2020, 10, 02), 10101);
            //Magazine m2 = new Magazine("Edition2", Frequency.Monthly, new DateTime(2019, 09, 04), 12222);
            //Magazine m3 = new Magazine("Edition3", Frequency.Weekly, new DateTime(2018, 08, 08), 999);
            //mag_col1.AddMagazines(m1, m2);
            //mag_col2.AddDefaults();
            //m2.Date = new DateTime(2000, 01, 01);
            //mag_col1.Replace(m1, m3);
            //m2.Circulation = 9999;
            //m1.Circulation = 100;
            //m3.Circulation = 10000000;



            ////Вывести данные объекта Listener

            //Console.WriteLine(listener.ToString());




















            //------------------------------------------------------------------------------------------------------Лабораторная №3---------------------------------------------------------------------------------------------------------


            ////Создать объект Magazine и вызвать методы, выполняющие сортировку
            ////списка List<Article> статей в журнале по разным критериям, после каждой
            ////сортировки вывести данные объекта. Выполнить сортировку
            //// по названию статьи;
            //// по фамилии автора;
            //// по рейтингу статьи.
            //Magazine magazine1 = new Magazine("Edition1", Frequency.Monthly, new DateTime(2000, 01, 01), 100);
            //List<Article> new_articles = new List<Article>();
            //new_articles.Add(new Article(new Person("Daniil", "Aleksandrov", new DateTime(2001, 11, 22)), "Article1", 9.1));
            //new_articles.Add(new Article(new Person("Zeus", "Ult", new DateTime(0001, 01, 01)), "Article3", 1.0));
            //new_articles.Add(new Article(new Person("Alex", "Alex", new DateTime(1990, 12, 01)), "Article2", 9.0));
            //new_articles.Add(new Article(new Person("qweqwe", "qweqwe", new DateTime(2000, 08, 18)), "Article4", 9.8));
            //magazine1.Set_Articles = new_articles;

            //Console.WriteLine("------------------Без сортировки-------------");
            //Console.WriteLine(magazine1.ToString());

            //Console.WriteLine("------------------Сортировка по названию статьи.-------------");
            //magazine1.ArticleNameSort();
            //Console.WriteLine(magazine1.ToString());

            //Console.WriteLine("------------------Сортировка по фамилии автора.-------------");
            //magazine1.ArtilceAuthorSurnameSort();
            //Console.WriteLine(magazine1.ToString());

            //Console.WriteLine("------------------Сортировка по рейтингу статьи.-------------");
            //magazine1.ArticleRateSort();
            //Console.WriteLine(magazine1.ToString());

            ////Создать объект MagazineCollection<string>.Добавить в коллекцию
            ////несколько разных элементов типа Magazine и вывести объект
            ////MagazineCollection<string>.
            //Random rand = new Random();
            //KeySelector<string> selector = delegate (Magazine input)
            //{
            //    return (input.GetHashCode()/rand.Next(1,20)).ToString();
            //};
            //Console.WriteLine("------------------Magazine Collection-------------");
            //var mag_col = new MagazineCollection<string>(selector);
            //mag_col.AddDefaults();
            //Magazine m1 = new Magazine("Edition2", Frequency.Yearly, new DateTime(2020, 10, 02), 10101);
            //Magazine m2 = new Magazine("Edition3", Frequency.Yearly, new DateTime(2019, 09, 04), 12222);
            //mag_col.AddMagazines(m1, magazine1,m2);
            //Console.WriteLine(mag_col.ToString());

            ////Вызвать методы класса MagazineCollection<string>, выполняющие
            ////операции с коллекцией-словарем Dictionary<TKey, Magazine>, и после
            ////каждой операции вывести результат операции.Выполнить
            //// вычисление максимального значения среднего рейтинга статей для
            ////элементов коллекции;
            //// вызвать метод FrequencyGroup для выбора журналов с заданной
            ////периодичностью выхода;
            //// вызвать свойство класса, выполняющее группировку элементов
            ////коллекции по периодичности выхода; вывести все группы
            ////элементов.
            //Console.WriteLine("------------------Magazine Collection Методы-------------");
            //Console.WriteLine(mag_col.MaxAvrRate);
            //foreach (var element in mag_col.FrequencyGroup(Frequency.Yearly))
            //{
            //    Console.WriteLine(element.ToString());
            //}
            //foreach (var element in mag_col.GroupByFrequency)
            //{
            //    foreach (var element1 in element)
            //    {
            //        Console.WriteLine(element1.ToString());
            //    }
            //    Console.WriteLine("Следующая группа");
            //}

            ////Создать объект типа TestCollection<Edition, Magazine>. Ввести число
            ////элементов в коллекциях и вызвать метод для поиска первого,
            ////центрального, последнего и элемента, не входящего в коллекции.
            ////Вывести значения времени поиска для всех четырех случаев. 

            //Console.WriteLine("------------------Test Collections-------------");

            //GenerateElement<Edition, Magazine> generator = delegate (int j)
            // {
            //     var key = new Edition("Edition" + j, new DateTime(2000, 01, 01), j * 1000);
            //     var value = new Magazine(key.Edition_Name, Frequency.Yearly, key.Date, key.Circulation);
            //     return new KeyValuePair<Edition, Magazine>(key, value);
            // };
            //Console.WriteLine("Введите кол-во элементов.");




            //for(; ; )
            //{
            //    bool flag = true;
            //    try
            //    {
            //        long number = Convert.ToInt64(Console.ReadLine());
            //        var test_col = new TestCollections<Edition, Magazine>(number, generator);
            //        test_col.searchInTKeyList();
            //        test_col.searchInStrList();
            //        test_col.searchInKeyDict();
            //        test_col.searchInStrDict();
            //        test_col.searchInKeyDictByValue();
            //    }
            //    catch(ArgumentException e)
            //    {
            //        Console.WriteLine(e.Message);
            //        flag = false;
            //    }
            //    if (flag) break;
            //}

































            //------------------------------------------------------------------------------------------------------Лабораторная №2---------------------------------------------------------------------------------------------------------


            //Edition edition1 = new Edition("basic_edition", new DateTime(1111, 01, 01), 1);
            //Edition edition2 = new Edition("basic_edition", new DateTime(1111, 01, 01), 1);

            //Console.WriteLine(edition1.ToString());
            ////ref Edition edition1Ref = ref edition1;
            ////Console.WriteLine(&edition1Ref);
            //Console.WriteLine(edition1.GetHashCode());

            //Console.WriteLine(edition2.ToString());
            //Console.WriteLine(edition2.GetHashCode());


            ////В блоке try/catch присвоить свойству с тиражом издания некорректное значение, в обработчике исключения вывести сообщение, переданное через объект - исключение.");
            //try
            //{
            //    edition1.Circulation = -100;
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}


            ////Создать объект типа Magazine, добавить элементы в списки статей и редакторов журнала и вывести данные объекта Magazine. ");
            //Magazine magazine = new Magazine("Gazeta", Frequency.Monthly, new DateTime(1000, 10, 10), 9999);
            //Article[] default_art = { new Article(new Person("tyu", "tyu", new DateTime(2222, 8, 8)), "Statya1", 5.2), new Article(new Person("zxc", "zxc", new DateTime(1111, 11, 11)), "Statya2", 5.0) };
            //ArrayList new_articles = new ArrayList();
            //new_articles.Add(new Article(new Person("zxc", "zxc", new DateTime(1111, 11, 11)), "Statya2", 5.0));
            //new_articles.Add(new Article(new Person("tyu", "tyu", new DateTime(2222, 8, 8)), "Statya1", 5.2));
            //magazine.Set_Articles = new_articles;

            //ArrayList new_persons = new ArrayList();
            //new_persons.Add(new Person("zxc", "zxc", new DateTime(1111, 11, 11)));
            //new_persons.Add(new Person("tyu", "tyu", new DateTime(2222, 8, 8)));
            //magazine.Persons = new_persons;
            //Console.WriteLine(magazine.ToString());

            ////"Вывести значение свойства типа Edition для объекта типа Magazine");
            //Console.WriteLine(magazine.Edition.ToString());//--------------------------------------------------Раскомментируй

            ////С помощью метода DeepCopy() создать полную копию объекта Magazine.Изменить данные в исходном объекте Magazine и вывести копию и исходный объект, полная копия исходного объекта должна остаться без изменений.

            //Magazine mag_cpy = new Magazine();

            //mag_cpy = (Magazine)magazine.DeepCopy();
            //Console.WriteLine("_________________________До изменений______________________________");
            //Console.WriteLine(magazine.ToString());
            //Console.WriteLine(mag_cpy.ToString());

            //magazine.Set_Frequency = Frequency.Yearly;
            //magazine.Set_Name = "Chaged Name";
            //magazine.Set_Date = new DateTime(2020, 10, 12);

            //ArrayList changed_persons = new ArrayList();
            //changed_persons.Add(new Person("Changed_Person", "Changed_Person", new DateTime(2000, 10, 10)));
            //magazine.Persons = changed_persons;

            //ArrayList changed_articles = new ArrayList();
            //changed_articles.Add(new Article());
            //magazine.Set_Articles = changed_articles;

            //Console.WriteLine("_________________________После изменений______________________________");
            //Console.WriteLine(magazine.ToString());
            //Console.WriteLine(mag_cpy.ToString());
            //Console.WriteLine("_______________________________________________________");

            //changed_persons.Add(new Person("qwerty", "qwerty", new DateTime(2000, 10, 10)));
            //changed_articles.Add(new Article (new Person("qwerty", "qwerty", new DateTime(2000, 10, 10)), "TEST", 10.0));


            ////На удивление, работает
            //Console.WriteLine("________________________Итераторы_______________________________");
            //foreach (Article element in mag_cpy.Get_Hier_Rate(5.0))
            //{
            //    Console.WriteLine(element.ToString());
            //}
            //Console.WriteLine("_______________________________________________________");
            //foreach (Article element in mag_cpy.Get_String_Contains("Statya"))
            //{
            //    Console.WriteLine(element.ToString());
            //}
            //Console.WriteLine("_______________________________________________________");
            //foreach (Article element in mag_cpy.Get_Articles())
            //{
            //    Console.WriteLine(element.ToString());
            //}
            //Console.WriteLine("_______________________________________________________");
            //foreach (Person element in mag_cpy.Get_Persons())
            //{
            //    Console.WriteLine(element.ToString());
            //}
            //Console.WriteLine("_______________________________________________________");
            //foreach (Article element in mag_cpy)
            //{
            //    Console.WriteLine(element.ToString());
            //}



















            //------------------------------------------------------------------------------------------------------Лабораторная №1---------------------------------------------------------------------------------------------------------


            // Создание нескольких элементов классов
            //Person person1 = new Person();
            //Person person2 = new Person("Daniil","Aleksandrov", new DateTime(2001,11,22));

            //Article[] default_art = { new Article(new Person("tyu", "tyu", new DateTime(2222, 8, 8)), "Statya1", 5.2), new Article(new Person("zxc", "zxc", new DateTime(1111, 11, 11)), "Statya2", 5.0) };
            //Magazine magazine = new Magazine("Gazeta", Frequency.Monthly, new DateTime(1000, 10, 10), 9999);
            //magazine.Set_Articles = default_art;

            //Article[] default_art1 = { new Article(new Person("tyu", "tyu", new DateTime(2222, 8, 8)), "Statya1", 5.2), new Article(new Person("zxc", "zxc", new DateTime(1111, 11, 11)), "Statya2", 5.0) };
            //Magazine magazine1 = new Magazine("Gazeta1", Frequency.Monthly, new DateTime(1000, 10, 10), 9999);
            //magazine1.Set_Articles = default_art1;

            //Article[] default_art2 = { new Article(new Person("tyu", "tyu", new DateTime(2222, 8, 8)), "Statya1", 5.2), new Article(new Person("zxc", "zxc", new DateTime(1111, 11, 11)), "Statya2", 5.0) };
            //Magazine magazine2 = new Magazine("Gazeta1", Frequency.Monthly, new DateTime(1000, 10, 10), 9999);
            //magazine2.Set_Articles = default_art2;

            //// Проверяю методы сравнения, переопределенных операторов и GetHashCode()
            //Console.WriteLine("_______________________Проверяю операторы для сравнения Класса Person__________________________");
            //Console.WriteLine(person1.ToString());
            //Console.WriteLine(person1.GetHashCode());
            //Console.WriteLine(person2.ToString());
            //Console.WriteLine(person2.GetHashCode());
            //Console.WriteLine(person1.Equals(person2));
            //Console.WriteLine(person1 == person2);
            //Console.WriteLine(person1 != person2);

            //Console.WriteLine("____________________Проверяю операторы для сравнения Класса Article_____________________________");


            //Console.WriteLine(magazine.Set_Articles[0].ToString());
            //Console.WriteLine(magazine.Set_Articles[0].GetHashCode());
            //Console.WriteLine(magazine1.Set_Articles[0].ToString());
            //Console.WriteLine(magazine1.Set_Articles[0].GetHashCode());

            //Console.WriteLine(magazine.Set_Articles[0].Equals(magazine1.Set_Articles[0]));
            //Console.WriteLine(magazine.Set_Articles[0] == magazine1.Set_Articles[0]);
            //Console.WriteLine(magazine.Set_Articles[0] != magazine1.Set_Articles[0]);

            //Console.WriteLine("____________________Проверяю операторы для сравнения Класса Magazine_____________________________");


            //Console.WriteLine(magazine.ToString());
            //Console.WriteLine(magazine.GetHashCode());
            //Console.WriteLine(magazine1.ToString());
            //Console.WriteLine(magazine1.GetHashCode());
            //Console.WriteLine(magazine2.ToString());
            //Console.WriteLine(magazine2.GetHashCode());
            //Console.WriteLine(magazine.Equals(magazine1));
            //Console.WriteLine(magazine == magazine1);
            //Console.WriteLine(magazine != magazine1);

            //Console.WriteLine("______________________Проверяю методы DeepCopy___________________________");

            //Console.WriteLine(person2.ToString());
            //Person person_cpy= person2.DeepCopy();
            ////person_cpy = person2.DeepCopy();
            //Console.WriteLine(person_cpy.ToString());

            //Console.WriteLine("_________________________________________________");

            //Console.WriteLine(magazine.Set_Articles[0].ToString());
            //Article article_cpy = magazine.Set_Articles[0].DeepCopy();
            //Console.WriteLine(article_cpy.ToString());

            //Article article_test = ((IRateAndCopy)default_art[0]).DeepCopy();


            //Console.WriteLine("_________________________________________________");

            //Console.WriteLine(magazine.ToString());
            //Magazine new_magazine = magazine.DeepCopy();
            //Console.WriteLine(new_magazine.ToString());


            //_________________________________ПЕРВАЯ ЛАБА________________________________

            //magazine.AddArticles(default_art);
            //Console.WriteLine(magazine.ToShortString());
            //Console.WriteLine(magazine[Frequency.Weekly]);
            //Console.WriteLine(magazine[Frequency.Monthly]);
            //Console.WriteLine(magazine[Frequency.Yearly]);
            //magazine.Set_Name="asdasd";
            //magazine.Set_Frequency = Frequency.Yearly;
            //magazine.Set_Date = new DateTime(2020, 1, 12);
            //magazine.Set_Circulation = 1488;
            //Article[] added_art = { new Article(new Person("qwe","rty", new DateTime(1999,12,13)),"Statya3",9.1)};
            //magazine.AddArticles(added_art);
            //Console.WriteLine(magazine.ToString());

            ////Сравнение времени разных массивов
            //Console.WriteLine("Введите два числа: кол-во строк и кол-во столбцов через пробел.");
            //string str = Console.ReadLine();
            //string[] split = str.Split(' ');
            //int ncolumn = Convert.ToInt32(split[1]), ncrow = Convert.ToInt32(split[0]);

            //Article[] mas1 = new Article[ncolumn * ncrow];
            //for (int i =0; i < ncolumn*ncrow;i++)
            //{
            //    mas1[i] = new Article();
            //}

            //Article[,] mas2 = new Article[ncrow, ncolumn];
            //for (int i = 0; i < ncrow; i++)
            //{ 
            //    for (int j=0; j < ncolumn;j++)
            //    {
            //        mas2[i, j] = new Article();
            //    }
            //}

            //Article[][] mas3 = new Article[ncrow][];
            //for (int i=0;i<ncrow;i++)
            //{
            //    mas3[i] = new Article[ncolumn];
            //}
            //for (int i = 0; i < ncrow; i++)
            //{
            //    for (int j = 0; j < ncolumn; j++)
            //    {
            //        mas3[i][j] = new Article();
            //    }
            //}
            ////SystemDiagnosticStopWatch - для замера 

            //var timer = new System.Diagnostics.Stopwatch();

            //timer.Start();
            //for (int i = 0; i < ncolumn * ncrow; i++)
            //{
            //    mas1[i].article_name = "qwerty";
            //}
            //timer.Stop();
            //Console.WriteLine(timer.ElapsedMilliseconds);


            //timer.Restart();
            //for (int i = 0; i < ncrow; i++)
            //{
            //    for (int j = 0; j < ncolumn; j++)
            //    {
            //        mas2[i, j].article_name = "qwerty";
            //    }
            //}
            //timer.Stop();
            //Console.WriteLine(timer.ElapsedMilliseconds);


            //timer.Restart();
            //for (int i = 0; i < ncrow; i++)
            //{
            //    for (int j = 0; j < ncolumn; j++)
            //    {
            //        mas3[i][j].article_name = "qwerty";
            //    }
            //}
            //timer.Stop();
            //Console.WriteLine(timer.ElapsedMilliseconds);


        }
    }
}
