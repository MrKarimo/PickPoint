namespace PickPoint.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public string[] Goods { get; set; }
        public decimal Check { get; set; }
        public string PostamatNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string RecipientName { get; set; }

    }
}
