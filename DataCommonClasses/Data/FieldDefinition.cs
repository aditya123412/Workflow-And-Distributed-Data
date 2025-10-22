namespace DataCommonClasses.Data
{
    public class FieldDefinition
    {
        public string Name { get; set; }
        public Type FieldType { get; set; }
        public bool IsNullable { get; set; }
        public FieldDataType DataType { get; set; }
        public int? MaxLength { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsUnique { get; set; }
        public bool IsExternallyReferencedData { get; set; }    // Indicates if the value in this comes from another list

        public FieldDefinition() { }
    }
    public record ExternalReferenceValue(
        string CollectionName,      //Name of the collection being referenced
        Type FieldType,     //Type of the field being referenced
        string IdFieldName    //Name of the ID field being referenced whose value is stored in this field
    );
    public enum Type
    {
        Primitive,
        Complex,
        Collection
    }
    public enum FieldDataType
    {
        String,
        Integer,
        Float,
        Boolean,
        DateTime,
        Binary,
        Object,
        Array
    }
}