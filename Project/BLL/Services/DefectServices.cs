using Project.BLL.Services.IServiceIntefaces;
using Project.Models;
using Project.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services
{
    public class DefectServices : IDefectServices
    {
        private readonly IUnitOfWork _uow;
        public DefectServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public List<Defect> GetAll()
        {

            return _uow.Defects
                  .ReadAll().Where(d => d.IsDeleted == false).ToList();
        }
        public List<Defect> GetDetectedByMonth(int month)
        {
            return
             _uow.Defects
                .ReadAll()
                .Where(u => u.DateOfDetection > DateTime.Now.AddMonths(-month))
                .Where(d => d.IsDeleted == false)
                .ToList();
        }

        public List<Defect> GetDeletedByMonth(int month)
        {
            return
             _uow.Defects
                .ReadAll()
                .Where(u => u.DateOfDetection > DateTime.Now.AddMonths(-month))
                .Where(d => d.IsDeleted == true)
                .ToList();
        }

        public List<Defect> GetAllWithAcsess(int OrgId, int GlobalId, int LocalId, Enum role)
        {
            Coordinate coor = new Coordinate();
            var result = _uow.Defects.ReadAll();
            foreach (var res in result)
            {
                //res.Co
                //    coor = res.Coordinate
            }
            //var result = _uow.Defects.ReadAll().Join(_uow.Coordinates.ReadAll(), c => c.Coordinate.Id == _uow.Defects.)
            throw new NotImplementedException();
        }
    }
}
