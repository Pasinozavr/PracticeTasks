using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;


namespace _2classes
{
    class Address
    {
        int index;
        public int Index
        {
            get { return index; }
            set
            {
                if (value > 10000)
                {
                 Console.WriteLine("{0} - normal index", value);
                 index = value;
                }
                else
                {
                    Console.WriteLine("{0} - incorrect index", value);
                }
            }
        }
        public int Apartment
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
        public string Street
        {
            get;
            set;
        }
        public string House
        {
            get;
            set;
        }
    }
    class Rectangle
    {
        double side1, side2;
        public Rectangle(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }
        double AreaCalculate(double side1, double side2)
        {
            return side1 * side2;
        }
        double PerimetrCalculate(double side1, double side2)
        {
            return 2 * (side1 + side2);
        }
        public double Area{
            get { 
                return AreaCalculate(side1, side2); 
            }
        }
        public double Perimetr { 
            get 
            { 
                return PerimetrCalculate(side1, side2); 
            } 
        }
    }
    class Book
    {
        Title title;
        Author author;
        Content content;
        
        public Book()
        {
            title = new Title();
            author = new Author();
            content = new Content();
            title.info = "i"; author.info = "am"; content.info = "empty";
            Console.WriteLine("New book created");
        }
        public void Show()
        {
            title.Show();
            author.Show();
            content.Show();
        }
        public void Edit()
        {
            Console.WriteLine("Enter title: ");
            title.info = Console.ReadLine();
            Console.WriteLine("Enter author: ");
            author.info = Console.ReadLine();
            Console.WriteLine("Enter content: ");
            content.info = Console.ReadLine();
        }
    }
    class Title
    {
        public string info;
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Title: {0}", info);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    class Author
    {
        public string info;
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Author: {0}", info);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    class Content
    {
        public string info;
        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Content: {0}\n", info);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    class Point
    {
        int x;
        int y;
        string name;
        public int X { get{return x;} }
        public int Y { get { return y; } }
        public string Name { get { return name; } }
        public Point(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }
    class Figure
    {
        int count;
        Point first, second, third, fourth, fifth;
        double LengthSide(Point A, Point B)
        {
            return Math.Sqrt((B.X-A.X)*(B.X-A.X)+(B.Y-A.Y)*(B.Y-A.Y));
        }
        public void PerimetrCalculator()
        {
            string name;
            name = "" + first.Name + second.Name;
            double perimetr = 0;
            perimetr += LengthSide(first, second);
            perimetr += LengthSide(second, third);

            if (count == 3)
            {
                name += third.Name;
                perimetr += LengthSide(third, first);
            }
            else if (count == 4)
            {
                name += third.Name + fourth.Name;
                perimetr += LengthSide(third, fourth);
                perimetr += LengthSide(fourth, first);
            }
            else if (count == 5)
            {
                name += third.Name + fourth.Name +fifth.Name;
                perimetr += LengthSide(third, fourth);
                perimetr += LengthSide(fourth, fifth);
                perimetr += LengthSide(fifth, first);
            }
            Console.WriteLine("Perimetr of {0} = {1}", name, perimetr);
        }
        public Figure(Point first, Point second, Point third)
        {
            count = 3;
            this.first = first;
            this.second = second;
            this.third = third;
        }
        public Figure(Point first, Point second, Point third, Point fourth)
        {
            count = 4;
            this.first = first;
            this.second = second;
            this.third = third;
            this.fourth = fourth;
        }
        public Figure(Point first, Point second, Point third, Point fourth, Point fifth)
        {
            count = 5;
            this.first = first;
            this.second = second;
            this.third = third;
            this.fourth = fourth;
            this.fifth = fifth;
        }

    }
    class User
    {
        string login, name, lastname;
        int age;
        readonly string time;
        string input(string text, string a)
        {
            Console.WriteLine(text);
            a = Console.ReadLine();
            return a;
        }
        public User()
        {
           time = DateTime.Now.ToString("dd MMMM yyyy");
           Console.WriteLine("Анкета создана.");
        }
       public void Edit()
        {
            age = 0;
            login=input("Введите логин", login);
            name=input("Введите имя", name);
            lastname=input("Введите фамилию", lastname);
            do
            {
                Console.Write("Введите возраст\n");
                try
                {
                    age = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error input. Try again.");
                }
            } while (age == 0);
        }
      public  void Show()
        {
            Console.WriteLine("Логин: {0}\nИмя: {1}\nФамилия: {2}\nВозраст: {3}\nДата создания: {4}\n", login, name, lastname, age, time); 
        }
    }
    class Converter
    {
        public static double ParseDouble(string text, double number)
        {
            do
            {
                Console.Write(text);
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error input. Try again.");
                }
            } while (number == 0);
            return number;
        }
        double usd, eur, rub;
        public Converter()
        {
            Console.WriteLine("Bad constructor");
            usd = 1/10;
            eur = 1/20;
            rub = 3;
        }
        public Converter(double usd, double eur, double rub)
         {
             this.usd = usd;
             this.eur = eur;
             this.rub = rub;
         }
        public void ConverFromGrn(double grn)
        {
            Console.WriteLine("grn: {0}. usd: {1}. eur: {2}. rub: {3}.", grn, grn/usd, grn/eur, grn/rub);
        }
        public void ConverFrom()
        {
            int number = 0;
            double usd=0, eur=0, rub=0, grn=0;
            do
            {
                Console.Write("1. usd, 2. eur, 3. rub. choose: ");
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error input. Try again.");
                }
            } while (number == 0);

            if (number == 1)
            {
                usd = ParseDouble("Input how much usd you wanna convert\n", usd);
                grn = usd * this.usd;
            }
            if (number == 2)
            {
                eur = ParseDouble("Input how much eur you wanna convert\n", eur);
                grn = eur * this.eur;
            }
            if (number == 3)
            {
                rub = ParseDouble("Input how much rub you wanna convert\n", rub);
                grn = rub * this.rub;
                
            }
            Console.WriteLine("grn: {0}. usd: {1}. eur: {2}. rub: {3}.", grn, grn / this.usd, grn / this.eur, grn / this.rub);
        }
    }
    class Employee
    {
        string name, lastname;
        int worked, rang;
        double pay, payoff;
        Random rnd;
        public Employee(string name, string lastname)
        {
            rnd = new Random();
            this.name = name;
            this.lastname = lastname;
            worked = rnd.Next(1, 5);
            rang = rnd.Next(1, 3);
        }
        public void CalculatePay()
        {
            pay=rang * 100 + worked * 50;
            payoff = (0.10 - 0.005 * worked) * pay;
        }
        
        public void Show()
        {
            if (pay == 0)
            {
                Console.WriteLine("Оклад и налог еще не высчитаны");
            }
            else
            {
                Console.WriteLine("Имя {0}\nФамилия {1}\nОклад {2}\nНалоговый сбор - {3}", name, lastname, pay, payoff);
            }
        }
    }
    class Invoice
    {
        readonly int account;
        readonly string customer;
        readonly string provider;
        string article;
        int quantity=0;
        bool nds = true;
        Random rnd;
        public double withNDS()
        {
            return (((account * quantity) / 1.2) - (account * quantity)) * (-1);
        }
        public double withoutNDS()
        {
            return (account * quantity);
        }
        public Invoice()
        {
            Console.WriteLine("Начало создания счета.");
            Console.WriteLine("Введите свое ФИО или ИД покупателя:");
            customer = Console.ReadLine();
            provider = "Supermarker VARUS";
            rnd = new Random();
            account = rnd.Next(5, 150);
            Console.WriteLine("Счет составлен. При покупке от 100 единиц товара, данная транзакция считается оптовой и НДС отключается.\n");
            do
            {
                Console.Write("Введите количество товара: ");
                try
                {
                    quantity = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error input. Try again.");
                }
            } while (quantity == 0);
            if (quantity >= 100)
            {
                nds = false;
            }
        }
        public void Show()
        {
            Console.Write("Клиент\tПоставщик\tЦена товара\tКоличество\tСчет\n{0}\t{1}\t{2}\t{3}\t", customer, provider, account, quantity);
            if (nds)
            {
                 Console.WriteLine(withNDS());
            }
            else
            {
                Console.WriteLine(withoutNDS());
            }
        }
    }
    public class SecretKeeper
    {
        private int _secret;

        // Для упрощения тестирования
        public int Secret { get { return _secret; } set { _secret = value; } }
    }
    public static class SecretFinder
    {
        public static int GetSecretUsingFieldInfo(this SecretKeeper keeper)
        {
            FieldInfo fieldInfo = typeof(SecretKeeper).GetField("_secret", BindingFlags.Instance | BindingFlags.NonPublic);
            int result = (int)fieldInfo.GetValue(keeper);
            return result;
        }

    }
    class taskforpractice
    {
        public static double ParseDouble( string text, double number)
        {
            do
            {
                Console.Write(text);
                try
                {
                    number = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error input. Try again.");
                }
            } while (number==0);
            return number;
        }
        public static void ParseInteger(string text, int number)
        {
            do
            {
                Console.Write(text);
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error input. Try again.");
                }
            } while (number == 0);
        }
        public static void newline()
        {
            Console.WriteLine("\n");
        }
        static void Main(string[] args)
        {
            Address home = new Address();
            home.Index = 0;
            home.Country = "Ukraine";
            home.Apartment = 64;
            home.House = "6a";
            home.Street="Kasakevicha";
            home.Index = 49066;
            Console.WriteLine("My home is {0} {1} {2} {3} {4}\n", home.Index, home.Country, home.Street, home.House, home.Apartment);
            newline();
            Console.Write("Enter sides of the rectangle:\n");
            double side1=0, side2=0;
            side1=ParseDouble("first\n", side1);
            side2=ParseDouble("second\n", side2);
            Rectangle figure = new Rectangle(side1, side2);
            Console.WriteLine("Area={0}. Perimetr={1}.", figure.Area, figure.Perimetr);
            newline();
            Book book1 = new Book();
            book1.Show();
            Book book2 = new Book();
            book2.Edit();
            book2.Show();
            newline();
            Point first = new Point(0, 0, "A");
            Point second = new Point(0, 3, "B");
            Point third = new Point(4, 0, "C");
            Figure treangle = new Figure(first, second, third);
            treangle.PerimetrCalculator();
            Point fourth = new Point(4, -3, "D");
            Figure rectangle = new Figure(first, second, third, fourth);
            rectangle.PerimetrCalculator();
            newline();
            User pasha = new User();
            pasha.Edit();
            pasha.Show();
            newline();
            Converter newcon = new Converter(27.000, 28.900, 0.4600);
            newcon.ConverFrom();
            newcon.ConverFromGrn(500);
            newline();
            string name, lastname;
            Console.WriteLine("Введите имя сотрудника");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилию сотрудника");
            lastname = Console.ReadLine();
            newline();
            Employee me = new Employee(name, lastname);
            me.CalculatePay();
            me.Show();
            newline();
            Invoice sell = new Invoice();
            sell.Show();
            Invoice sell2 = new Invoice();
            sell2.Show();
            newline();
            Console.WriteLine("Program is off.");
            Console.ReadLine();
        }
    }
}
