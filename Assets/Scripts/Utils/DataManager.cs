namespace CGArt.Utils
{
    using System.Collections.Generic;
    using UnityEngine;
    using System.IO;
    public class DataManager
    {
        private static DataManager _instance;
        protected Dictionary<string, object> data = new Dictionary<string, object>();
        protected Dictionary<string, List<object>> dataList = new Dictionary<string, List<object>>();
        protected static string path = Path.Combine(Application.persistentDataPath, "game_data.xml").ToString();

        private const string stringPrefix = "_stringdata";
        private const string intPrefix = "_intdata";
        private const string intListPrefix = "_int_list";
        private const string boolPrefix = "_booldata";
        private const string floatPrefix = "_floatdata";

        public static DataManager instance
        {
            private set { }
            get
            {
                if (_instance == null)
                {
                    _instance = new DataManager();
                    _instance.LoadData();
                }
                return _instance;
            }
        }

		public void AddListData(string key, List<int> value) {
			key += intListPrefix;
			List<object> listObject = new List<object>();

			if (data.ContainsKey(key))
			{
				data[key] = value;
			}
			else
			{
				data.Add(key, value);
			}

			if (!dataList.ContainsKey (key)) {
				dataList.Add(key, (List<object>)GetObject(key));
			} else {
				foreach(int num in value) {
					listObject.Add(num);
				}

				dataList.Remove(key);

				dataList.Add(key, listObject);
			}

			Save();
		}

        public void AddData(string key, object value)
		{
            if (data.ContainsKey(key))
            {
                data[key] = value;
            }
            else
            {
                data.Add(key, value);
            }
            Save();
        }

        public void AddString(string key, string value)
        {
            key += stringPrefix;
            AddData(key, value);
        }

        public void AddInt(string key, int value)
        {
            key += intPrefix;
            AddData(key, value);
        }

        public void AddFloat(string key, float value)
        {
            key += floatPrefix;
            AddData(key, value);
        }

        public void AddBool(string key, bool value)
        {
            key += boolPrefix;
            AddData(key, value);
        }

        public void AddIntToList(string key, int value)
        {
            List<int> data = GetIntList(key);
            if (data.Contains(value)) return;
            key += intListPrefix;
            data.Add(value);
            if (dataList.ContainsKey(key))
            {
                dataList[key].Add(value);
            }
            AddData(key, data);
        }

        public void RemoveIntFromList(string key, int value)
        {
            List<int> data = GetIntList(key);
            if (data.Contains(value))
            {
                data.Remove(value);
            }
            AddListData(key, data);

        }

        public object GetObject(string key)
        {
            if (!data.ContainsKey(key))
                return null;
            return data[key];
        }

        public string GetString(string key, string defaultValue)
        {
            key += stringPrefix;
            if (data.ContainsKey(key))
            {
                return (string)GetObject(key);
            }
            return defaultValue;
        }
        public string GetString(string key)
        {
            return GetString(key, "");
        }

        public int GetInt(string key, int defaultValue)
        {
            key += intPrefix;
            if (data.ContainsKey(key))
            {
                return System.Convert.ToInt32(GetObject(key));
            }
            return defaultValue;
        }
        public int GetInt(string key)
        {
            return GetInt(key, 0);
        }

        public float GetFloat(string key, float defaultValue)
        {
            key += floatPrefix;
            if (data.ContainsKey(key))
            {
                return (float)GetObject(key);
            }
            return defaultValue;
        }
        public float GetFloat(string key)
        {
            return GetFloat(key, 0);
        }

        public bool GetBool(string key, bool defaultValue)
        {
            key += boolPrefix;
            if (data.ContainsKey(key))
            {
                return (bool)GetObject(key);
            }
            return defaultValue;
        }

        public List<int> GetIntList(string key)
        {
            key += intListPrefix;
            if (data.ContainsKey(key))
            {
                if (!dataList.ContainsKey(key))
                {
                    dataList.Add(key, (List<object>)GetObject(key));
				}
                List<int> list = new List<int>();
                foreach (object obj in dataList[key])
                {
                    list.Add(System.Convert.ToInt32(obj));
                }
                return list;
            }
            if (!dataList.ContainsKey(key)) dataList.Add(key, new List<object>());
            return new List<int>();
        }

        public bool GetBool(string key)
        {
            return GetBool(key, false);
        }

        /// <summary>
        /// Convert data to json
        /// </summary>
        /// <returns></returns>
        protected string ToJsonString()
        {
            return Json.Serialize(data);
        }

        /// <summary>
        /// Encypt data before saving, child class override this for security method;
        /// </summary>
        /// <returns></returns>
        protected virtual string DataToJson()
        {
            return ToJsonString();
        }

        /// <summary>
        /// Decypt string, override for security purpose
        /// </summary>
        /// <param name="encryptedData">raw data</param>
        /// <returns></returns>
        protected virtual string DecryptData(string encryptedData)
        {
            return encryptedData;
        }

        public void Save()
        {
            string saveData = DataToJson();
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            writer.Write(saveData);
            writer.Close();
            fs.Close();
        }


        /// <summary>
        /// Loading data
        /// </summary>
        protected void LoadData()
        {
            if (File.Exists(path))
            {
				string dataString;
                Debug.Log(path);
                using(FileStream fs = new FileStream(path, FileMode.Open))
                using(StreamReader sr = new StreamReader(fs))
                	dataString = DecryptData(sr.ReadToEnd());
                Debug.Log(dataString);
                try
                {
                    data = Json.Deserialize(dataString) as Dictionary<string, object>;
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
            }
            else
            {
                Debug.Log("Error: " + path + "not existed!!!!!!");
            }
        }

        /// <summary>
        /// Remove all data
        /// </summary>
        public void ClearAllData()
        {
            data.Clear();
        }
    }
}