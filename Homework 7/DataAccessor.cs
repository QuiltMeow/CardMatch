using System.Runtime.InteropServices;
using System.Text;

namespace Homework_7
{
    internal class DataAccessor
    {
        private const string AESKey = "EW_Quilt_Flandre_Meow";

        public static bool writeHighScore(int score)
        {
            try
            {
                WritePrivateProfileString("HighScore", "score", AESTool.AESEncryptBase64(score.ToString(), AESKey), "./Quilt.ew");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int readHighScore()
        {
            StringBuilder retVal = new StringBuilder(0xFF);
            GetPrivateProfileString("HighScore", "score", "0", retVal, 0xFE, "./Quilt.ew");

            try
            {
                string decrypt = AESTool.AESDecryptBase64(retVal.ToString(), AESKey);
                return int.Parse(decrypt);
            }
            catch
            {
                writeHighScore(0);
                return 0;
            }
        }

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", CharSet = CharSet.Unicode)]
        private static extern uint GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern uint WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}