using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace ConsoleApp1
{
    delegate void MagazinesChangedHandler<TKey>(object source, MagazinesChangedEventArgs<TKey> args);

    class MagazineCollection<TKey>
    {
        private Dictionary<TKey, Magazine> mag_dict = new Dictionary<TKey, Magazine>();
        private KeySelector<TKey> keySelector;
        public string CollectionName { get; set; }
        public event MagazinesChangedHandler<TKey> MagazineChenged;
        public MagazineCollection(KeySelector<TKey> tempKey)
        {
            this.keySelector = tempKey;
        }

        public void AddDefaults()
        {
            Magazine tmpMag = new Magazine();
            TKey key = keySelector(tmpMag);
            mag_dict.Add(key, tmpMag);
            MagazineChenged?.Invoke(this, new MagazinesChangedEventArgs<TKey>(CollectionName, Update.Add, "", key));
        }

        public void AddMagazines(params Magazine[] newMags)
        {
            foreach (Magazine element in newMags)
            {
                element.PropertyChanged += MagazinesChenged;
                TKey key = keySelector(element);
                mag_dict.Add(key, element);
                MagazineChenged?.Invoke(this, new MagazinesChangedEventArgs<TKey>(CollectionName, Update.Add, "", key));
            }
        }

        public override string ToString()
        {
            string ret = "";
            foreach (var element in mag_dict)
            {
                ret += element.Key.ToString();
                ret += " : ";
                ret += element.Value.ToString();
                ret += "\n___________________\n";
            }
            return ret;
        }

        public string ToShortString()
        {
            string ret = "";
            foreach (var element in mag_dict)
            {
                ret += element.Key.ToString();
                ret += " : ";
                ret += element.Value.ToShortString();
            }
            return ret;
        }

        public double MaxAvrRate
        {
            get
            {
                if (mag_dict.Count > 0) return mag_dict.Values.Max(x => x.avRate);
                return 0;
            }
        }

        public IEnumerable<KeyValuePair<TKey, Magazine>> FrequencyGroup(Frequency value)
        {
            return mag_dict.Where(x => x.Value.Set_Frequency==value);
        }

        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> GroupByFrequency
        {
            get
            {
                return mag_dict.GroupBy(x => x.Value.Set_Frequency);
            }
        }

        public bool Replace(Magazine mold, Magazine mnew)
        {
            foreach(var element in mag_dict)
            {
                if (element.Value == mold)
                {
                    MagazineChenged?.Invoke(this, new MagazinesChangedEventArgs<TKey>(CollectionName, Update.Replace, "", element.Key));
                    element.Value.PropertyChanged -= MagazinesChenged;
                    mag_dict[element.Key] = mnew;
                    mnew.PropertyChanged += MagazinesChenged;
                    return true;
                }
            }
            return false;
        }

        public void MagazinesChenged(object sender, PropertyChangedEventArgs _propertyChanged)
        {
            MagazineChenged?.Invoke(this, new MagazinesChangedEventArgs<TKey>(CollectionName, Update.Property, _propertyChanged.PropertyName, keySelector((Magazine)sender)));
        }
    }
}
