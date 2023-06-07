using System.Collections.Generic;
using System.Linq;

namespace Persistence.Systems
{
    [System.Serializable]
    [SaveableData]
    public class DataClassesVersionStorage
    {
        public List<Entry> entries;
        public Dictionary<string, string> versionsDict;

        public void SetEntry(string id, string version)
        {
            if (versionsDict.ContainsKey(id))
            {
                versionsDict[id] = version;
                var entry=entries.Single(n => n.id == id);
                entry.version=version;
            }
            else
            {
                entries.Add(new Entry(){id=id,version = version});
                versionsDict.Add(id,version);
            }
        }
        public void Initialize()
        {
            if(entries!=null&&entries.Count>0)
                versionsDict = entries.ToDictionary(a => a.id,a=> a.version);
            else
            {
                entries = new List<Entry>();
                versionsDict = new Dictionary<string, string>();
            }
        }
        [System.Serializable]
        public class Entry
        {
            public string id;
            public string version;
        }
    }
}