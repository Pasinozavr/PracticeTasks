using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7delegate
{
    class Program
    {
        delegate int MyDelegate(Number[]a);
        delegate double Operation(int a, int b, int c);
        delegate double Mathem(int a, int b);
        delegate int Number();
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
        static double Add(int a, int b) { return a + b; }
        static double Sub(int a, int b) { return a - b; }
        static double Mul(int a, int b) { return a * b; }
        static double Div(int a, int b) {
            if (b != 0) return a / b;
            else return 1;
        }
        static int create_number() { Random rnd = new Random(2); return rnd.Next(-100, 100); }
        static int av(Number[] a) { 
            int i = 0; 
            foreach (Number q in a)
            {
                i += q.Invoke();
            }
            return i;
        }
        static void Main(string[] args)
        {
            Operation average;
            average = delegate(int a, int b, int c) { return (double)(a + b + c) / 3; };
            Console.WriteLine("Введите три числа для вычисления среднего арифметического:");
            int x = 0, y = 0, z = 0;
            x = ParseInteger("Введите первое число: ", x);
            y = ParseInteger("Введите второе число: ", y);
            z = ParseInteger("Введите третье число: ", z);
            Console.WriteLine("Среднее арифметическое равно {0}", average(x,y,z));

            Mathem sum = new Mathem(Add);
            Mathem sub = new Mathem(Sub);
            Mathem mul = new Mathem(Mul);
            Mathem div = new Mathem(Div);

            Console.WriteLine("Введите два числа для выполнения арифметических операций:");
            x = ParseInteger("Введите первое число: ", x);
            y = ParseInteger("Введите второе число: ", y);
            char s='1';
            do
            {
                Console.WriteLine("Введите операцию: + - * или /. Для завершения - введите 0");
                s = Convert.ToChar(Console.ReadLine());
                switch (s)
                {
                    case '+':
                        Console.WriteLine("Сумма равна {0}", sum(x,y));
                        break;
                    case '-':
                        Console.WriteLine("Разность равна {0}", sub(x, y));
                        break;
                    case '*':
                        Console.WriteLine("Произведение равно {0}", mul(x, y));
                        break;
                    case '/':
                        Console.WriteLine("Рнзкльтпт деление равен {0}", div(x, y));
                        break;
                    case '0':
                        Console.WriteLine("Вы выбрали завершение.");
                        break;
                    default:
                        Console.WriteLine("Вы ввели некорректный символ. Попробуйте еще раз.");
                        break;
                }
            } while (s != '0');

            Number[] random_number = new Number[10];
            for (int i = 0; i < 10; i++) { random_number[i] = new Number(create_number); }
            MyDelegate summa = new MyDelegate(av);
            Console.WriteLine("Sum={0}", summa(random_number));
            Console.WriteLine("Программа будет завершена.");
            Console.Read();
        }
    }
}
