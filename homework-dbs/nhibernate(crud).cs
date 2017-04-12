using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateBasics
{
    public class Employee
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        { 
Configuration myConfiguration;
ISessionFactory mySessionFactory;
ISession mySession;

Employee[] myInitialObjects;
Employee[] myFinalObjects;


myInitialObjects = new Employee[2];
myFinalObjects = new Employee[2];

myConfiguration = new Configuration();
myConfiguration.Configure();
mySessionFactory = myConfiguration.BuildSessionFactory();
mySession = mySessionFactory.OpenSession();

Employee jack = new Employee();
jack.Name = "Jack";
myInitialObjects[0] = jack;

Employee jill = new Employee();
jill.Name = "Jill";
myInitialObjects[1] = jill;

using (mySession.BeginTransaction())
{
    mySession.Save(myInitialObjects[0]);
    mySession.Save(myInitialObjects[1]);
    mySession.Transaction.Commit();
} 
string messageString = "";
         
using (mySession.BeginTransaction())
{
    mySession.Delete(myInitialObjects[0]);
    mySession.Transaction.Commit();
}
using (mySession.BeginTransaction())
{
     ICriteria criteria = mySession.CreateCriteria<Employee>();
     IList<Employee> list = criteria.List<Employee>();
     messageString = "";
     // Load and display the data
     foreach (Employee employee in list)
     {
         messageString+="ID: " + employee.ID + " Name: " + employee.Name;
     }
     Console.WriteLine(messageString.ToString());
}
            Console.Read();
        }
    }
}
