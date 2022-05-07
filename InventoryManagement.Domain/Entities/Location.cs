using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public SubLocation SubLocation { get; set; }
    }
}
