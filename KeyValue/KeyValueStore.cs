using System;
using System.Collections.Generic;
using System.Text;

namespace KeyValueAssignment
{
    public struct KeyValue
    {
        public readonly string Key;
        public readonly int Value;
        public KeyValue(string s, int i)
        {
            Key = s;
            Value = i;
        }
    }
    public class MyDictionary
    {
        private KeyValue[] store;
        private int count;
        public MyDictionary()
        {
            store = new KeyValue[2];
            count = 0;
        }

        public int Count { get; set; }
        public int this[string key]
        {
            get => FindKeyValue(key);
            set
            {
                try
                {
                    store[FindKeyValue(key)] = new KeyValue(key, value);
                }
                catch
                {
                    store[count] = new KeyValue(key, value);
                    count++;
                }
            }
        }

        public int FindKeyValue (string s)
        {
            for (int i = 0; i < count; i++)
            {
                if (store[i].Key == s) return store[i].Value;
            }
            throw new KeyNotFoundException();
        }
    }
}
