using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Ballerina.Helpers
{
    public static class DataHelpers
    {
        public static DataTable GetDistinct(DataTable input, IEnumerable<string> columnNames)
        {
            DataView view = new DataView(input);
            return view.ToTable(true, columnNames.ToArray());
        }
    }
}