using DataCommonClasses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommonClasses.Operations
{
    public interface SchemaOperations
    {
        public Schema GetSchema(string schemaName);
        public IEnumerable<Schema> GetAllSchemas();
        public Schema CreateSchema(Schema schema);
        public Schema UpdateSchema(Schema schema, IOperations operations);
    }
}
