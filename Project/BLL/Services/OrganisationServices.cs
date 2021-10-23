using Project.UnitOfWork;
using Project.BLL.Services.IServiceIntefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Services
{
    class OrganisationServices : IOrganisationServices
    {
        private readonly IUnitOfWork _uow;
        public OrganisationServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
