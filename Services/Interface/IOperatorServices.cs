using RailDBProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services.IServiceIntefaces
{
    public interface IOperatorServices
    {
        public Operator UpdateOperator(Operator @operator);
        public List<Operator> GetAllOpp();
        public Operator GetById(int id);
        public void DeleteOperator(Operator @operator);
        public void CreateOperator(Operator @operator);
        public IQueryable<Operator> GetQuarable();
        public List<Operator> GetOperatorList();
    }
}
