using WebApplicationProduct.Models;

namespace WebApplicationProduct.RepoProduct
{
    public interface IRepoProduct
    {
        List<Product> GetAll();
        Product? GetById(int id);
        Product Add(Product product);
        Product? Update(int id, Product product);
        bool Delete(int id);
    }
}
