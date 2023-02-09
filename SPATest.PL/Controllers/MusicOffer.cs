using Microsoft.AspNetCore.Mvc;
using SPATest.BuisnessLayer.DTO;
using SPATest.BuisnessLayer.Interfaces;

namespace SPATest.PL.Controllers
{
    public class MusicOffer : Controller
    {
        private readonly IOfferService<MusicOfferDTO> _offerService;


        public MusicOffer(IOfferService<MusicOfferDTO> offerService)
        {
            _offerService = offerService;
        }

        public async Task<IActionResult> Index()
        {
            MusicOfferDTO offer = await _offerService.GetOffer(12344);
            offer.IsAvailable = offer.IsAvailable == "true" ? "Available" : "Not available";
            offer.Delivery = offer.Delivery == "true" ? "Available" : "Not available";
            ViewBag.Offer = offer;
            return View();
        }
    }
}