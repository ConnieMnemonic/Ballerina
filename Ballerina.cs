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
            var pivotTableService = new PivotTableService();
            var pivotingService = new PivotingService();

            var pivotTrees = pivotTreeService.GeneratePivotTrees(spec);
            var output = pivotTableService.GenerateOutputDataTable(spec);

            pivotingService.Pivot(spec, output, pivotTrees);

            return output;
        }
    }
}