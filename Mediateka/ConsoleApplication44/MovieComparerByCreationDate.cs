using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication44
{
    class MovieComparerByCreationDate : IComparer<IMovieItem>
    {
        public int Compare(IMovieItem x, IMovieItem y)
        {
            if (x != null && y != null)
            {
                if (x.CreationDate > y.CreationDate)
                {
                    return 1;
                }
                else
                {
                    return (x.CreationDate == y.CreationDate) ? 0 : -1;
                }
            }
            else
            {
                return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            }
        }
    }
}
