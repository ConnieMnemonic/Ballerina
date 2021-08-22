using System.Data;
using System.Linq;
using System.Collections.Generic;
using Ballerina.Models;
using Ballerina.Helpers;

namespace Ballerina.Services
{
    public class PivotTableService
    {
        public PivotTable GenerateOutputDataTable(PivotSpec spec)
        {
            PivotTable output = new PivotTable();

            var distinctPivotSet = DataHelpers.GetDistinct(spec.Input, spec.PivotColumns);

            foreach(string valueColumn in spec.ValueColumns)
            {
                //For each unique PK combo, generate tree
                //Assume moving left to right in tabular space -> moving deeper in tree space

                foreach(DataColumn column in spec.Input.Columns)
                {
                    if(column.ColumnName == valueColumn)
                    {
                        //If it's our target...
                        foreach(DataRow row in distinctPivotSet.Rows)
                        {
                            GenerateColumnName(output, row, valueColumn);
                        }
                    }
                    else
                    {
                        //Otherwise flat copy
                        output.DataTable.Columns.Add(column.ColumnName);
                    }
                }
            }


            return output;
        }

        private void GenerateColumnName(PivotTable output, DataRow row, string valueColumn)
        {
            string pivotColumnName = "";
            var pivotColumn = new PivotColumn();

            for(int i = 0; i < row.Table.Columns.Count; i++)
            {
                foreach(DataColumn column in row.Table.Columns)
                {
                    pivotColumnName += $"{column.ColumnName}_{row[column]} ";
                    pivotColumn.PivotMappings[column.ColumnName] = new CellValue(row[column], column.DataType);
                }
            }

            pivotColumnName += valueColumn;
            pivotColumn.ColumnName = pivotColumnName;

            output.DataTable.Columns.Add(pivotColumnName);
        }
    }
}