using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TimeWidget
{
    public static class SaveFile
    {
        private static BinaryFormatter binaryFormatter = new BinaryFormatter();
        public static Save save = new Save();

        public static string dirPath;
        public static string savePath;

        public static void Init()
        {
            dirPath = Path.GetFullPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "TimeWidget"));
            savePath = Path.Combine(dirPath, "config.dat");

            if (Directory.Exists(dirPath) == false)
            {
                Directory.CreateDirectory(dirPath);

                using (Stream stream = File.OpenWrite(savePath))
                {
                    binaryFormatter.Serialize(stream, save);
                }
            }
            else
            {
                using (Stream stream = File.OpenRead(savePath))
                {
                    save = (Save)binaryFormatter.Deserialize(stream);
                }
            }
        }

        public static void SaveConfig()
        {
            using (Stream stream = File.OpenWrite(savePath))
            {
                binaryFormatter.Serialize(stream, save);
            }
        }

        [Serializable]
        public class Save
        {
            /// <summary>
            /// Start window pos
            /// </summary>
            public int[] p = new int[2] { 0, 0 };
            /// <summary>
            /// Transparent color
            /// </summary>
            public int[] c = new int[3] { 0, 0, 0 };
        }
    }
}
