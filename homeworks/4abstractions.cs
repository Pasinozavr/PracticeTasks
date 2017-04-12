using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 


namespace _4abstractions 
{ 
abstract class AbstractHandler 
{ 
public abstract void Open(); 
public abstract void Create(); 
public abstract void Change(); 
public abstract void Save(); 
} 
class XMLHandler : AbstractHandler 
{ 
public override void Open() 
{
    Console.WriteLine(" XML file open ");
} 
public override void Create() 
{
    Console.WriteLine(" XML file created ");
} 
public override void Change() 
{
    Console.WriteLine(" XML file changed ");
} 
public override void Save() 
{
    Console.WriteLine(" XML file saved ");
} 
} 
class TXTHandler : AbstractHandler 
{
    public override void Open()
    {
        Console.WriteLine(" TXT file open ");
    }
    public override void Create()
    {
        Console.WriteLine(" TXT file created ");
    }
    public override void Change()
    {
        Console.WriteLine(" TXT file changed ");
    }
    public override void Save()
    {
        Console.WriteLine(" TXT file saved ");
    } 
} 
class DOCHandler : AbstractHandler 
{
    public override void Open()
    {
        Console.WriteLine(" DOC file open ");
    }
    public override void Create()
    {
        Console.WriteLine(" DOC file created ");
    }
    public override void Change()
    {
        Console.WriteLine(" DOC file changed ");
    }
    public override void Save()
    {
        Console.WriteLine(" DOC file saved ");
    } 
}

public interface IPlayable
{
    void Play();
    void Pause();
    void Stop();
}
public interface IRecodable
{
    void Record();
    void Pause();
    void Stop();
}
public class Player : IPlayable, IRecodable
{
    public void Pause(){
        Console.WriteLine("Работа остановлена.");
}
    public void Play()
    {
        Console.WriteLine("Идет воспроизведение.");
    }
    public void Record()
    {
        Console.WriteLine("Идет запись.");
    }
    public void Stop()
    {
        Console.WriteLine("Работа прекращена.");
    }
    public void Work()
    {
        Record();Pause();Record();Stop();

        Play();Pause();Record();Stop();
    }
}
class Program 
{ 
static void Main(string[] args) 
{
    Console.WriteLine("Введите название файла с расширением (.???)");
    string[] myarray = Console.ReadLine().Split('.');
    string format = myarray[myarray.Length - 1];
    myarray = null;
    Console.WriteLine("Расширение вашего файла - " + format);
    AbstractHandler my = new XMLHandler();
    bool known = true;
    switch (format)
    {
        case "xml": 
            my = new XMLHandler();
            break;
        case "doc": 
            my = new DOCHandler();
            break;
        case "txt": 
            my = new TXTHandler();
            break;
        default:
            Console.WriteLine("К сожалению, для вашего формата не описаны действия");
            my = null;
            known = false;
            break;
    }
    if (known)
    {
        my.Create();
        my.Open();
        my.Change();
        my.Save();
    }

    Player myplayer = new Player();
    myplayer.Work();

Console.WriteLine("Программа будет завершена."); 
Console.ReadLine(); 
} 
} 
}