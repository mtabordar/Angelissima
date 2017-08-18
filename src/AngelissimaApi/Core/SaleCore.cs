namespace AngelissimaApi.Core
{
    using System.Collections.Generic;
    using AutoMapper;
    using Interfaces;
    using Models;
    using Models.Interfaces;
    using ViewModels;

    public class SaleCore : ISaleCore
    {
        private ISaleRepository _saleRepository;
        private IMapper _mapper;

        public SaleCore(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public void Add(SaleViewModel item)
        {
            Sale sale = _mapper.Map<Sale>(item);

            _saleRepository.Add(sale);
            _saleRepository.SaveChanges();
        }

        public SaleViewModel Find(int id)
        {
            return _mapper.Map<SaleViewModel>(_saleRepository.Find(id));
        }

        public IEnumerable<SaleViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<SaleViewModel>>(_saleRepository.GetAll());
        }

        public void Remove(int id)
        {
            _saleRepository.Remove(id);
            _saleRepository.SaveChanges();
        }

        public void Update(SaleViewModel item)
        {
            Sale sale = _mapper.Map<Sale>(item);

            _saleRepository.Update(sale);
            _saleRepository.SaveChanges();
        }
    }
}
