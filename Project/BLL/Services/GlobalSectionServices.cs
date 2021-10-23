using Project.BLL.Services.IServiceIntefaces;
using Project.Models;
using Project.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Services
{
    class GlobalSectionServices : IGlobalSectionServices
    {
        private readonly IUnitOfWork _uow;
        public GlobalSectionServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
