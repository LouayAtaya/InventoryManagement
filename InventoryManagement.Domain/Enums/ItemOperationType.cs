﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.Enums
{
    public enum ItemOperationType: byte
    {
        Addition,
        Transfer,
        Exit,
        Return,
        Lost

    }
}
