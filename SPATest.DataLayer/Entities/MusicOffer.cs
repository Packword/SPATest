using System.ComponentModel.DataAnnotations.Schema;

namespace SPATest.DataLayer.Entities
{
    [Table("MusicOffers")]
    public class MusicOffer : Offer
    {
        public MusicOffer() { }
        public MusicOffer(int id,
                     string type,
                     int bid,
                     int cbid,
                     string isAvailable,
                     string url,
                     int price,
                     string currencyId,
                     int categoryId,
                     string picture,
                     string description,
                     string? artist,
                     string? title,
                     int? year,
                     string? media,
                     string delivery) : base(id, type, bid, cbid, isAvailable, url, price, currencyId, categoryId, picture, description)
        {

            Artist = artist;
            Title = title;
            Year = year;
            Media = media;
            Delivery = delivery;
        }

        public string? Artist { get; set; }
        public string? Title { get; set; }
        public int? Year { get; set; }
        public string? Media { get; set; }
        public string? Delivery { get; set; }
    }
}
