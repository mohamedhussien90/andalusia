using WebApplicationProduct.Models;
using WebApplicationProduct.RepoProduct;

namespace WebApplicationProduct.ServiceProduct
{
    public class ServiceProduct: IServiceProduct
    {
        private readonly IRepoProduct _repo;

        public ServiceProduct(IRepoProduct repo)
        {
            _repo = repo;
        }

        public List<Product> GetAll() => _repo.GetAll();
        public Product? GetById(int id) => _repo.GetById(id);
        public Product Add(Product product) => _repo.Add(product);
        public Product? Update(int id, Product product) => _repo.Update(id, product);
        public bool Delete(int id) => _repo.Delete(id);
    }
}
