using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ListEntry
    {
        public string CollectionName { get; set; }
        public Update Update { get; set; }
        public string PropertyName { get; set; }
        public string Key { get; set; }

        public ListEntry(string name_value, Update upd_value, string prop_value, string key_value)
        {
            CollectionName = name_value;
            Update = upd_value;
            PropertyName = prop_value;
            Key = key_value;
        }

        public string UpdateToString()
        {
            if (Update == Update.Add) return "Add";
            else if (Update == Update.Replace) return "Replace";
            else if (Update == Update.Property) return "Property";
            return "";
        }

        public override string ToString()
        {
            return CollectionName + " " + UpdateToString() + " " + PropertyName + " " + Key;
        }
    }
}
