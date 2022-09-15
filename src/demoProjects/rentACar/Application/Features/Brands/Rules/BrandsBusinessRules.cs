using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandsBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandsBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDublicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any())
            {
                throw new BusinessException("Marka isimleri aynı olamaz.");
            }
        }

        public void BrandShouldExistWhenRequested(Brand brand)
        {
            if (brand == null) 
            {
                throw new BusinessException("Requested brand does not exist !");
            }
        }
    }
}
