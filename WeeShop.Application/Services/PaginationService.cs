using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Application.Pagination;
using WeeShop.Application.PaginationView;
using WeeShop.Application.Services.Interface;

namespace WeeShop.Application.Services
{
    public class PaginationService<T, S> : IPaginationService<T, S> where T : class
    {
        private readonly IMapper _mapper;

        public PaginationService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PaginationViewModel<T> GetPagination(List<S> source, PaginationModel paginationModel)
        {
            var CurrentPage = paginationModel.PageNumber;

            var PageSize = paginationModel.PageSize;

            var TotalNoOfRecords = source.Count;

            var TotalPages = (int)Math.Ceiling(TotalNoOfRecords / (Double)PageSize);

            var Result = source
                .Skip((paginationModel.PageNumber - 1) * (paginationModel.PageSize))
                .Take(paginationModel.PageSize)
                .ToList();

            var items = _mapper.Map<List<T>>(Result);

            PaginationViewModel<T> paginationViewModel = new PaginationViewModel<T>(CurrentPage,TotalPages, PageSize, TotalNoOfRecords, items);

            return paginationViewModel;
        }
    }
}
