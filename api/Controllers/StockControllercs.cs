using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockControllercs : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockControllercs(ApplicationDBContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stock.ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stock.Find(id);
            
            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }
    }
}
