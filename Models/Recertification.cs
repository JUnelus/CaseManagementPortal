using System;

namespace CaseManagementPortal.Models
{
    public class Recertification
    {
        public int RecertificationId { get; set; }
        public DateTime RecertificationDate { get; set; }
        public string RecertificationStatus { get; set; } = string.Empty; // For example, 'Pending', 'Approved'

        public int CaseId { get; set; }
        public Case Case { get; set; } = null!; // Non-nullable property initialized to avoid CS8618
    }
}
