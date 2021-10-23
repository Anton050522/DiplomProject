using Project.DAL.Models.Repository.Interfaces;
using Project.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace Project.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDefectRepository Defects { get; }
        IGlobalSectionRepository GlobalSections { get; }
        ICoordinateRepository Coordinates { get; }
        ILocalSectionRepository LocalSections { get; }
        IOrganisationRepository Organisations { get; }
        IUserRepository Users { get; }
        IDefectAuditRepository DefectAudits { get; }
        public int SaveChanges();
    }
}
