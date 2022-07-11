using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string ImageURL { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }
    }
}
