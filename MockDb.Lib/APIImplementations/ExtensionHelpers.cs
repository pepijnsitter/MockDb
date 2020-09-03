using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MockDb.Lib.APIImplementations
{
    public static class ExtensionHelpers
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int pageNumber, int pageLength)
        {
            return source.Skip(pageNumber * pageLength).Take(pageLength);
        }
    }
}
