using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Application.Pagination;
using WeeShop.Application.PaginationView;

namespace WeeShop.Application.Services.Interface
{
    public interface IPaginationService<T,S> where T : class
    {
        PaginationViewModel<T> GetPagination(List<S> source, PaginationModel paginationModel);
    }
}
