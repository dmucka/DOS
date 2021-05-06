using System;

namespace DOS_BL.Interfaces
{
    public interface ITrackCreateDTO
    {
        DateTime Created { get; set; }
        string CreatedByUsername { get; set; }
        string CreatedText { get; }
    }
}
