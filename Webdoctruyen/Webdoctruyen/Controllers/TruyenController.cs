using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Security.Policy;
using Webdoctruyen.Models;

namespace Webdoctruyen.Controllers
{
    public class TruyenController : Controller
    {   
        ApptruyenContext _context;
        public TruyenController(ApptruyenContext context)
        {
            _context =  context; 
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Truyen truyen, IFormFile Anh)
        {
            if (Anh != null && Anh.Length > 0)
            {
                // Xác định đường dẫn lưu trữ ảnh
                var uploadFolderPath = Path.Combine("wwwroot", "upload", "image");
                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }
                var filePath = Path.Combine(uploadFolderPath, Anh.FileName);

                // Lưu trữ ảnh vào máy chủ
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Anh.CopyToAsync(stream);
                }

                // Lưu đường dẫn của ảnh vào truyện
                truyen.Anh = "/upload/image/" + Anh.FileName; // Đảm bảo đường dẫn này phù hợp với cách hiển thị ảnh trong mã HTML
            }
            if (!ModelState.IsValid)
            {
               
                _context.Truyens.Add(truyen);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(truyen);
        }
        public async Task<IActionResult> Edit(int id)
        {
            Truyen model = await _context.Truyens.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Truyen truyen, IFormFile Anh)
        {
            if (!ModelState.IsValid)
            {
                Truyen model = await _context.Truyens.FirstOrDefaultAsync(p => p.Id == truyen.Id);
                if (model == null)
                {
                    return BadRequest();
                }

                if (Anh != null && Anh.Length > 0)
                {
                    // Xác định đường dẫn lưu trữ ảnh
                    var uploadFolderPath = Path.Combine("wwwroot", "upload", "image");
                    if (!Directory.Exists(uploadFolderPath))
                    {
                        Directory.CreateDirectory(uploadFolderPath);
                    }
                    var filePath = Path.Combine(uploadFolderPath, Anh.FileName);

                    // Lưu trữ ảnh vào máy chủ
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Anh.CopyToAsync(stream);
                    }

                    // Lưu đường dẫn của ảnh vào truyện
                    truyen.Anh = "/upload/image/" + Anh.FileName; // Đảm bảo đường dẫn này phù hợp với cách hiển thị ảnh trong mã HTML
                }
                else
                {
                    truyen.Anh = model.Anh;
                }

                // Update the model with the new values
                model.Tentruyen = truyen.Tentruyen;
                model.Noidung = truyen.Noidung;
                model.IdTk = truyen.IdTk;
                model.Anh = truyen.Anh;

                // Save changes to the database
                _context.Truyens.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(truyen);
        }

        public async Task<IActionResult> AddVoiceTruyen(int id)
        {
            Truyen model = await _context.Truyens.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        public class Response
        {
            public string async { get; set; }
            public int error { get; set; }
            public string message { get; set; }
            public string requestId { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> AddVoiceTruyen(Truyen truyen)
        {
            string urlMP3 = "";
  
            Truyen model = await _context.Truyens.FirstOrDefaultAsync(x=>x.Id == truyen.Id);
            String result = Task.Run(async () =>
            {
                String payload = truyen.Noidung;
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("api-key", "YlnQWFjysuLxu6ecepDbZsG1YlrM2t2g");
                client.DefaultRequestHeaders.Add("speed", "");
                client.DefaultRequestHeaders.Add("voice", "banmai");
                var response = await client.PostAsync("https://api.fpt.ai/hmi/tts/v5", new StringContent(payload));
                return await response.Content.ReadAsStringAsync();

            }).GetAwaiter().GetResult();

            var responseObject = JsonConvert.DeserializeObject<Response>(result);

            
            truyen.Noidung = model.Noidung;
            truyen.Voice = responseObject.async;
            _context.Truyens.Update(truyen);
             _context.SaveChanges();
            Console.WriteLine(responseObject.async);
            return RedirectToAction("Index");
        }

    }

    
}
