using Microsoft.AspNetCore.Mvc;
using WebApi1.Models;

namespace WebApi1.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController : ControllerBase{
 
 private readonly mobile_showroomContext dbContext;

 public ProductController(mobile_showroomContext dbcontxt){
   this.dbContext = dbcontxt;
 }

[HttpGet("getAll")]
 public IActionResult get(){
  var product = this.dbContext.Products.ToList();
  
  return Ok(product);
 }

 [HttpGet("brand/{bname}")]
public IActionResult getByBrandName(string bname){
   var product = this.dbContext.Products.Where(o => o.Brand==bname);
   return Ok(product);
}
 
 [HttpGet("category/{cname}")]
public IActionResult getByCategory(string cname){
   var product = this.dbContext.Products.Where(o => o.Category==cname);
   return Ok(product);
}

 [HttpGet("price")]
public IActionResult getByPrice(int min,int max){
   var product = this.dbContext.Products.Where(o => (o.Price>=min && o.Price<=max));
   return Ok(product);
}

}