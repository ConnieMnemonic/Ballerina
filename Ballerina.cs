using System.Data;
using System.Collections.Generic;
using Ballerina.Services;
using Ballerina.Models;

namespace Ballerina
{
    public class Ballerina
    {
        public DataTable Pivot(
            DataTable input,
            IEnumerable<string> primaryKeyColumns,
            IEnumerable<string> pivotColumns,
            IEnumerable<string> valueColumns)
        {
            var pivotTreeService = new PivotTreeService();
            var pivotTree = pivotTreeService.GeneratePivotTrees(input, primaryKeyColumns, pivotColumns, valueColumns);
            
        }
    }
}