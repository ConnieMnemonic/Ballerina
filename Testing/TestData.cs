using System;
using System.Data;

namespace Ballerina.Testing
{
    public static class TestData
    {
        public static DataTable GetTestDataGrid()
        {
            var table = new DataTable();
            
            table.Columns.Add("Id");
            table.Columns.Add("FocusMode");
            table.Columns.Add("MotorId");
            table.Columns.Add("Position");
            table.Columns.Add("Speed");

            CreateAndAddRow(table, 1, 1, 1, 10, 8);
            CreateAndAddRow(table, 1, 1, 2, 20, 7);
            CreateAndAddRow(table, 1, 2, 1, 30, 6);
            CreateAndAddRow(table, 1, 2, 2, 40, 5);
            CreateAndAddRow(table, 2, 1, 1, 50, 4);
            CreateAndAddRow(table, 2, 1, 2, 60, 3);
            CreateAndAddRow(table, 2, 2, 1, 70, 2);
            CreateAndAddRow(table, 2, 2, 2, 80, 1);

            return table;
        }

        private static void CreateAndAddRow(DataTable table, int id, int focusMode, int motorId, int position, int speed)
        {
            var row = table.NewRow();

            row["Id"] = id;
            row["FocusMode"] = focusMode;
            row["MotorId"] = motorId;
            row["Position"] = position;
            row["Speed"] = speed;

            table.Rows.Add(row);
        }
    }
}