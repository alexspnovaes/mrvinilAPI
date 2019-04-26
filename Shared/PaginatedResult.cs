using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public class PaginatedResult<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">The full list of items you would like to paginate</param>
        /// <param name="page">The current page number</param>
        /// <param name="pageSize">(optional) The size of the page</param>
        public PaginatedResult(IQueryable<T> list, int page, int pageSize = 10)
        {
            _list = list;
            _page = page;
            _pageSize = pageSize;
        }

        private IQueryable<T> _list;
        public IEnumerable<T> Items
        {
            get
            {
                if (_list == null) return null;
                return _list.Skip((Page - 1) * PageSize).Take(PageSize).ToList();
            }
        }

        private int? _page;
        /// <summary>
        ///  The current page.
        /// </summary>
        public int Page
        {
            get
            {
                if (!_page.HasValue)
                {
                    return 1;
                }
                else
                {
                    return _page.Value;
                }
            }
        }

        private int? _pageSize;
        /// <summary>
        /// The size of the page.
        /// </summary>
        public int PageSize
        {
            get
            {
                if (!_pageSize.HasValue)
                {
                    return _list == null ? 0 : _list.Count();
                }
                else
                {
                    return _pageSize.Value;
                }
            }
        }

        /// <summary>
        /// The total number of items in the original list of items.
        /// </summary>
        public int TotalItemCount
        {
            get
            {
                return _list == null ? 0 : _list.Count();
            }
        }
    }
}
