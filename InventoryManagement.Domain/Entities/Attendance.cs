using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    class Attendance
    {
        public int Id { get; set; }
        public DateTime workingDay { get; set; }
        public DateTime EnterTime { get; set; }
        public DateTime ExitTime { get; set; }
        public int WorkingTotalMinutes { get; set; }
        public bool isHoliday { get; set; }

    }
}
