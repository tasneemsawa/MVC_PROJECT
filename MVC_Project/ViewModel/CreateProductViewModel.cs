using MVC_Project.Models;

namespace MVC_Project.ViewModel
{
    public class CreateProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
