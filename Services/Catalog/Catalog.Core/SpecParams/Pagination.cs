using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.SpecParams
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize,long total,IReadOnlyList<T> data)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Total = total;
            this.Data = data;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Total { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}
