using WebApplicationProduct.Models;

namespace WebApplicationProduct.RepoProduct
{
    public class RepoProduct: IRepoProduct
    {
        private  List<Product> _products = new List<Product>();
        

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Add(Product product)
        {
            
            _products.Add(product);
            return product;
        }

        public Product? Update(int id, Product product)
        {
            var index = _products.FindIndex(p => p.Id == id);

            if (index == -1)
            {
                return null;
            }

            //product.Id = id; 
            _products[index] = product; 

            return product;
        }

        public bool Delete(int id)
        {
            var productToRemove = _products.FirstOrDefault(p => p.Id == id);

            if (productToRemove == null)
            {
                return false; 
            }

            _products.Remove(productToRemove);
            return true;
        }
    }
}
