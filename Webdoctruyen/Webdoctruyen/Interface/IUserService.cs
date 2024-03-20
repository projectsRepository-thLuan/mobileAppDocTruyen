using Webdoctruyen.Models;

namespace Webdoctruyen.Interface
{
    public interface IUserService
    {
        Taikhoan Authenticate(string username, string password);

    }

    public class UserService : IUserService
    {
        ApptruyenContext _context;
        public UserService(ApptruyenContext context)
        {
            _context = context;
        }

        public Taikhoan Authenticate(string username, string password)
        {
             List<Taikhoan> _users = _context.Taikhoans.ToList();
             var user = _users.SingleOrDefault(x => x.Tentaikhoan == username && x.Matkhau == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful
            return user;
        }
    }
}
