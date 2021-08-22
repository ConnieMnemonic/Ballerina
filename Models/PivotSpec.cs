using System.Data;
using System.Collections.Generic;

namespace Ballerina.Models
{
    public class PivotSpec
    {
        public DataTable Input { get; set; }
        public IEnumerable<string> PrimaryKeyColumns { get; set; }
        public IEnumerable<string> PivotColumns { get; set; }
        public IEnumerable<string> ValueColumns { get; set; }
    }
}