using System.Data;
using System.Linq;
using System.Collections.Generic;
using Ballerina.Models;
using Ballerina.Helpers;

namespace Ballerina.Services
{
    public class ColumnHeaderService
    {
        public DataTable GenerateOutputDataTable(PivotSpec spec)
        {
            DataTable output = new DataTable();

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
                            output.Columns.Add(GenerateColumnName(row, valueColumn));
                        }
                    }
                    else
                    {
                        //Otherwise flat copy
                        output.Columns.Add(column.ColumnName);
                    }
                }
            }


            return output;
        }

        private string GenerateColumnName(DataRow row, string valueColumn)
        {
            string columnName = "";

            for(int i = 0; i < row.Table.Columns.Count; i++)
            {
                foreach(DataColumn column in row.Table.Columns)
                {
                    columnName += $"{column.ColumnName}_{row[column]} ";
                }
            }
            columnName += valueColumn;

            return columnName;
        }
    }
}