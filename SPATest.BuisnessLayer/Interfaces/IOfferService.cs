using SPATest.BuisnessLayer.DTO;

namespace SPATest.BuisnessLayer.Interfaces
{
    public interface IOfferService<T> where T : OfferDTO
    {
        Task<T> GetOffer(int? id);
    }
}
