using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Post
{
    Starter=200,
    Middle=250,
    Elder=300
}
public class Accauntant
{
    public bool AskForBonus(Post worker, int hours)
    {
        if (hours > (int)worker) return true;
        return false;
    }
}

enum Colour :int
{
    Red=1,
    Green,
    Blue,
    White
}
public static class Out
{
   public static void Print(string stroka, int color)
    {
        switch (color)
        {
            case 1: 
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
Console.WriteLine(stroka);
Console.ResetColor();
    }
}

struct Notebook
{
    string model, manufacturer;
    int price;

    public Notebook(string mod, string man, int coins)
    {
        model = mod;
        manufacturer = man;
        price = coins;
    }
    public void Show()
    {
        Console.WriteLine("Записная книга '{0}' от {1} стоит {2} у.е.\n", model, manufacturer, price);
    }
}

struct Train
{
    public string to;
    public int number;
    public DateTime from;

    public Train(string param1, int param2, DateTime param3)
    {
        to = param1;
        number = param2;
        from = param3;
        Console.WriteLine("Поезд занесен в базу");
    }
    
}

class MyClass
{
    public string change;
}
struct MyStruct
{
    public string change;
}


namespace _6structures
{
    class Program
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
        public static int ParseInteger(string text, int number, string date = "no", int mounth=0, int year=0)
        {
            if (date == "year")
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
                    } while (number == 0 || number<1900 || number>2017);

                }
            else if (date == "mounth")
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
                } while (number == 0 || number < 0 || number > 12);

            }
            else if (date=="day")
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
                } while (number == 0 || number < 0 || (year%4==0 && mounth==2 && number > 29) || (year%4!=0 && mounth==2 && number>28) || (mounth!=2 && number>30));
            }
            else
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
                return number;
            
        }

        public static  void SortByNumber(Train[] a, int size)
        {
            bool flag;
            do
            {
                flag = false;
                for (int i = 0; i < size-1; i++)
                {
                    if (a[i].number > a[i + 1].number)
                    {
                        flag = true;
                        Train tmp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = tmp;
                    }
                }
            } while (flag);
        }
        public static void ShowArray(Train[] a, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("Место назначения - {0}, время отправки - {1}, номер - {2}", a[i].to, a[i].from, a[i].number);
            }
        }
        public static void ShowByNumber(Train[] a, int size, int number)
        {
            bool exist = false;
            for (int i = 0; i < size; i++)
            {
                if (a[i].number == number)
                {
                    Console.WriteLine("Место назначения - {0}, время отправки - {1}", a[i].to, a[i].from);
                    exist = true;
                }
            }
            if (!exist)
            {
                Console.WriteLine("К сожалению, в базе нет позда с таким номером.");
            }

        }

        static void ClassTaker(MyClass myclass)
        {
            myclass.change = "изменено";
        }
        static void StructTaker(MyStruct mystruct)
        {
            mystruct.change = "изменено";
        }
        static int CloserParty(DateTime birth)
        {
            DateTime now = DateTime.Now;
            if (birth.Month == now.Month && birth.Day == now.Day)
            {
                return 0;
            }
            if (birth.Month <= now.Month && birth.Day <= now.Day)
            {
                DateTime birthplusone=new DateTime(now.Year + 1, birth.Month, birth.Day);
                TimeSpan lol=birthplusone - now;
                return lol.Days;
            }
            else
            {
                DateTime birthplusone = new DateTime(now.Year, birth.Month, birth.Day);
                TimeSpan lol = birthplusone - now;
                return lol.Days;
            }
        }
        static void Main(string[] args)
        {
            string param1, param2;
            int param3=0;
            Console.WriteLine("Создаем записную книгу.\nВведите название модели: ");
            param1 = Console.ReadLine();
            Console.WriteLine("Введите название производителя: ");
            param2 = Console.ReadLine();

            Notebook mynote= new Notebook(param1, param2, ParseInteger("Введите цену: ", param3));
            mynote.Show();

            Train[] mytrains = new Train[8];
            string to;
            int parse=0;
            Console.WriteLine("Следующая часть программы довольно большая (ввод 8 элементов по 3 поля в каждом)");
            int year = 0, mounth = 0, day = 0;
            if(ParseInteger("Пропустить? (1 - да, ост - нет): ", parse)!=1)
            {
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("Поезд № {0}", i + 1);
                Console.WriteLine("Введите пункт назначения: ");
                to = Console.ReadLine();
               
                year=ParseInteger("Время отправки  - год: ", year, "year");
                mounth=ParseInteger("Время отправки - месяц: ", mounth, "mounth");
                day=ParseInteger("Время отправки - день: ", day, "day", mounth, year);
                mytrains[i] = new Train(to,
                ParseInteger("Введите номер: ", parse),
                    new DateTime(year,
                                 mounth,
                                 day));
            }
            SortByNumber(mytrains, 8);
            ShowArray(mytrains, 8);
            Console.WriteLine("Информацию о позде с каким номером Вы хотите узнать?");
            ShowByNumber(mytrains, 8, ParseInteger(" Введите номер: ", parse));
            }

            MyClass cl = new MyClass();
            MyStruct st = new MyStruct();
            cl.change = "не изменено";
            st.change = "не изменено";
            Console.WriteLine("Поля до вызова методов: класс - {0}, структура - {1}", cl.change, st.change);
            ClassTaker(cl);
            StructTaker(st);
            Console.WriteLine("Поля после вызова методов: класс - {0}, структура - {1}", cl.change, st.change);

            Console.WriteLine("Введите свой день рождения.");
            year = ParseInteger("Год: ", year, "year");
            mounth = ParseInteger("Месяц: ", mounth, "mounth");
            day = ParseInteger("День: ", day, "day", mounth, year);
            Console.WriteLine("До ближайшего дня рождения осталость {0} дней.", CloserParty(new DateTime(year, mounth, day)));

            Console.WriteLine("Введите строку, которую хотите вывести цветом:");
            string outp = Console.ReadLine();
            Console.WriteLine("Введите цвет.");
            Colour mycolour=Colour.White;
            Console.WriteLine("Y - yes, N - no");
            Console.WriteLine("красный?");
            string choose=Console.ReadLine();
            if (choose == "Y" || choose == "y")
            {
                mycolour = Colour.Red;
            }
            else if (choose == "N" || choose == "n")
            {
                Console.WriteLine("зеленый?");
                choose = Console.ReadLine();
                if (choose == "Y" || choose == "y")
                {
                    mycolour = Colour.Green;
                }
                else if (choose == "N" || choose == "n")
                {
                    mycolour = Colour.Blue;
                }
            }
            if (mycolour == Colour.White)
            {
                Console.WriteLine("Вы сделали ошибку во вводе, так что цвет будет белым.");
            }
            Out.Print(outp, (int)mycolour);

            Accauntant worker = new Accauntant();
            Console.WriteLine("Создан новый сотрудник.");
            int hard = 0, hours=0;
            hours = ParseInteger("Сколько часов он проработал за месяц?", hours);
            do{
            hard=ParseInteger("Введите его должность (от 1 до 3): ", hard);
            }while(hard!=1 && hard!=2 && hard!=3);
            string empl="Unknowk yet";
            switch (hard)
            {
                case 1:
                    empl = " Ваш Starter-сотрудник";
                    if (worker.AskForBonus(Post.Starter, hours))
                    {
                        empl += "заслужил премию";
                    }
                    else
                    {
                        empl += "не заслужил премию";
                    };
                    break;
                case 2:
                    empl = "Ваш Middle-сотрудник";
                    if (worker.AskForBonus(Post.Middle, hours))
                    {
                        empl += "заслужил премию";
                    }
                    else
                    {
                        empl += "не заслужил премию";
                    };
                    break;
                case 3:
                    empl = "Ваш Elder-сотрудник";
                    if (worker.AskForBonus(Post.Elder, hours))
                    {
                        empl += "заслужил премию";
                    }
                    else
                    {
                        empl += "не заслужил премию";
                    };
                    break;
            }
            Console.WriteLine(empl);
            
            Console.WriteLine("Программа будет завершена.");
            Console.ReadLine();
        }
    }
}
