using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public partial class AttendanceType
    {
        public int Id { get; set; }
        public String Name { get; set; }

        //houres
        //public datetim EnterTime { get; set; }
        //houres
        //public int ExitTime { get; set; }

        public String WorkingTotalMinutes { get; set; }
    }
}
