using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Service.Models
{

    public class SortingData
    {
        public string SortOrder { get; set; } = "name";
        public SortingData() { }
    }
    public class FilteringData
    {
        public string CurrentFilter { get; set; }
        public string SearchString { get; set; } = "";
        public FilteringData() { }
    }
    public class PaginationData
    {
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 3;
        public int TotalCount { get; set; }
        private bool HasPrevious => CurrentPage > 1;
        private bool HasNext => CurrentPage < TotalPages;
        public PaginationData() { }
    }
    public class PagedList<T> 
    {
        public List<T> Items;
        public PagedList(){}
        public PaginationData PaginationData { get; set; }
        public PagedList(List<T> items, int count, PaginationData pagination)
        {
            PaginationData = pagination;

            PaginationData.TotalPages = (int)Math.Ceiling(count / (double)pagination.PageSize);
            
            Items = new List<T>();
            Items.AddRange(items);
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source,int totalCount, PaginationData pagination)
        {
            return new PagedList<T>(source.ToList(), totalCount, pagination);
        }
    }
}
