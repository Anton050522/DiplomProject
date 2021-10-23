using System;
using System.Collections.Generic;
using System.Text;

namespace CommonClasses.PaginationAndSort.PageViewClass
{
    public class PageView
    {
        public int PageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PageView(int listCount, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(listCount / (double)pageSize);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageNumber > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageNumber < TotalPages);
            }
        }
    }
}
