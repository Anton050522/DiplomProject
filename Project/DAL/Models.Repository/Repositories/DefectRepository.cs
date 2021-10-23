using Project.DAL.Models;
using Project.Models.Repository.Interfaces;
using Project.RepositoryPattern;
using System;

namespace Project.Models.Repository.Repositories
{
    public class DefectRepository : Repository<Defect>, IDefectRepository
    {
        public DefectRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }
        
        public override void Create(Defect defect)
        {
            defect.IsDeleted = false;
            defect.DateOfDetection = DateTime.Now;
            _context.Update(defect);
        }
        public override void Delete(Defect defect)
        {
            DefectAudit defectTransfer = new DefectAudit(); // В случае удаления архивирования убрать
            defectTransfer = defect; // В случае удаления архивирования убрать
            defect.IsDeleted = true;
            _context.Update(defect);
            _context.Update(defectTransfer); // В случае удаления архивирования убрать
        }
               
        public void DeleteById(int id)
        {
            var entity = _context.Defects.Find(id);
            DefectAudit defectTransfer = new DefectAudit(); // В случае удаления архивирования убрать
            defectTransfer = entity; // В случае удаления архивирования убрать
            entity.IsDeleted = true;
            _context.DefectAudits.Add(defectTransfer);// В случае удаления архивирования убрать
            _context.Update(entity);
        }
    }
}
