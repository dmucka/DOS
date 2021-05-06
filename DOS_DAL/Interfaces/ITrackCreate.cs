using DOS_DAL.Models;
using System;

namespace DOS_DAL.Interfaces
{
    public interface ITrackCreate
    {
        DateTime Created { get; set; }
        User CreatedBy { get; set; }
    }
}
