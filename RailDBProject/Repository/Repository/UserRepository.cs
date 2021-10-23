using RailDBProject.Model;
using RailDBProject.Repository.Interface;

namespace RailDBProject.Repository.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }

        public override void Delete(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
