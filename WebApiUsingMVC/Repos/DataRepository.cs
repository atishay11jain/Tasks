using MySql.Data.MySqlClient;
using WebApiUsingMVC.LogicCodeBase;
using WebApiUsingMVC.Models;
using Dapper;

namespace WebApiUsingMVC.Repos;


public class DataRepository{

   public static List<ProductModel> GetProductData(string brand, string category, int minPrice, int maxPrice, string connectionString){
       MySqlConnection conn = new MySqlConnection(connectionString);
       string query = DataFetching.getAllProducts_Query(brand,category,minPrice,maxPrice);
       var prds = conn.Query<ProductModel>(query);
       return prds.ToList();
   }

   public static List<ProductModel> GetProductImages(string brand, string category, int minPrice, int maxPrice, string connectionString,List<ProductModel> pm){
      MySqlConnection con = new MySqlConnection(connectionString);
        List<int> prdIds = new List<int>();
        
        for(int i = 0;i<pm.Count();i++){
             var products = con.Query<ProductImageModel>("SELECT * FROM prdimages_atishay WHERE id = " + pm[i].Id);
             List<string> imagesUrl = ConvertObjecttoList(products.ToList());
             pm[i].images = imagesUrl;
        }

        
       return pm;
   }

   public static List<ProductModel> ResultantData(string brand,string category,int minPrice,int maxPrice,string connectionString){
      List<ProductModel> prdData = GetProductData(brand,category,minPrice,maxPrice,connectionString);
      List<ProductModel> data = GetProductImages(brand,category,minPrice,maxPrice,connectionString,prdData);    
       return data;
   }


 public static List<string> ConvertObjecttoList(List<ProductImageModel> imageModel)
    {
        List<string> imagesList = new List<string>();
        for(int i = 0;i<imageModel.Count();i++){
            imagesList.Add(imageModel[i].imageUrl);
        }

        return imagesList;

    }
}