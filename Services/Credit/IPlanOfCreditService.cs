using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Credit.Models;

namespace Services.Credit
{
    public interface IPlanOfCreditService
    {
        void Create(PlanOfCreditModel plan);
        IEnumerable<PlanOfCreditModel> GetAll();
    }
}
