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


        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var records = _db.Set<Product>().ToList();
            if(records != null)
            {
                return Ok(records);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<Product>> GetById(int id)
        {
            var records = _db.Set<Product>().Find(id); 
           return records != null ? Ok(records) : NotFound(); 
        }

        [HttpPost]
        [Route("")]
        public ActionResult<int> CreateProduct(Product product)
        {
            product.Id = 0;
            _db.Set<Product>().Add(product);
           _db.SaveChanges();
            return Ok(product.Id);
        }

        [HttpPut]
        [Route("")]
        public ActionResult<int> UpdataProduct(Product product)
        {
            var existingProduct = _db.Set<Product>().Find(product.Id);
            existingProduct.Name = product.Name;
            existingProduct.Sku = product.Sku;
            _db.Set<Product>().Update(existingProduct);
            _db.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<int> DeleteProduct(int id)
        {
            var existingProduct = _db.Set<Product>().Find(id); 
            _db.Set<Product>().Remove(existingProduct);
            _db.SaveChanges();
            return Ok();
        }
    }
}
