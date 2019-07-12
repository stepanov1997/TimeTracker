﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracker.Models
{
    public class PagedList<T>
    {
        public IEnumerable<T> items { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => 
            (int) Math.Ceiling((decimal)TotalCount / PageSize);
    }
}
