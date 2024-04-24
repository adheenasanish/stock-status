using System.ComponentModel.DataAnnotations;

namespace PaintStockStatusAPI.Models
{
    public class Paint
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public int Stock { get; set; }
        public int Min { get; set; }

    }
}
