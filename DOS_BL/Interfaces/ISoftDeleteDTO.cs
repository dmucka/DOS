using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Interfaces
{
    public interface ISoftDeleteDTO
    {
        public bool IsDeleted { get; set; }
    }
}
