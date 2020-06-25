using System;
namespace Bravado.Models.Services
{
    public class PriceTable
    {
        public int ID { get; set; }
        public int ByHour { get; set; }
        public int ByAmount { get; set; }
        public int ByMonth { get; set; }
        public int ByQuantity { get; set; }
    }
}
