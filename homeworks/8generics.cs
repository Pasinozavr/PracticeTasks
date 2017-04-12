using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8generics
{
    class MyClass<T>
    {
        public static T FactoryMethod()
        {
            return default(T);
        }
        public void demonstrace() { Console.WriteLine("'"+FactoryMethod()+"' is "+FactoryMethod().GetType()); }
    }
    class MyList<T>
    {   
       static int size;
       public int Size
        {
            get { return size; }
        }
       static T[] elements;
       public T[] Elements
       {
           get { return elements; }
       }
       public void Add(T el)
        {
            T[] lol = new T[size];
            lol = elements;
            size++;
            elements = new T[size];
            for (int i = 0; i < size - 1; i++) { elements[i] = lol[i]; }
            lol = null;
            elements[size - 1] = el;
        }
       public T TakeByIndex(int index)
        {
            if (index <= size) { return elements[index - 1]; }
            else { Console.WriteLine("{"+index+"th element isn't exist}"); return default(T); }
        }
      
       public void Show()
        {
           for (int i = 0; i < size; i++) { Console.WriteLine(elements[i]); }
        }
        /*
       public static T[] GetArray<T>(this MyList<T> list)
       {
           return MyList<T>.elements;
       }
       //Метод расширения должен быть определен в статическом классе, не являющимся универсальным

         */
    }
    class Book
    {
       public string key;
       public int value;
    }
    class MyDictionary<TKey, TValue>
        where TValue : struct
        where TKey : class
    {

        int size;
        public int Size
        {
            get { return size; }
        }
        TKey[] keys;
        TValue[] values;
        public void Add(TKey key, TValue value)
        {
            TKey[] keys_lol = new TKey[size];
            keys_lol = this.keys;
            TValue[] values_lol = new TValue[size];
            values_lol = this.values;

            size++;

            keys = new TKey[size];
            values = new TValue[size];

            for (int i = 0; i < size - 1; i++) { keys[i] = keys_lol[i]; values[i] = values_lol[i]; }

            keys[size - 1] = key;
            values[size - 1] = value;
        }
        public TValue TakeByIndex(int index)
        {
            if (index <= size) { return values[index - 1]; }
            else { Console.WriteLine("{" + index + "th element isn't exist}"); return default(TValue); }
        }
        public void Show()
        {
            for (int i = 0; i < size; i++) { Console.WriteLine(keys[i]+"->"+values[i]); }
        }
    }
    public class Car
    {
        public Car(string prm1, int prm2)
        {
            name = prm1;
            age = prm2;
        }
       public string name;
       public int age;
    }
    class CarCollection<T> where T:Car
    {
        int size;
        public int Size
        { get{return size;} }
        public T[] cars;
        public void Add(T el)
        {
            T[] old_cars = new T[size];
            old_cars = cars;
            size++;
            cars = new T[size];
            for (int i = 0; i < size-1; i++)
            {
                cars[i] = old_cars[i];
            }
            cars[size - 1] = el;
            Console.WriteLine("element " + el.name + " was added");
        }
        public Car this[int index]
        {
            get { return cars[index]; }
            set { cars[index] = (T)value; }
        }

        public void DeleteAll()
        {
            size = 0;
            cars = new T[0];
            Console.WriteLine("CarCollection was cleaned");
        }
        public void Show()
        {
            Console.WriteLine("Car park:");
            for (int i = 0; i < size; i++) { Console.WriteLine(cars[i].age+" -eq- "+cars[i].name); }
        }
    }
    class ArrayList
    {
        int size;
        object [] array;
        public ArrayList()
        {
            size = 0;
            array = new object[size];
        }
        public object Add(object what_to_add)
        {
            /*
            object[] newarray = new object[size + 1];
            newarray = array;
            newarray[size] = what_to_add;
            size++;
            */
            object[] newarray = new object[size];
            newarray = array;
            size++;
            array = new object[size];
            for (int i = 0; i < size - 1; i++) { array[i] = newarray[i]; }
            newarray = null;
            array[size - 1] = what_to_add;

            return array[size - 1];
        }
        public object Del(int index)
        {
            object temp=null;
            object[] newarray = new object[size-1];
            int j = 0;
            for (int i = 0; i < size; i++)
            {
                if (i != index) { newarray[j] = array[i]; j++; }
                else { temp = array[i]; }
            }
            array = newarray;
            size--;
            return temp;
        }
        public void Show()
        {
            for (int i = 0; i < size; i++) { Console.WriteLine("#" + (i+1) + ":" + array[i]); }
        }

    }
    class Program
    {
        
        static void Main(string[] args)
        {
            MyClass<int> classing1=new MyClass<int>();
            classing1.demonstrace();
            MyClass<char> classing2 = new MyClass<char>();
            classing2.demonstrace();
            Console.WriteLine();

            MyList<int> listing = new MyList<int>();
            listing.Add(10);
            listing.Add(20);
            listing.Show();
            Console.WriteLine("The first element is " + listing.TakeByIndex(1) + "\nThe 12-th is " + listing.TakeByIndex(12));
            Console.WriteLine("List consist " + listing.Size + " elements");
            Console.WriteLine();

            MyDictionary<string, int> dictinaring = new MyDictionary<string, int>();
            dictinaring.Add("first", 1);
            dictinaring.Add("second", 2);
            dictinaring.Add("third", 3);
            dictinaring.Show();
            Console.WriteLine("Dictionary consist " + dictinaring.Size + " elements");
            Console.WriteLine();

            /*
           Console.WriteLine("Вывод списка через метод расширения:");
           for (int i = 0; i<listing.Size; i++)
           {
               Console.WriteLine(MyList<int>.GetArray(listing)[i]);
           }
            */
            Car toyota = new Car("toyta", 2000);
            Car toshiba = new Car("toshiba", 2015);
            Car citroyen = new Car("citroyen", 1998);

            CarCollection<Car> carpark=new CarCollection<Car>();
            carpark.Add(toyota);
            carpark.Add(toshiba);
            carpark.Show();
            Console.WriteLine("Carpark consist " + carpark.Size + " elements");
            carpark.DeleteAll();
            carpark.Show();
            Console.WriteLine("Carpark consist " + carpark.Size + " elements");
            carpark.Add(citroyen);
            carpark.Show();
            Console.WriteLine();

            ArrayList myarraylist = new ArrayList();
            Console.WriteLine("element '" + myarraylist.Add(13) + "' was added");
            Console.WriteLine("element '" + myarraylist.Add("lol") + "' was added");
            Console.WriteLine("element '" + myarraylist.Add(10.5) + "' was added");
            myarraylist.Show();
            Console.WriteLine("element '" + myarraylist.Del(0) + "' was deleted");
            myarraylist.Show();

            Console.Write("Программа будет завершена.");
            Console.Read();
        }
    }
}
