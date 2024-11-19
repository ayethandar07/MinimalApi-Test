using MinimalApiTest.Model;
using System.Xml.Linq;

namespace MinimalApiTest.Repository;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99M },
        new Product { Id = 2, Name = "Smartphone", Price = 499.99M }
    };

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product)
    {
        product.Id = _products.Max(p => p.Id) + 1;
        _products.Add(product);
    }

    public void Update(Product updatedProduct)
    {
        var product = GetById(updatedProduct.Id);
        if (product != null)
        {
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
        }
    }

    public void Delete(int id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}
