using Microsoft.AspNetCore.Mvc;
using Webdoctruyen.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Webdoctruyen.APIController
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TruyenController : ControllerBase
    {
        ApptruyenContext _context;
        public TruyenController(ApptruyenContext context) {
            _context = context;
        }
        // GET: api/<TruyenController>
        [HttpGet]
        public IEnumerable<Truyen> GetAll()
        {
            return _context.Truyens.ToList();
        }

        // GET api/<TruyenController>/5
        [HttpGet("{id}")]
        public Truyen Get(int id)
        {
            Truyen truyen =  _context.Truyens.FirstOrDefault(p => p.Id == id) ;
            return truyen;
        }

        [HttpGet("Search/{tenTruyen}")]
        public IEnumerable<Truyen> Seach(string tenTruyen)
        {
            List<Truyen> list = _context.Truyens.Where(p => p.Tentruyen.Contains(tenTruyen)).ToList();
            if(list.Count == 0)
            {
                return null;
            }
            return list;
        }

        // POST api/<TruyenController>
        [HttpPost]
        public IActionResult Post([FromBody] Truyen model)
        {
            _context.Truyens.Add(model);
            int status = _context.SaveChanges();
            return Ok(status);
        }

        // PUT api/<TruyenController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Truyen model)
        {
            Truyen truyen = _context.Truyens.FirstOrDefault(p => p.Id == id);
            model.Anh = truyen.Anh;
            if (model.Anh.Equals(""))
            {
                model.Anh = truyen.Anh;
            }
            _context.Truyens.Update(model);
            var status = _context.SaveChanges();
            return Ok(status);
        }

        // DELETE api/<TruyenController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Truyen model = _context.Truyens.FirstOrDefault(p => p.Id==id);
            _context.Truyens.Remove(model);
            var status = _context.SaveChanges();
            return Ok(status);
        }
    }
}
