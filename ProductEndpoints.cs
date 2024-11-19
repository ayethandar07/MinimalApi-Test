using MinimalApiTest.Model;
using MinimalApiTest.Service;

namespace MinimalApiTest;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/products", (IProductService productService) =>
        {
            return Results.Ok(productService.GetAllProducts());
        });

        app.MapGet("/products/{id}", (int id, IProductService productService) =>
        {
            var product = productService.GetProductById(id);
            return product is not null ? Results.Ok(product) : Results.NotFound();
        });

        app.MapPost("/products", (Product product, IProductService productService) =>
        {
            productService.CreateProduct(product);
            return Results.Created($"/products/{product.Id}", product);
        });

        app.MapPut("/products/{id}", (int id, Product updatedProduct, IProductService productService) =>
        {
            if (id != updatedProduct.Id) return Results.BadRequest();

            var existingProduct = productService.GetProductById(id);
            if (existingProduct is null) return Results.NotFound();

            productService.UpdateProduct(updatedProduct);
            return Results.Ok(updatedProduct);
        });

        app.MapDelete("/products/{id}", (int id, IProductService productService) =>
        {
            var product = productService.GetProductById(id);
            if (product is null) return Results.NotFound();

            productService.DeleteProduct(id);
            return Results.NoContent();
        });
    }
}
