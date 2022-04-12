using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;
using OrderAPI.Data;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly APIContext _context;   

        public OrderController(APIContext context) { _context = context; }

        //Create / Edit
        [HttpPost]
        public JsonResult CreateEdit(Order order)
        {
            if(order.Id == 0)
            {
                _context.Orders.Add(order); 
            }
            else
            {
                var orderInDb=_context.Orders.Find(order.Id);
                if(orderInDb == null)
                    return new JsonResult(NotFound());
                orderInDb = order;
            }

            _context.SaveChanges();
            return new JsonResult(Ok(order));
        }

        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result=_context.Orders.Find(id);
            if(result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Orders.Find(id);
            if(result == null)
                return new JsonResult(NotFound());

            _context.Orders.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent()); 

        }

        //Getting All
        [HttpGet()]
        public JsonResult GetAll()
        {
            var result=_context.Orders.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
