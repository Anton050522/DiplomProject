using RailDBProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services.IServiceIntefaces
{
    public interface IGlobalSectionServices
    {
        public GlobalSection UpdateGlobalSection(GlobalSection globalSection);
        public IQueryable<GlobalSection> GetQuarable();
        public List<GlobalSection> GetGlobalSectionList();
        public GlobalSection GetById(int id);
        public void DeleteGlobalSection(GlobalSection globalSection);
        public void CreateGlobalSection(GlobalSection globalSection);
    }
}
