using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MagazinesChangedEventArgs<TKey>: System.EventArgs
    {
        public string CollectionName { get; set; }
        public Update Update { get; set; }
        public string PropertyName { get; set; }
        public TKey Key { get; set; }

        public MagazinesChangedEventArgs(string collection_value, Update update_value, string property_value, TKey key_value)
        {
            CollectionName = collection_value;
            Update = update_value;
            PropertyName = property_value;
            Key = key_value;
        }

        public override string ToString()
        {
            return CollectionName + Update.ToString() + PropertyName + Key.ToString();
        }
    }
}
