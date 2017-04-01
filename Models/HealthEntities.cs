using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HealthCare.Models
{
    public partial class healthEntities : DbContext
    {
        public List<EmployeeDisplay> EmployeeList()
        {
            var list = from e in this.Employees
                       select new EmployeeDisplay
                       {
                           Id = e.Id,
                           First = e.First,
                           Last = e.Last,
                           BenefitPlanId = e.BenefitPlanId ?? 0,
                           BenefitPlanTitle = (e.BenefitPlanId == null || e.BenefitPlanId == 0) ? "No Plan Selected" : e.BenefitPlan.Title,
                           PhotoUrl = e.PhotoUrl
                       };

            return list.ToList();
        }

        public bool UpdatePlan(int UserId, int PlanId)
        {
            var employee = this.Employees.FirstOrDefault(i => i.Id == UserId);
            if (employee != null)
            {
                employee.BenefitPlanId = PlanId;
                this.SaveChanges();
                return true;
            }
            return false;
        }
    }
}