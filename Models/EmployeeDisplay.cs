using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public class EmployeeDisplay
    {
        public EmployeeDisplay() { }
        public EmployeeDisplay(Employee person)
        {
            Id = person.Id;
            First = person.First;
            Last = person.Last;
            BenefitPlanId = person.BenefitPlanId != null ? person.BenefitPlanId : 0;
            BenefitPlanTitle = (person.BenefitPlanId == null || person.BenefitPlanId == 0) ? "No Plan Selected" : person.BenefitPlan.Title;
            PhotoUrl = person.PhotoUrl;
        }

        public long Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public Nullable<long> BenefitPlanId { get; set; }
        public string BenefitPlanTitle { get; set; }
        public string PhotoUrl { get; set; }
    }
}