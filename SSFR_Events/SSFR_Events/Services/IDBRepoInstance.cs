﻿using SSFR_Events.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSFR_Events.Services
{
    public interface IDBRepoInstance
    {
        IDBRepository getInstance();
    }
}
