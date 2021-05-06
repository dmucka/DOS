using System;

namespace DOS_BL.Interfaces
{
    public interface ITrackEditDTO
    {
        DateTime Edited { get; set; }
        string EditedByUsername { get; set; }
        string EditedText { get; }
    }
}
