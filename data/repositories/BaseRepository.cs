using data.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.repositories
{
    public class BaseRepository
    {
    
            public readonly Context context;

            public BaseRepository(Context _context)
            {
                context = _context;
            }
        }
    
}
