using System.Text;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Webdoctruyen.Controllers
{
    public class HomeController : Controller
    {
         private const string ApiKey = "binh123";
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DownloadMp3(string url)
        {
            // Tạo client HTTP
            using (var client = new HttpClient())
            {
                // Gửi yêu cầu GET đến URL file mp3
                var response = await client.GetAsync(url);

                // Kiểm tra trạng thái phản hồi
                if (response.IsSuccessStatusCode)
                {
                    // Lấy nội dung file mp3
                    var content = await response.Content.ReadAsByteArrayAsync();

                    // Lưu file vào thư mục gốc
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/voice", "file1.mp3");
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await stream.WriteAsync(content, 0, content.Length);
                    }

                    // Tạo URL cho file mp3
                    url = Url.Content("~/wwwroot/voice/file.mp3");

                    // Lưu trữ URL để sử dụng sau này
                    // ...

                    // Trả về kết quả thành công
                    return Ok("File mp3 đã được lưu thành công!");
                }

                // Trả về kết quả thất bại
                return BadRequest("Lỗi khi lưu file mp3!");
            }
        }
    }
}
