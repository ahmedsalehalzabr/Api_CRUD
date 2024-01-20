using Api_Code.Data;
using Api_Code.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;

        [HttpPost]
        [Route("")]
        public ActionResult<int> CreateProduct(Product product)
        {
            product.Id = 0;
            _db.Set<Product>().Add(product);
           _db.SaveChanges();
            return Ok(product.Id);
        }
    }
}
