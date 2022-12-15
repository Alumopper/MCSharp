using MCSharp.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MCSharp.Type
{
    /// <summary>
    /// 颜色类，储存了颜色有关的信息
    /// </summary>
    public class Color
    {
        /// <summary>
        /// 聊天栏颜色枚举
        /// </summary>
        public enum Colors
        {
            black, dark_blue, dark_green, dark_aqua, dark_red, dark_purple, gold, gray, dark_gray, blue, green, aqua, red, light_purple, yellow, white 
        }
        
        public static Color black = new Color(0, 0, 0);
        public static Color dark_blue = new Color(0, 0, 170);
        public static Color dark_green = new Color(0, 170, 0);
        public static Color dark_aqua = new Color(0, 170, 170);
        public static Color dark_red = new Color(170, 0, 0);
        public static Color dark_purple = new Color(170, 0, 170);
        public static Color gold = new Color(255, 170, 0);
        public static Color gray = new Color(42, 42, 42);
        public static Color dark_gray = new Color(85, 85, 85);
        public static Color blue = new Color(85, 85, 255);
        public static Color green = new Color(85, 255, 85);
        public static Color aqua = new Color(85, 255, 255);
        public static Color red = new Color(255, 85, 85);
        public static Color light_purple = new Color(255, 85, 255);
        public static Color yellow = new Color(255, 255, 85);
        public static Color white = new Color(255, 255, 255);

        /// <summary>
        /// hex颜色码
        /// </summary>
        public Vector3<string> hex;

        public int r;
        public int g;
        public int b;
        public int alpha = 255;

        /// <summary>
        /// 根据RGB数值创建一个颜色对象
        /// </summary>
        public Color(int red,int green,int blue)
        {
            this.r = red;
            this.g = green;
            this.b = blue;
        }

        /// <summary>
        /// 根据RGBA数值创建一个颜色对象
        /// </summary>
        public Color(int red, int green, int blue, int alpha)
        {
            this.r = red;
            this.g = green;
            this.b = blue;
            this.alpha = alpha;
            hex = RGBtoHEX(red, green, blue);
        }

        /// <summary>
        /// 根据一个hex码字符串创建一个颜色对象
        /// </summary>
        /// <exception cref="IllegalFormatException">传入的hex码格式不正确</exception>
        public Color(string hex)
        {
            if (!Regex.IsMatch(hex, "^[#][a-zA-Z0-9]{6}$"))
            {
                throw new IllegalFormatException("无效的HEX颜色码:" + hex);
            }
            this.hex[0] = hex.Substring(1, 2);
            this.hex[1] = hex.Substring(3, 2);
            this.hex[2] = hex.Substring(5, 2);
            Vector3<int> qwq = HEXtoRGB(this.hex);
            r = qwq[0];
            g = qwq[1];
            b = qwq[2];
        }

        /// <summary>
        /// 将rgb转换为hex
        /// </summary>
        /// <returns></returns>
        private static Vector3<string> RGBtoHEX(int R, int G, int B)
        {
            return new Vector3<string>(R.ToString("x2"), G.ToString("x2"), B.ToString("x2"));
        }

        /// <summary>
        /// 将hex转换为rgb
        /// </summary>
        /// <returns></returns>
        private static Vector3<int> HEXtoRGB(Vector3<string> hex)
        {
            return new Vector3<int>(Convert.ToInt32(hex[0], 16), Convert.ToInt32(hex[1], 16), Convert.ToInt32(hex[2], 16));
        }

        public override string ToString()
        {
            return "#" + hex[0] + hex[1] + hex[2];
        }
    }
}
