using System;
using System.Collections.Generic;

namespace CaseManagementPortal.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;

        public List<Case> Cases { get; set; } = new List<Case>(); // A client can have multiple cases
    }
}
