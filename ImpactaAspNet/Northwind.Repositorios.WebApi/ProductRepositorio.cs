using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Repositorios.WebApi
{
    public class ProductRepositorio
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string url = "http://localhost:56609/api/products";

        public async Task<ProductViewModel> Post(ProductViewModel product)
        {
            using (var responsta = await httpClient.PostAsJsonAsync(url, product))
            {
                responsta.EnsureSuccessStatusCode();
                return await responsta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task Put(ProductViewModel product)
        {
            using (var responsta = await httpClient
                .PutAsJsonAsync($"{url}/{product.ProductID}", product))
            {
                responsta.EnsureSuccessStatusCode();
            }
        }

        public async Task<List<ProductViewModel>> Get()
        {
            using (var responsta = await httpClient.GetAsync(url))
            {
                responsta.EnsureSuccessStatusCode();
                return await responsta.Content.ReadAsAsync<List<ProductViewModel>>();
            }
        }

        public async Task<ProductViewModel> Get(int id)
        {
            using (var responsta = await httpClient.GetAsync($"{url}/{id}"))
            {
                responsta.EnsureSuccessStatusCode();
                return await responsta.Content.ReadAsAsync<ProductViewModel>();
            }
        }

        public async Task Delete(int id)
        {
            using (var responsta = await httpClient.DeleteAsync($"{url}/{id}"))
            {
                responsta.EnsureSuccessStatusCode();
            }
        }
    }
}
