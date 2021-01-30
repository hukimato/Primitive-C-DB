using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ArticleComparer: IComparer<Article>
    {
        public int Compare(Article art1, Article art2)
        {
            if (art1.rate > art2.rate) return 1;
            else if (art1.rate < art2.rate) return -1;
            else return 0;
        }
    }
}
