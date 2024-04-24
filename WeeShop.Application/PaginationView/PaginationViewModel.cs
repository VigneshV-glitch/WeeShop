using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeShop.Application.PaginationView
{
    public class PaginationViewModel<T>
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalNoOfRecords { get; set; }

        public List<T> Items { get; set; }

        public bool HasPrevious => CurrentPage > 1;

        public bool HasNext => CurrentPage < TotalPages;

        public PaginationViewModel(int currentpage, int totalpage, int pagesize, int totalnoofrecords, List<T> items)
        {
            CurrentPage = currentpage;
            TotalPages = totalpage;
            PageSize = pagesize;
            TotalNoOfRecords = totalnoofrecords;
            Items = items;
        }
    }
}
