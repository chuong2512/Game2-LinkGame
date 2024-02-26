namespace CGArt.Utils
{
    using UnityEngine;
    using System.IO;

    public class SecureDataManager : DataManager
    {
        private static SecureDataManager _instance;
        public static new SecureDataManager instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SecureDataManager();
                    path = Path.Combine(Application.persistentDataPath, "game_secure_data.xml").ToString();
                    _instance.LoadData();
                }
                return _instance;
            }
        }

        private const string SECURITY_KEY = "ULhbMmIY4M";

        /// <summary>
        /// Convert data to enscrpyt json for saving to disk
        /// </summary>
        /// <returns></returns>
        protected override string DataToJson()
        {
            string enscryptedData = Security.Encrypt(ToJsonString(), SECURITY_KEY);
            return enscryptedData;
        }

        protected override string DecryptData(string encryptedData)
        {
            return Security.Decrypt(encryptedData, SECURITY_KEY);
        }
    }

}