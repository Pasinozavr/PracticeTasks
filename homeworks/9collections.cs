using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
namespace _9collections
{
    
    class Program
    {
        
        class IntColl : IEnumerable
        {
            private int[] array;
            public IntColl(int[] array)
            {
                this.array = array;
            }
            public int this[int index]
            {
                get
                {
                    return array[index];
                }
                set
                {
                    array[index] = value;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 2 == 0) yield return array[i];
                }
            }
        }
        class MyList<T> : IEnumerable
        {
            private T[] elements;
            public MyList(T[]arr)
 {
 elements = arr;
 }
            public int Length
 {
 get { return elements.Length; }
 }
            public T this[int index]
 {
 get
 {
 return elements[index];
 }
 set
 {
 elements[index] = value;
 }
 }
            public MyList()
            {
                elements = new T[0];
            }
            public void Add(T element)
            {
                T [] newarr=new T[elements.Length+1];
                for (int i = 0; i < elements.Length; i++)
                {
                    newarr[i] = elements[i];
                }
                newarr[elements.Length] = element;
                elements = newarr;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return elements.GetEnumerator();
            }
          
            //Метод расширения должен быть определен в статическом классе, не являющимся универсальным
            /*
            public static T[] GetArray<T>(this IEnumerable list)
            {
                T[] mynewar = new T[0];
                foreach (var el in list)
                {
                    T[] newarr = new T[mynewar.Length + 1];
                    for (int i = 0; i < mynewar.Length; i++)
                    {
                        newarr[i] = mynewar[i];
                    }
                    newarr[mynewar.Length] = el;
                    mynewar = newarr;
                }
                return mynewar;
            }
            */
        }
        class MyDictionary<TKey, TValue> : IEnumerable
        {
            private int size;
            public int Size
            {
                get { return size; }
            }
            private TKey[] keys;
            private TValue[] values;
            public MyDictionary()
            {
                keys = new TKey[0];
                values = new TValue[0];
                size = 0;
            }
            public TValue this[TKey index]
            {
                get
                {
                    for (int i = 0; i < size; i++) { if (keys[i].Equals(index))return values[i]; }
                    return default(TValue);
                }
            }
            public void Add(TKey key, TValue value)
            {
                TKey[] newkeys = new TKey[size + 1];
                TValue[] newvalues = new TValue[size + 1];
                for (int i = 0; i < size; i++)
                {
                    newkeys[i] = keys[i];
                    newvalues[i] = values[i];
                }
                newkeys[size] = key;
                newvalues[size] = value;
                keys = newkeys;
                values = newvalues;
                size++;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return keys.GetEnumerator();
            }
        }

        static void Main(string[] args)
        {
            int[]arr=new int[10]{1,2,3,4,5,6,7,8,9,10};
            IntColl myintcoll=new IntColl(arr);
            foreach (int el in myintcoll)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();

            MyList<string> mystrings=new MyList<string>();
            mystrings.Add("abcd");
            mystrings.Add("efg");
            foreach (var el in mystrings)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();

            MyDictionary<int,string> newdict=new MyDictionary<int,string>();
            newdict.Add(1, "a");
            newdict.Add(2, "b");
            newdict.Add(45, "c");

            foreach (var el in newdict)
            {
                Console.WriteLine(""+el+"->"+newdict[(int)el]);
            }

           // string[] mas;
           // mas=MyList<string>.GetArray<string>(mystrings);
            Console.WriteLine("Программа подошла к концу.");
            Console.ReadLine();
        }
    }
}
