using English.Dal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English.Dal
{
    public interface IDbFactory
    {
        EnglishDbContext Get();
    }
}
