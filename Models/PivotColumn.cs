using System.Collections.Generic;
using Ballerina.Models;

namespace Ballerina.Models
{
    public class PivotColumn
    {
        public string ColumnName { get; set; }
        public Dictionary<string, CellValue> PivotMappings { get; set; } = new Dictionary<string, CellValue>();
    }
}