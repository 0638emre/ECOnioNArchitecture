using Application.Features.Brands.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Brands.Models
{
    //modeller encapsulation yapabilmek adına sayfalama gibi işleri yapmak için var.
    public class BrandListModel:BasePageableModel
    {
        public IList<BrandListDto> Items { get; set; }
    }
}
