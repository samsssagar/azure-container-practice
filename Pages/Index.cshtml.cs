using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductService.Models;
using ProductService.Services;

namespace ProductService.Pages
{
    public class IndexModel : PageModel
    {
        public List<ProductModel>? Products { get; set; }
        private readonly IProductService _productService;

        public IndexModel(IProductService productService) 
        {
            _productService = productService;
        }

        public async Task OnGetAsync()
        {
            Products = _productService.GetProducts();
        }
    }
}
