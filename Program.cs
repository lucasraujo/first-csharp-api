using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["Database:SqlServer"]);
var app = builder.Build();


app.MapGet("/test", () => {
    return  listProduct.ListAll();
});

app.MapPost("/", (ProductRequest productRequest, ApplicationDbContext context ) => {

    var category = context.Category.Where(c => c.Id == productRequest.CategoryId).First();
    var product = new Product{ 
        Name = productRequest.Name,
        Code = productRequest.Code,
        Category = category
    };

    context.Products.Add(product);
    context.SaveChanges();
    return Results.Created($"/{product.Id}", product.Id );

   
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
