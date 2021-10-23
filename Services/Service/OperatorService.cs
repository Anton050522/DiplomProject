using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using RailDBProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Service
{
    public class OperatorService : IOperatorServices
    {
        private readonly IUnitOfWork _uow;
        public OperatorService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateOperator(Operator @operator)
        {
            _uow.Operators.Create(@operator);
            _uow.SaveChanges();
        }

        public void DeleteOperator(Operator @operator)
        {
            
            _uow.Operators.Delete(@operator);
            _uow.SaveChanges();
        }

        public List<Operator> GetAllOpp()
        {
            return _uow.
                Operators.ReadAll().ToList();
        }

        public Operator GetById(int _id)
        {
            return _uow.Operators.Read(_id);
        }

        public List<Operator> GetOperatorList()
        {
            return _uow.Operators.ReadAll().ToList();
        }

        public IQueryable<Operator> GetQuarable()
        {
            return _uow.Operators.ReadAll();
        }

        public Operator UpdateOperator(Operator @operator)
        {
            _uow.
                Operators.
                Update(@operator);
            _uow.SaveChanges();
            return @operator;
        }
    }
}
