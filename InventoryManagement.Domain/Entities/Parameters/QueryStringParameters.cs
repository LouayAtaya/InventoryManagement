using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Entities.Parameters
{
    public abstract class QueryStringParameters
    {
        const int maxPageSize = 300;//50
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 250;//10
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string OrderBy { get; set; }

    }
}
