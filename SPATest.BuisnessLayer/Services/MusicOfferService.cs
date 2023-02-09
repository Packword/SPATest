using SPATest.BuisnessLayer.DTO;
using SPATest.BuisnessLayer.Interfaces;
using SPATest.DataLayer;
using SPATest.DataLayer.Entities;
using System.Xml.Linq;

namespace SPATest.BuisnessLayer.Services
{
    public class MusicOfferService:IOfferService<MusicOfferDTO>
    {

        public MusicOfferService() { }
        public async Task<MusicOfferDTO> GetOffer(int? id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MusicOfferDTO offer = new MusicOfferDTO();
                MusicOffer? offerDb = db.MusicOffers.FirstOrDefault(o => o.Id == id);
                if (offerDb == null)
                {
                    offerDb = new MusicOffer();
                    await FillOffer(id, offerDb);
                    db.MusicOffers.Add(offerDb);
                    db.SaveChanges();
                }
                MapOffer(offer, offerDb);
                return offer;
            }
        }

        private async Task FillOffer(int? id, MusicOffer? offerDb)
        {
            XElement xmlOffer = await ExtractOffer(id);
            ParseXmlOffer(offerDb, xmlOffer);
        }

        private void MapOffer(MusicOfferDTO offer, MusicOffer? offerDb)
        {
            offer.IsAvailable = offerDb.IsAvailable;
            offer.Url = offerDb.Url;
            offer.Price = offerDb.Price;
            offer.Currency = offerDb.CurrencyId;
            offer.Picture = offerDb.Picture;
            offer.Description = offerDb.Description;
            offer.Delivery = offerDb.Delivery;
            offer.Artist = offerDb.Artist;
            offer.Title = offerDb.Title;
            offer.Year = offerDb.Year;
            offer.Media = offerDb.Media;
        }

        private void ParseXmlOffer(MusicOffer offerDb, XElement xmlOffer)
        {
            offerDb.Id = Convert.ToInt32(xmlOffer.Attribute("id").Value);
            offerDb.Type = xmlOffer.Attribute("id").Value;
            offerDb.Bid = Convert.ToInt32(xmlOffer.Attribute("bid").Value);
            offerDb.IsAvailable = xmlOffer.Attribute("available").Value;
            offerDb.Url = xmlOffer.Element("url").Value;
            offerDb.Price = Convert.ToInt32(xmlOffer.Element("price").Value);
            offerDb.CurrencyId = xmlOffer.Element("currencyId").Value;
            offerDb.CategoryId = Convert.ToInt32(xmlOffer.Element("categoryId").Value);
            offerDb.Picture = xmlOffer.Element("picture").Value;
            offerDb.Description = xmlOffer.Element("description").Value;
            offerDb.Delivery = xmlOffer.Element("delivery").Value;
            offerDb.Artist = xmlOffer.Element("artist").Value;
            offerDb.Title = xmlOffer.Element("title").Value;
            offerDb.Year = Convert.ToInt32(xmlOffer.Element("year").Value);
            offerDb.Media = xmlOffer.Element("media").Value;
        }

        private async Task<XElement> ExtractOffer(int? id)
        {
            string xml = await GetXmlByUrl("http://partner.market.yandex.ru/pages/help/YML.xml");
            XDocument doc = XDocument.Parse(xml);
            XElement xmlShop = doc.Element("yml_catalog").Element("shop");
            XElement xmlOffer = xmlShop.Element("offers")?.Elements("offer")
                .FirstOrDefault(o => Convert.ToInt32(o.Attribute("id").Value) == id);
            return xmlOffer;
        }

        private async Task<string> GetXmlByUrl(string url)
        {
            HttpClient client = new HttpClient();

            using HttpResponseMessage response = await client.GetAsync(url);
            using HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();

            return json;
        }
    }
}
