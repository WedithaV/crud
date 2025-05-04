using api.Data;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;

namespace api.Controllers
{
    [Route("api/stocks")] //Defines the URL route to access this controller
    [ApiController] //Helps automatically handle things like model validation and routing.
    public class StockControllers : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public StockControllers(ApplicationDBContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stock.ToList().Select(s => s.ToStockDto());
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

            return Ok(stock.ToStockDto());
        }
    }
}
