using System;
using System.Collections.Generic;

namespace MVCStudenClassAssinment.DAL.Helper
{
    public static class Helper
    {
        public static IEnumerable<T> SetValue<T>(this IEnumerable<T> items, Action<T> updateMethod)
        {
            foreach (T item in items)
            {
                updateMethod(item);
            }
            return items;
        }
    }
}
