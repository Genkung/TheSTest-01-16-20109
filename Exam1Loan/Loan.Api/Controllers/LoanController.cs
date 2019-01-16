using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Loan.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        [HttpGet("{debtAmount}/{increasePercentage}/{totalYears}")]
        public ActionResult<IEnumerable<LoanCalculatorModel>> GetTotalDebtAmount(double debtAmount, double increasePercentage, int totalYears)
        {
            var result = new List<LoanCalculatorModel>();
            for (int i = 0; i < totalYears; i++)
            {
                var increaseAmount = debtAmount * increasePercentage / 100;
                var totalDebtAmount = debtAmount + increaseAmount;
                var loadDetail = new LoanCalculatorModel
                {
                    DebtAmount = debtAmount,
                    IncreaseAmount = increaseAmount,
                    IncreasePercentage = increasePercentage,
                    TotalDebtAmount = totalDebtAmount
                };
                result.Add(loadDetail);
                debtAmount = totalDebtAmount;
            }
            return result;
        }
    }

    public class LoanCalculatorModel
    {
        public double DebtAmount { get; set; }
        public double IncreaseAmount { get; set; }
        public double IncreasePercentage { get; set; }
        public double TotalDebtAmount { get; set; }
    }
}

