using RailDBProject.Model;
using System;

namespace ConsoleApplication
{
    class Program
    {

        public static T UserInput<T>()
        {
            var type = typeof(T);
            var insiders = (T)Activator.CreateInstance(type);

            foreach (var item in type.GetProperties())
            {
                Console.WriteLine($"Введите {item.Name}");
                var p = Console.ReadLine();
                item.SetValue(insiders, p);
            }
            return insiders;
        }
        static void Main(string[] args)
        {
            UserInput<User>();
        }
    }
}
