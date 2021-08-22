using System.Collections.Generic;
using System.Linq;

namespace Ballerina.Models
{
    public class PivotTreeNode
    {
        public PivotTreeNode(string columnName, CellValue pivotValue, CellValue leafValue = null)
        {
            ColumnName = columnName;
            PivotValue = pivotValue;
        }

        public string ColumnName { get; set; } = "Root";
        public CellValue PivotValue {get;set;}
        public CellValue LeafValue { get; set;}

        //<columnName, node>
        public Dictionary<CellValue, PivotTreeNode> Children { get; set;}

        public PivotTreeNode GetNext(CellValue other)
        {
            return Children[other];
        }

        public void AddChild(PivotTreeNode child)
        {
            Children.Add(child.PivotValue, child);
        }
    }
}