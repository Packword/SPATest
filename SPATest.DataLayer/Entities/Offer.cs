using System.ComponentModel.DataAnnotations.Schema;

namespace SPATest.DataLayer.Entities
{
    public class Offer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Type { get; set; }
        public int Bid { get; set; }
        public int? Cbid { get; set; }
        public string IsAvailable { get; set; }
        public string Url { get; set; }
        public int Price { get; set; }
        public string CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

        public Offer() { }
        public Offer(int id,
                     string type,
                     int bid,
                     int cbid,
                     string isAvailable,
                     string url,
                     int price,
                     string currencyId,
                     int categoryId,
                     string picture,
                     string description)
        {
            Id = id;
            Type = type;
            Bid = bid;
            Cbid = cbid;
            IsAvailable = isAvailable;
            Url = url;
            Price = price;
            CurrencyId = currencyId;
            CategoryId = categoryId;
            Picture = picture;
            Description = description;
        }
    }
}
