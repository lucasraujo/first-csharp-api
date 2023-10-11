using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();


app.MapGet("/test", () => {
    return  listProduct.ListAll();
});

app.MapPost("/", (Product product ) => {
    return listProduct.add(product);
});

app.MapGet("/{code}", ([FromRoute] string code) => {
    Product res = listProduct.GetBy(code);
    if(res == null) { 
        Results.NotFound();
    }
    Results.Ok(res);
});

app.MapDelete("/{code}", ([FromRoute] string code) => {
     listProduct.DeleteProduct(code);
});

app.Run();


public static class listProduct { 

    public static List<Product> Products {get; set;}

    public static Product add(Product product) { 
        if(Products == null){ 
            Products = new List<Product>();
        }

        Products.Add(product);
        return product;
    }

    public static Product GetBy(string code ){ 
        if(Products == null){ 
            Products = new List<Product>();
        }

       return Products.First(p => p.code == code);
    }

    public static List<Product> ListAll(){ 
        if(Products == null){ 
            Products = new List<Product>();
        }
        
        return Products;

    }

    public static void DeleteProduct(string code){
        if(Products == null){ 
            Products = new List<Product>();
        }
        var p = Products.First(p => p.code == code);


        Products.Remove(p);


    }
}


public class Product {

    public int  Id {get; set;}
    public string name {get; set;}

    public string code {get; set;}


};


public class ApplicationDbContext : DbContext {

    public DbSet<Product> Products {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer(
        "Server=localhost; Database=products; User Id=sa; Password=@flatron1522; MultipleActiveResultSets=True; Encrypt=YES; TrustServerCertificate=YES");
}
