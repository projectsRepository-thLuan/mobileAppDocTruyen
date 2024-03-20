using Microsoft.AspNetCore.Mvc;
using Webdoctruyen.Models;

namespace Webdoctruyen.Controllers
{
    public class TaikhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public Taikhoan Login(string username,string password)
        {
            Taikhoan u = new Taikhoan();
            return u;
        }
    }
}
