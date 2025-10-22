using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommonClasses.Data
{
    public class DataCollection<T>
    {
        private IEnumerable<DataRecordItem<T>> _items;
        public DataCollection()
        {
            _items = new List<DataRecordItem<T>>();
        }
        public DataCollection(IEnumerable<DataRecordItem<T>> items)
        {
            _items = items;
        }
        public IEnumerable<DataRecordItem<T>> GetItemsById(object id, string fieldName)
        {
            return _items.Where(item => item.GetKeyField<object>()!.Equals(id));
        }

        public IEnumerable<DataRecordItem<T>> GetAllItemsByCondition(Func<DataRecordItem<T>, bool> predicate)
        {
            return _items.Where(item => predicate(item));
        }
        public void AddItem(DataRecordItem<T> item)
        {
            _items = _items.Append(item);
        }
        public DataRecordItem<T> RemoveItem(Func<DataRecordItem<T>, bool> predicate)
        {
            var itemToRemove = _items.FirstOrDefault(predicate);
            if (itemToRemove != null)
            {
                _items = _items.Where(item => !predicate(item));
            }
            return itemToRemove!;
        }

        public void UpdateItem(Func<DataRecordItem<T>, bool> predicate, DataRecordItem<T> newItem)
        {
            // Replace the matching item with the new item
            _items = _items.Select(item => predicate(item) ? newItem : item);
        }

        public Dictionary<K, DataRecordItem<T>> ToDictionary<K>(string fieldName, Func<DataRecordItem<T>, bool> predicate)
        {
            return _items.Where(predicate).ToDictionary(item => item.GetKeyField<K>(fieldName));
        }
    }
}
