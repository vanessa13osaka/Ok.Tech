using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ok.Tech.Api.Models;

namespace Ok.Tech.Api.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProductViewModel>> GetProducts()
        {
            return Ok(new List<ProductViewModel>());
        }
    }
}
