using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salary3
{
    public class Settings : ICloneable, 
        IEnumerable<KeyValuePair<string, string>> 
          
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
            return dict.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }



    }
}
