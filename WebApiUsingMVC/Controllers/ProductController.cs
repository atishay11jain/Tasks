using Microsoft.AspNetCore.Mvc;
using WebApiUsingMVC.Repos;
using Newtonsoft.Json;
using PagedList;
using WebApiUsingMVC.Models;

namespace WebApiUsingMVC.Controllers;

public class ProductController: Controller{

  private readonly ILogger<ProductController> _logger;
   private readonly IConfiguration _Config;


   public ProductController(ILogger<ProductController> logger,IConfiguration config){
         _logger = logger;
         this._Config = config;
   }


   public string GetAll(string? brand="", string category="",int minPrice=0, int maxPrice=0,int page = 1){
      int pageSize = 6;
      int pageIndex = 1;
      pageIndex = Convert.ToInt32(page);
      string connectionString = _Config.GetValue<string>("ConnectionStrings:default");
      var data = DataRepository.ResultantData(brand,category,minPrice,maxPrice,connectionString);
      IPagedList<ProductModel> list = data.ToPagedList(pageIndex,pageSize);
      var json = JsonConvert.SerializeObject(list);

      return json;
   }

}



/////////////////////////////////////////////////////////////////////



