using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int NationalId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String FullName { get; set; }
        public String FatherName { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Age { get; set; }
        public string photo { get; set; }
    }
}
