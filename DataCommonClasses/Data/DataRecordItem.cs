using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommonClasses.Data
{
    public class DataRecordItem<ValueType>
    {
        public ValueType Value { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsIterable { get; set; }
        public DataRecordItem(ValueType item)
        {
            Value = item;
            Timestamp = DateTime.UtcNow;
        }
        public K GetKeyField<K>(string fieldName = "Id")
        {
            var keyProperty = typeof(ValueType).GetProperty(fieldName);
            if (keyProperty == null)
            {
                throw new InvalidOperationException($"Type T does not have a property named '{fieldName}'.");
            }
            return (K)keyProperty.GetValue(Value);
        }
        public K GetField<K>(string fieldName)
        {
            var keyProperty = typeof(ValueType).GetProperty(fieldName);
            if (keyProperty == null)
            {
                throw new InvalidOperationException($"Type T does not have a property named '{fieldName}'.");
            }
            return (K)keyProperty.GetValue(Value);
        }
        public void SetField<K>(string fieldName, K value)
        {
            var keyProperty = typeof(ValueType).GetProperty(fieldName);
            if (keyProperty == null)
            {
                throw new InvalidOperationException($"Type T does not have a property named '{fieldName}'.");
            }
            keyProperty.SetValue(Value, value);
            Timestamp = DateTime.UtcNow;
        }
        // Correct indexer syntax
        public object this[string fieldName]
        {
            get
            {
                var keyProperty = typeof(ValueType).GetProperty(fieldName);
                if (keyProperty == null)
                {
                    throw new InvalidOperationException($"Type T does not have a property named '{fieldName}'.");
                }
                return keyProperty.GetValue(Value);
            }
            set
            {
                var keyProperty = typeof(ValueType).GetProperty(fieldName);
                if (keyProperty == null)
                {
                    throw new InvalidOperationException($"Type T does not have a property named '{fieldName}'.");
                }
                keyProperty.SetValue(Value, value);
                Timestamp = DateTime.UtcNow;
            }
        }
        public override string ToString()
        {
            return $"Item: {Value}, Timestamp: {Timestamp}";
        }
    }
}
