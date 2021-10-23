using RailDBProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services.IServiceIntefaces
{
    public interface ILocalSectionServices
    {
        public LocalSection UpdateLocalSection(LocalSection localSection);
        public IQueryable<LocalSection> GetQuarable();
        public List<LocalSection> GetLocalSectionList();
        public LocalSection GetById(int id);
        public void DeleteLocalSection(LocalSection localSection);
        public void CreateLocalSection(LocalSection localSection);
    }
}
