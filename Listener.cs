using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Listener
    {
        List<ListEntry> list;

        public Listener()
        {
            list = new List<ListEntry>();
        }

        public void MagazineChanged(object obj, MagazinesChangedEventArgs<string> args_value)
        {
            list.Add(new ListEntry(args_value.CollectionName, args_value.Update, args_value.PropertyName, args_value.Key));
        }

        public override string ToString()
        {
            string ret = "";
            foreach (var element in list)
                ret += element.ToString() + '\n';
            return ret;
        }
    }
}
