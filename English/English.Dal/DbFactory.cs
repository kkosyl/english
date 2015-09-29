using English.Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal
{
    public class DbFactory : IDbFactory
    {
        private EnglishDbContext _context;

        public Model.EnglishDbContext Get()
        {
            return _context ?? (_context = new EnglishDbContext());
        }
    }
}
