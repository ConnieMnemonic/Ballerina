using System;

namespace Ballerina.Models
{
    public class CellValue : IEquatable<CellValue>
    {
        public CellValue(object cellValue, Type type)
        {
            Value = cellValue;
            Type = type;
        }

        public object Value {get;set;}
        public Type Type {get;set;}

        public bool Equals(CellValue other)
        {
            return Convert.ChangeType(Value, Type)
                .Equals(
                    Convert.ChangeType(other.Value, other.Type)
                );
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
