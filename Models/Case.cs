using System;
using System.Collections.Generic;

namespace CaseManagementPortal.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public string CaseType { get; set; } = string.Empty; // For example, 'Food Assistance'
        public DateTime CaseOpenDate { get; set; }
        public string CaseStatus { get; set; } = string.Empty; // For example, 'Open', 'Closed'

        public int ClientId { get; set; }
        public Client Client { get; set; } = new Client(); // Initialize to avoid CS8618

        public List<Recertification> Recertifications { get; set; } = new List<Recertification>(); // Multiple recertifications per case
    }
}
