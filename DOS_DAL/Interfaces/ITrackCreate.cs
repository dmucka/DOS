﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOS_DAL.Models;

namespace DOS_DAL.Interfaces
{
    public interface ITrackCreate
    {
        DateTime Created { get; set; }
        User CreatedBy { get; set; }
    }
}
