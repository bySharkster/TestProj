using System.Drawing;

namespace TestProj.Models
{
    public class Constants
    {
        public static bool IsDev = true;

        public static Color LightModeBackgroundColor = Color.FromArgb(57, 234, 184);
        public static Color DarkModeBackgroundColor = Color.FromArgb(30, 30, 30);
        public static Color MainTextColor = Color.White;

        public static double LoginIconHeight = 120;


        //------Login------------
        public static string LoginUrl = "https://test.com/api/Auth.Login";

        public static object NoInternetText = "No internet, please reconnect";
    }
}

