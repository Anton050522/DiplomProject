using RailDBProject.Repository.Interface;
using RailDBProject.Repository.Repository;
using System;

namespace RailDBProject.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RailDBContext _context;
        public UnitOfWork(RailDBContext context)
        {
            _context = context;
        }

        public IDefectRepository _defects;
        public IDefectRepository Defects
        {
            get => _defects == null ? _defects = new DefectRepository(_context) : _defects;
        }

        public IGlobalSectionRepository _globalSections;
        public IGlobalSectionRepository GlobalSections
        {
            get => _globalSections == null ? _globalSections = new GlobalSectionRepository(_context) : _globalSections;
        }

        public ILocalSectionRepository _localSections;
        public ILocalSectionRepository LocalSections
        {
            get => _localSections == null ? _localSections = new LocalSectionRepository(_context) : _localSections;
        }

        public IOrganisationRepository _organisations;
        public IOrganisationRepository Organisations
        {
            get => _organisations == null ? _organisations = new OrganisationReporitory(_context) : _organisations;
        }

        public IUserRepository _users;
        public IUserRepository Users
        {
            get => _users == null ? _users = new UserRepository(_context) : _users;
        }

        public IOperatorRepository _operators;
        public IOperatorRepository Operators
        {
            get => _operators == null ? _operators = new OperatorRepository(_context) : _operators;
        }

        public IDefectoScopeRepository _defectoscopes;
        public IDefectoScopeRepository DefectoScopes
        {
            get => _defectoscopes == null ? _defectoscopes = new DefectoScopeRepository(_context) : _defectoscopes;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
