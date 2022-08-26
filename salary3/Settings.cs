using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salary3
{
    public class Settings : ICloneable, 
        IEnumerable<KeyValuePair<string, string>>,
        IComparable<Settings>
          
    {        
        private readonly IDictionary<string, string> dict = new Dictionary<string, string>();

        private Settings(Settings s)
        {
            dict = new Dictionary<string, string>(s.dict);
        }
        public Settings() 
        {
            AddConfigFile("Global.cfg");

            string userConfigFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\User.cfg";
            if (File.Exists(userConfigFile)) 
            {
                AddConfigFile(userConfigFile);
            }
        }

        public string GetSetting(string key) 
        { 
            return dict[key];
        }
        public void AddConfigFile(string path)
        {        
            using (StreamReader file = new StreamReader(path))
            {
                while (!file.EndOfStream)
                {
                    var fileLine = file.ReadLine();
                    var fragments = fileLine.Split('=', 2);
                    string key = fragments[0];
                    string value = fragments[1];
                    dict[key] = value;
                }
            }
        }

        public object Clone()
        {
            return new Settings(this);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return new SettingsEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(Settings? other)
        {
            int thisSize = this.dict.Count;
            int otherSize = other.dict.Count;
            if (thisSize == otherSize)
            {
                return 0;
            }
            else if (thisSize < otherSize)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        class SettingsEnumerator : IEnumerator<KeyValuePair<string, string>>
        {
            readonly IEnumerator<KeyValuePair<string, string>> dictEnumerator;

            public SettingsEnumerator(Settings settings)
            {
                dictEnumerator = settings.dict.GetEnumerator();
            }
            public KeyValuePair<string, string> Current => dictEnumerator.Current;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                dictEnumerator.Dispose();
            }

            public bool MoveNext()
            {
                return dictEnumerator.MoveNext();
            }

            public void Reset()
            {
                dictEnumerator.Reset();
            }
        }


    }
}
