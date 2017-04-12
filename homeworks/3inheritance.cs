using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3inheritance
{
    abstract class Printer
    {
        abstract public void Print(string value);
    }
    class WBPrinter : Printer
    {
        public WBPrinter()
        {
            Console.WriteLine("Черно-белый принтер создан.");
        }
        override public void Print(string value)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    class ColourPrinter : Printer
    {
        public ColourPrinter()
        {
            Console.WriteLine("Цветной принтер создан.");
        }
        override public void Print(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(value);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
    class ClassRoom
    {
        Pupil [] pupils;
        public ClassRoom(Pupil first, Pupil second, Pupil third, Pupil fourth)
        {
            pupils = new Pupil[5];
            pupils[1] = first;
            pupils[2] = second;
            pupils[3] = third;
            pupils[4] = fourth;
        }
        public void Show()
        {
            Console.Write("Study\t\tRead\t\t\tWrite\t\tRelax\n");
            for (int i = 1; i <= 4; i++)
            {
                pupils[i].Study(); 
                Console.Write("\t"); 
                pupils[i].Read(); 
                Console.Write("\t"); 
                pupils[i].Write(); 
                Console.Write("\t"); 
                pupils[i].Relax();  
                Console.Write("\n");
            }
        }
    }
    abstract public class Pupil
    {
        abstract public void Study();
        abstract public void Read();
        abstract public void Write();
        abstract public void Relax();
    }
    public class ExcelentPupil : Pupil
    {
        public ExcelentPupil()
        {
            Console.WriteLine("Создан отличный ученик.");
        }
        override public void Study()
        {
            Console.Write("I'm the best");
        }
        override public void Read()
        {
            Console.Write("I read a lot");
        }
        override public void Write()
        {
            Console.Write("I mind my language");
        }
        override public void Relax()
        {
            Console.Write("I need that");
        }
    }
    public class GoodPupil : Pupil
    {
        public GoodPupil()
        {
            Console.WriteLine("Создан нормальный ученик.");
        }
        override public void Study()
        {
            Console.Write("I'm normal");
        }
        override public void Read()
        {
            Console.Write("I read time by time");
        }
        override public void Write()
        {
            Console.Write("I can write");
        }
        override public void Relax()
        {
            Console.Write("I need that");
        }
    }
    public class BadPupil : Pupil
    {
        public BadPupil()
        {
            Console.WriteLine("Создан плохой ученик.");
        }
        override public void Study()
        {
            Console.Write("I don't care");
        }
        override public void Read()
        {
            Console.Write("I don't like read");
        }
        override public void Write()
        {
            Console.Write("For what?");
        }
        override public void Relax()
        {
            Console.Write("That's my lifestyle");
        }
    }
    abstract public class Vehicle
    {
        public Random rnd;
        protected double price, speed;
        protected int year, passagers;
        public abstract void Show();
    }
    class Plane : Vehicle
    {
        int high;
        public Plane()
        {
            rnd = new Random(1);
            price = rnd.Next(1000000, 2000001);
            speed = price / 1000;
            year = rnd.Next(2000, 2017);
            passagers = rnd.Next(10, 100);
            high = rnd.Next(100, 150);
        }
        override public void Show()
        {
            Console.WriteLine("type - plane. price - {0} $, speed - {1}, year - {2}, passagers - {3}, high - {4}", price, speed, year, passagers, high);
        }
    }
    class Car : Vehicle
    {
        public Car()
        {
            rnd = new Random(2);
            price = rnd.Next(1000000, 2000002);
            speed = price / 1000;
            year = rnd.Next(2000, 2017);
            passagers = rnd.Next(10, 100);
        }
        override public void Show()
        {
            Console.WriteLine("type - car. price - {0} $, speed - {1}, year - {2}, passagers - {3}", price, speed, year, passagers);
        }
    }
    class Ship : Vehicle
    {
        string port;
         public Ship()
        {
            rnd = new Random(3);
            price = rnd.Next(1000000, 2000003);
            speed = price / 1000;
            year = rnd.Next(2000, 2017);
            passagers = rnd.Next(10, 100);
            port = "port # " + (rnd.Next(1, 10)).ToString();
        }
         override public void Show()
         {
             Console.WriteLine("type - ship. price - {0} $, speed - {1}, year - {2}, passagers - {3}, port - {4}", price, speed, year, passagers, port);
         }
    }
    class DocumentWorker
    {
        public DocumentWorker()
        {

        }
        void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }
        void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии Про");
        }
        void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии Про");
        }
        public virtual void Show()
        {
            this.OpenDocument();
            this.EditDocument();
            this.SaveDocument();
        }
    }
    class ProDocumentWorker : DocumentWorker
    {
        void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }
        void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }
        void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
        }
        public override void Show()
        {
            this.OpenDocument();
            this.EditDocument();
            this.SaveDocument();
        }
    }
    class ExpertDocumentWorker : ProDocumentWorker
    {
        void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }
        void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }
        void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
        public override void Show()
        {
            this.OpenDocument();
            this.EditDocument();
            this.SaveDocument();
        }
    }
    class taskfororactice
    {
        public static void newline()
        {
            Console.WriteLine();
        }
        public static int ParseInteger(string text, int number)
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
            return number;
        }
        static void Main(string[] args)
        {
            WBPrinter white=new WBPrinter();
            ColourPrinter red=new ColourPrinter();
            int info;
            Console.WriteLine("Введите число, чтобы 'напечатать' его разными принтерами: ");
            info = Convert.ToInt32(Console.ReadLine());
            white.Print(info.ToString());
            red.Print(info.ToString());

            newline();
            Pupil []pupils=new Pupil[5];
            Console.WriteLine("Сколько учеников вы хотите создать? Максимум 4. Недостающих создаст рандом: ");
            int count = 0;
            do
            {
                count = ParseInteger("Введите количество студентов: ", count);
                if (count < 1 || count > 4) Console.WriteLine("От 1 до 4 студентов.");
            } while (count < 1 || count > 4);
            Console.WriteLine("Здесь три вида учеников: отличные, нормальные и плохие, соответственно +1, 0 и -1. Выберите для каждого тип: ");
            int type = 2;
            for (int i = 1; i <= count; i++)
            {
                do
                {
                    Console.WriteLine("Ученик № {0}: ", i);
                    type = Convert.ToInt32(Console.ReadLine());
                    if (type != (1) && type != (0) && type != (-1))
                    {
                        Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                    }
                    else
                    {
                        if (type == 1) pupils[i] = new ExcelentPupil();
                        if (type == 0) pupils[i] = new GoodPupil();
                        if (type == -1) pupils[i] = new BadPupil();
                    }
                } while (type != (1) && type != (0) && type != (-1));  
            }
            if (count < 4)
            {
                Random rnd = new Random();
                for (int i = count+1; i <= 4; i++)
                {
                    type = rnd.Next(0, 2) - 1;
                    if (type == 1) pupils[i] = new ExcelentPupil();
                    if (type == 0) pupils[i] = new GoodPupil();
                    if (type == -1) pupils[i] = new BadPupil();
                }
            }
            ClassRoom myclass = new ClassRoom(pupils[1], pupils[2], pupils[3], pupils[4]);
            myclass.Show();
            newline();
            Plane plane = new Plane();
            Ship ship = new Ship();
            Car car = new Car();
            plane.Show();
            ship.Show();
            car.Show();
            newline();
            DocumentWorker work = new DocumentWorker() ;
            Console.WriteLine("Введите ваш ключ доступа (или ничего, если у вас его нет): ");
            string key;
            key=Console.ReadLine();
            if (key == "pro")
            {
                work = new ProDocumentWorker();
            }
            if (key == "exp")
            {
                work = new ExpertDocumentWorker();
            }
            work.Show();
            Console.WriteLine("Завершение работы программы.");
            Console.ReadLine();
        }
    }
}
