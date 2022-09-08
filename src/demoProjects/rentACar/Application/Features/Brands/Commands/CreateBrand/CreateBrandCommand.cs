using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public partial class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        public string Name { get; set; }
        public class CreateBrandCommandHandler:IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandsBusinessRules _brandsBusinessRules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandsBusinessRules brandsBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandsBusinessRules = brandsBusinessRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {

                //en başta rules ile kuralları uyguluyoruz
                await _brandsBusinessRules.BrandNameCanNotBeDublicatedWhenInserted(request.Name);

                //önce gelen request(burada Name en üstte prop olarak tanımlandı. Brand entity ile mapleniyor)
                Brand mappedBrand = _mapper.Map<Brand>(request);
                //ardından gelen name parametresi repository metodu sayesinde işlem görüyor ve dönüş olarak bize brand entity dönüyor
                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand);
                //son olarak bize geri döndürdüğü değeri dto nesnesi ile mapleyip handle işlemini tamamlıyoruz
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand);
                return createdBrandDto;
            }
        }
    }
}
