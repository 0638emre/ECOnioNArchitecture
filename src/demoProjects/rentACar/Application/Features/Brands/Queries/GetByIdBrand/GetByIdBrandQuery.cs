﻿using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper ;
            private readonly BrandsBusinessRules _brandBusinessRules;

            public GetByIdQueryHandler(IBrandRepository brandRepository,IMapper mapper, BrandsBusinessRules brandsBusinessRules)
            {
                _brandRepository = brandRepository; 
                _mapper = mapper;
                _brandBusinessRules = brandsBusinessRules;
            }

            public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id);
               
                _brandBusinessRules.BrandShouldExistWhenRequested(brand);

                BrandGetByIdDto brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(brand);
                return brandGetByIdDto;
            }
        }
    }
}
