using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class UserWhoIsCustomerDto : IDto
    {
        public string email { get; set; }
        public int userId { get; set; }
        public int customerId { get; set; }
        public string CompanyName { get; set; }
        public int FindeksScore { get; set; }
    }
}
