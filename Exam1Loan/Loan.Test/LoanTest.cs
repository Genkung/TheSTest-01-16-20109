using Loan.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Loan.Test
{
    public class LoanTest
    {
        [Theory]
        [InlineData(10000, 12, 3,
            new double[3] { 10000, 11200, 12544 },
            new double[3] { 1200, 1344, 1505.28 },
            new double[3] { 12, 12, 12 },
            new double[3] { 11200, 12544, 14049.28 }
            )]
        [InlineData(10000, 12, 4,
            new double[4] { 10000, 11200, 12544, 14049.28 },
            new double[4] { 1200, 1344, 1505.28, 1685.9136 },
            new double[4] { 12, 12, 12, 12 },
            new double[4] { 11200, 12544, 14049.28, 15735.1936 }
            )]
        public void GetTotalDebtAmount(double debtAmount, double increasePercentage, int totalYears,
                                        double[] actrualDebtAmount, double[] actrualIncreaseAmount, double[] actrualIncreasePercentage, double[] actrualTotalDebtAmount)
        {
            var svc = new LoanController();
            var result = svc.GetTotalDebtAmount(debtAmount, increasePercentage, totalYears).Value.ToList();

            for (int i = 0; i < totalYears; i++)
            {
                Assert.Equal(result[i].DebtAmount, actrualDebtAmount[i]);
                Assert.Equal(result[i].IncreaseAmount, actrualIncreaseAmount[i]);
                Assert.Equal(result[i].IncreasePercentage, actrualIncreasePercentage[i]);
                Assert.Equal(result[i].TotalDebtAmount, actrualTotalDebtAmount[i]);
            };
        }
    }
}
