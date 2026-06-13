using MVC_Project.Models;

namespace MVC_Project.ViewModel
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Rate { get; set; }
        public int Quantity { get; set; }
        public String CategoryName { get; set; }
    }
}
