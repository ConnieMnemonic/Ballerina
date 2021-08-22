using System.Data;
using System.Collections.Generic;
using Ballerina.Services;
using Ballerina.Models;

namespace Ballerina
{
    public class Ballerina
    {
        public DataTable Pivot(PivotSpec spec)
        {
            var pivotTreeService = new PivotTreeService();
            var columnHeaderService = new ColumnHeaderService();
            var pivotingService = new PivotingService();

            var pivotTrees = pivotTreeService.GeneratePivotTrees(spec);
            var output = columnHeaderService.GenerateOutputDataTable(spec);

            pivotingService.Pivot(spec, output, pivotTrees);

            return output;
        }
    }
}