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

       return Products.First(p => p.Code == code);
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
        var p = Products.First(p => p.Code == code);


        Products.Remove(p);


    }
}

