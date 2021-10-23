using Project;
using Project.Models;
using Project.UnitOfWork;
using System;
using Project.RepositoryPattern;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Organisation org = new Organisation();
            org.OrgName = "Управление БелЖД";
            //org.UserId = 1;


            using (var UnitOfWork = new UnitOfWork(new RailDBContext()))
            {
                UnitOfWork.Defects.DeleteById(1);
                UnitOfWork.SaveChanges();
            }


        }
    }
}
