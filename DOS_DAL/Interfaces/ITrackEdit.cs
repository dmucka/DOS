using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOS_DAL.Models;

namespace DOS_DAL.Interfaces
{
    public interface ITrackEdit
    {
        public DateTime Edited { get; set; }
        public User EditedBy { get; set; }
    }
}
