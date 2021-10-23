using Project.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Models.Repository.Interfaces
{
    public interface IDefectRepository : IRepository<Defect>
    {
        public void DeleteById(int id);
    }

}
