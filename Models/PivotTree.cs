using System.Collections.Generic;

namespace Ballerina.Models
{
    public class PivotTree
    {
        public PivotTree(string inputValueColumn)
        {
            InputValueColumn = inputValueColumn;
        }

        public string InputValueColumn { get; set; }

        public PivotTreeNode Root { get; set;} = new PivotTreeNode("Root", null);

        //Tree Structure
        //GroupingColumns -> PivotColumns
        //E.g. Id -> FocusMode -> MotorId :)
    }
}