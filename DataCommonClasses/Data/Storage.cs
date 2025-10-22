using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCommonClasses.Data
{
    internal class Storage<Tvalue, Tkey, TFileId>
    {
        private DataCollection<Tvalue> _dataCollection = new DataCollection<Tvalue>();      // The actual collection of data items
        private Dictionary<Tkey, Tvalue> _dataDictionary = new Dictionary<Tkey, Tvalue>();  // In-memory dictionary for quick key-based access

        private Dictionary<Tkey, TFileId> _keyFileMapping = new Dictionary<Tkey, TFileId>();    // Mapping of keys to their corresponding file IDs of the file containing the latest version of the data for that key

        private IEnumerable<TFileId> _fileIds;      // Ordered list of file IDs representing the files used for persistent storage
        private IEnumerable<DataRecordItem<Tvalue>> _tempDataItems; // Temporary storage for data items before persisting to files

        private TFileId currentFileId;
        ILogger _logger;
        public Storage(ILogger logger)
        {
            _dataCollection = new DataCollection<Tvalue>();
            _dataDictionary = new Dictionary<Tkey, Tvalue>();
            _keyFileMapping = new Dictionary<Tkey, TFileId>();
            _logger = logger;
        }

        public Storage(IEnumerable<TFileId> fileIds, ILogger logger)
        {
            // Load all existing data from the provided file IDs from persistent storage
            _logger = logger;
            _dataCollection = new DataCollection<Tvalue>();
            _dataDictionary = new Dictionary<Tkey, Tvalue>();
            _keyFileMapping = new Dictionary<Tkey, TFileId>();
            loadDataFromFile(fileIds);
        }

        public void AddData(Tkey key, Tvalue value)
        {
            TFileId fileId = getCurrentFileId(key);
            _logger.LogInformation("Storing data for key {Key} in file {FileId}", key, fileId);
            _dataDictionary[key] = value;
            _keyFileMapping[key] = fileId;

            DataRecordItem<Tvalue> tempItem = new(value);
            _dataCollection.AddItem(tempItem);
            _tempDataItems = _tempDataItems.Append(tempItem);
            _logger.LogInformation("Added data for key {Key} in file {FileId}", key, fileId);
        }

        public DataRecordItem<Tvalue>? GetData(Tkey key)
        {
            // Retrieve data associated with the given key from in-memory storage
            if (_dataDictionary.TryGetValue(key, out Tvalue value))
            {
                _logger.LogInformation("Retrieved data for key {Key}", key);
                return new DataRecordItem<Tvalue>(value);
            }
            _logger.LogWarning("Data for key {Key} not found", key);
            var fileId = _keyFileMapping.GetValueOrDefault(key);
            if (fileId == null)
            {
                _logger.LogWarning("File ID for key {Key} not found", key);
                return null;
            }
            else
            {
                // Logic to load data from persistent storage using fileId
            }
            return null;
        }

        private TFileId getCurrentFileId(Tkey key)
        {
            //Get current file id logic for current key
            // If creating new file id, update currentFileId and add to _fileIds
            throw new NotImplementedException();
        }

        private void PersistDataToFile(TFileId fileId)
        {
            // Logic to persist data associated with the given fileId to persistent storage
            File.WriteAllLines(fileId.ToString(), _tempDataItems.Select(item => serializeDataRecordItem(item)));

            throw new NotImplementedException();
        }

        private IEnumerable<DataRecordItem<Tvalue>> loadDataFromFile(IEnumerable<TFileId> fileId)
        {
            _fileIds = fileId;
            _fileIds.Reverse().SelectMany(id => loadDataFromSingleFile(id).Reverse());
            // Logic to load data associated with the given fileId from persistent storage
            // Read all values in reverse order to maintain correct order, and treat first occurrence as latest and
            // every subsequent occurrence as history
            throw new NotImplementedException();
        }

        private IEnumerable<object> loadDataFromSingleFile(TFileId id)
        {
            // Logic to load data from a single file, deserialize and return as DataRecordItem<Tvalue>
            throw new NotImplementedException();
        }

        private string serializeDataRecordItem(DataRecordItem<Tvalue> item)
        {
            // Logic to serialize DataRecordItem to string for storage
            var jsonString = System.Text.Json.JsonSerializer.Serialize(item);
            // TODO: Add logic to escape line breaks or other special characters if needed
            jsonString.Replace(Environment.NewLine, "\\n");
            return jsonString;
        }
        private DataRecordItem<Tvalue> deserializeDataRecordItem(string serializedItem)
        {
            // Logic to deserialize string back to DataRecordItem
            var jsonString = serializedItem.Replace("\\n", Environment.NewLine);
            return System.Text.Json.JsonSerializer.Deserialize<DataRecordItem<Tvalue>>(jsonString)!;
        }
    }
}
