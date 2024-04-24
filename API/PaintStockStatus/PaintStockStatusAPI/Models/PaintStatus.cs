namespace PaintStockStatusAPI.Models
{
    public class PaintStatus
    {
        public int Id { get; set; }
        public int PaintId { get; set; }
        public int  StatusId { get; set; }

        public Paint Paint { get; set; }
        public Status Status { get; set; }
    }
}
