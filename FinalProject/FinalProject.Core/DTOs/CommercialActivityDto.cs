using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTOs
{
    public class CommercialActivityDto
    {
        public int Id { get; set; }

        public string Service { get; set; }

        public decimal Price { get; set; }

        public DateTime ActivityDate { get; set; }

        public int CustomerId { get; set; }
    }
}
