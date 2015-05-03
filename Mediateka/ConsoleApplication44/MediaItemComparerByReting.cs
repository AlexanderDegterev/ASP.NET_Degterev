using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication44
{
    class MediaItemComparerByReting : IComparer<IMediaItem>
    {
        public int Compare(IMediaItem x, IMediaItem y)
        {
            if(x.Rating>y.Rating)
            {
                return 1;
            }
            else
            {
                    return (x.Rating == y.Rating) ? 0 : -1;
            }
        }
        
    }

}
