using DOS_DAL.Models;
using System;

namespace DOS_DAL.Interfaces
{
    public interface ITrackEdit
    {
        DateTime Edited { get; set; }
        User EditedBy { get; set; }
    }
}
