using System.Data;
using System.Linq;
using System.Collections.Generic;
using Ballerina.Models;

namespace Ballerina.Services
{
    public class PivotTreeService
    {
        public List<PivotTree> GeneratePivotTrees(
            DataTable input,
            IEnumerable<string> primaryKeyColumns, 
            IEnumerable<string> pivotColumns,
            IEnumerable<string> valueColumns)
        {
            foreach(DataRow row in input.Rows)
            {
                foreach(string valueColumn in valueColumns)
                {
                    var tree = GeneratePivotTree(input, primaryKeyColumns, pivotColumns, valueColumn);
                }
            }
        }

        private PivotTree GeneratePivotTree(
            DataTable input,
            IEnumerable<string> primaryKeyColumns,
            IEnumerable<string> pivotColumns,
            string valueColumn)
        {
            var tree = new PivotTree(valueColumn);

            var combinedPivotColumns = primaryKeyColumns.ToList();
            combinedPivotColumns.AddRange(pivotColumns);
            var combinedWithData = new List<string>(combinedPivotColumns);
            combinedWithData.Add(valueColumn);
            var distinctPivotSet = GetDistinct(input, combinedPivotColumns);

            //For each unique PK combo, generate tree
            //Assume moving left to right in tabular space -> moving deeper in tree space

            foreach(DataRow row in distinctPivotSet.Rows)
            {
                PivotTreeNode activeNode = tree.Root;

                foreach(DataColumn column in row.Table.Columns)
                {
                    bool isValueColumn = column.ColumnName == valueColumn;

                    CellValue cellValue = new CellValue(row[column], column.DataType);
                    var next = activeNode.GetNext(cellValue);

                    if(next == null)
                    {
                        next = new PivotTreeNode(column.ColumnName, cellValue);

                        if(isValueColumn)
                        {
                            //Leaf value is now redundant?
                            next.LeafValue = cellValue;
                        }

                        activeNode.AddChild(next);
                    }

                    activeNode = next;
                }
            }

            return tree;
        }

        private DataTable GetDistinct(DataTable input, IEnumerable<string> columnNames)
        {
            DataView view = new DataView(input);
            return view.ToTable(true, columnNames.ToArray());
        }
    }
}