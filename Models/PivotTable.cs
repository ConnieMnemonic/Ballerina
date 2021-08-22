using System.Data;
using System.Collections.Generic;

namespace Ballerina.Models
{
    public class PivotTable
    {
        public DataTable DataTable { get; set; } = new DataTable();
        public List<PivotColumn> PivotColumns { get; set; } = new List<PivotColumn>();
    }
}