using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommonClasses.Data
{
    // / <summary>
    // / This class is to be used when multiple items are expected to be returned from a data query, as a shorthand for Group-by clause.
    // / Represents an enumerable collection of data record items with key-based retrieval capabilities.
    // / Key: The type of the key used for identifying items. This is typically the type of the unique identifier field in the item.
    // </summary>
    public class DataRecordItemsEnumerable<Key, ItemValue> : DataRecordItem<ItemValue>
    {
        private string _groupIdFieldName = "Id";
        private IEnumerable<DataRecordItem<ItemValue>> _items;
        public Key GroupId
        {
            get
            {
                return _items.First().GetKeyField<Key>(_groupIdFieldName);
            }
            set
            {
                foreach (var item in _items)
                {
                    item.SetField<Key>(_groupIdFieldName, value);
                }
            }
        }

        public DataRecordItemsEnumerable(ItemValue item) : base(item)
        {
            _items = new List<DataRecordItem<ItemValue>>() { new DataRecordItem<ItemValue>(item) };
            this.IsIterable = true;
        }
        public DataRecordItemsEnumerable(IEnumerable<DataRecordItem<ItemValue>> items) : base(default(ItemValue)!)
        {
            _items = items;
        }
        public IEnumerable<DataRecordItem<ItemValue>> GetItemsById(Key id, string fieldName)
        {
            return _items.Where(item => item.GetKeyField<Key>(fieldName)!.Equals(id));
        }
        public IEnumerable<DataRecordItem<ItemValue>> GetAllItemsByCondition(Func<DataRecordItem<ItemValue>, bool> predicate)
        {
            return _items.Where(item => predicate(item));
        }
    }
}
