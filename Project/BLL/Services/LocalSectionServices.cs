using Project.UnitOfWork;
using Project.BLL.Services.IServiceIntefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Services
{
    class LocalSectionServices : ILocalSectionServices
    {
        private readonly IUnitOfWork _uow;
        public LocalSectionServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
