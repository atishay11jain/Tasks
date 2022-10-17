namespace WebApiUsingMVC.LogicCodeBase{


public class DataFetching{

public static string getAllProducts_Query(string brand, string category, int minPrice, int maxPrice){
   string query = "";
   string tempquery = "SELECT * FROM products_atishay WHERE ";
   query = filterQuery(tempquery,brand,category,minPrice,maxPrice);
   if(query == ""){
     query = "SELECT * FROM products_atishay";
   }

   return query;
}


public static string filterQuery(string query,string brand,string category,int minPrice,int maxPrice){
  if(brand.Length != 0){
    query = query + $"brand IN ({brand})";
  }
  if(category.Length != 0){
    if(brand.Length != 0)  query = query + $" AND category IN ({category})";
    else query = query + $" category IN ({category})";
  }
  if(minPrice != 0 && maxPrice != 0){
    if(brand.Length != 0 || category.Length != 0) query = query + $" AND price BETWEEN {minPrice} AND {maxPrice}";
    else query = query + $" price BETWEEN {minPrice} AND {maxPrice}";
  }

  if(brand.Length == 0 && category.Length == 0 && minPrice == 0 && maxPrice == 0) query="";
  
  return query;
}

}

}