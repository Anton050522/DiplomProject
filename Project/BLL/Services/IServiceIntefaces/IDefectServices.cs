using System;
using System.Collections.Generic;
using Project.Models;

namespace Project.BLL.Services.IServiceIntefaces
{
    public interface IDefectServices
    {
        public List<Defect> GetDetectedByMonth(int month);
        public List<Defect> GetDeletedByMonth(int month);
        public List<Defect> GetAll();
        public List<Defect> GetAllWithAcsess(int grgId, int globalId, int LocalId, Enum role);
        //переделать метод ГетАлл исходя из ролей пользователей
    }
}
