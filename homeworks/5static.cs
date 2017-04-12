using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class Calculater
{
    static double a;
    static double b;
    public static double plus(double a, double b)
    {
        return a + b;
    }
    public static double minus(double a, double b)
    {
        return a - b;
    }
    public static double product(double a, double b)
    {
        return a * b;
    }
    public static double division(double a, double b)
    {
        return a / b;
    }
    public static double pow(double a, double b)
    {
        return Math.Pow(a, b);
    }
    public static double log(double a, double b)
    {
        return Math.Log(a, b);
    }
    static Calculater()
    {
        Random rnd = new Random(5);
        a = rnd.Next(0, 10000) / 100;
        b = rnd.Next(0, 10000) / 100;
    }
}
static class Array
{
    static int size;
    static int[] element;
    static Random rnd;

    static Array()
    {
        rnd = new Random();
        size = rnd.Next(6, 12);
        element = new int[size];
        for (int i = 0; i < size; i++)
        {
            element[i] = rnd.Next(-100, 100);
        }
    }
    public static void Method(this bool how)
    {
        for (int i = 0; i < size-1; i++)
        {
            for (int j = 0; j < size-1; j++)
            {
                if ((element[j] > element[j + 1]) && how==true)
                {
                    int temp = element[j];
                    element[j] = element[j + 1];
                    element[j + 1] = temp;
                }
                if ((element[j] < element[j + 1]) && how == false)
                {
                    int temp = element[j];
                    element[j] = element[j + 1];
                    element[j + 1] = temp;
                }
            }
        }
    }
    public static void Show()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write(" " + element[i]);
        }
        Console.WriteLine();
    }
}
static class Str
{
    static string mystr;
    static int len;
    static Str()
    {
        mystr = "абракадабра";
        len = mystr.Length;
        Console.WriteLine("\nСозданная строка: " + mystr);
    }
    public static string Substring(int start, int length)
    {
        string result = "";
        for (int i=0; i<length; i++)
        {
            result += mystr[start+i];
        }
        return result;
    }
    public static int IndexOf(string param)
    {
        if (param.Length > len) { return -1; }
        else if (param.Length == len && param != mystr) { return -1; }
        else
        {
            for (int i = 0; i <= len-param.Length; i++)
            {
               bool suc = true;

                for (int j = 0; j < param.Length; j++)
                {
                    if (mystr[i + j] != param[j])
                    {
                        suc = false;
                    }
                }
                if (suc == true) { return i; }
            }
            return -1;
        }
    }
    public static string Replace(string oldv, string newv)
    {
        string result="";
        for (int i = 0; i <= len - newv.Length; i++)
        {
            if (Substring(i, newv.Length) == oldv)
            {
                result += newv;
                i += newv.Length-1;
            }
            else
            {
                result += mystr[i];
            }
        }
        return result;
    }
}

namespace _5static
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
        static void Main(string[] args)
        {
            double a=0, b=0;
            Console.WriteLine("Введите два числа работы калькулятора.");
            a = ParseDouble("Первое: ", a);
            b = ParseDouble("Второе: ", b); 

            Console.WriteLine("Презентация работы калькулятора:\n+={0}\n-={1}\n*={2}\n/={3}\n^={4}\nlog={5}", 
                Calculater.plus(a, b), 
                Calculater.minus(a, b), 
                Calculater.product(a, b), 
                Calculater.division(a, b), 
                Calculater.pow(a, b), 
                Calculater.log(a, b));

            Console.WriteLine("Изначальный массив:");
            Array.Show();
            Array.Method(true);
            Console.WriteLine("Отсортирован по возростанию:");
            Array.Show();
            Array.Method(false);
            Console.WriteLine("Отсортирован по убыванию:");
            Array.Show();

            Console.WriteLine("Пять символов, начиная со второго: " + Str.Substring(2, 5));
            Console.WriteLine("Вхождение када начинается на символе: " + Str.IndexOf("када"));
            Console.WriteLine("Замена букв абра на ЯМОК: " + Str.Replace("абра", "ЯМОК"));
            Console.WriteLine("Программа будет завершена.");
            Console.ReadLine();
        }
    }
}
