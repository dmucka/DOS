using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOS_BL.Interfaces
{
    public interface ITrackCreateDTO
    {
        DateTime Created { get; set; }
        string CreatedByUsername { get; set; }
        string CreatedText { get; }
    }
}
