namespace SPATest.BuisnessLayer.DTO
{
    public class MusicOfferDTO: OfferDTO
    {
        public string? Artist { get; set; }
        public string? Title { get; set; }
        public int? Year { get; set; }
        public string? Media { get; set; }
        public string? Delivery { get; set; }
    }
}
