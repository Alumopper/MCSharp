using MCSharp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 控制屏幕标题。屏幕标题会以一行粗体大号文字的形式出现在玩家屏幕的中央，并且可以附加第二行作为副标题。标题和副标题均可使用原始JSON文本组件。屏幕标题可以设置为淡入淡出过渡，而显示持续时间同样可以设定。屏幕标题的大小取决于界面尺寸设置，而过长的标题不会自动换行（只会溢出屏幕之外）。
    /// <code>
    /// title &lt;player> (clear|reset)
    /// title &lt;player> (title|subtitle|actionbar) &lt;JSON>
    /// title &lt;player> times &lt;渐入> &lt;保持> &lt;渐出>
    /// </code>
    /// </summary>
    public class Title : Command
    {
        Entity player;
        Option? clear_reset = null;
        TitleType? title_subtitle_actionbar = null;
        JsonText jsonText;
        int fadeIn;
        int stay;
        int fadeOut;

        public enum Option
        {
            clear, reset
        }

        public enum TitleType
        {
            title, subtitle, actionbar
        }

        /// <summary>
        /// title &lt;player> (clear|reset)
        /// </summary>
        /// <param name="player"></param>
        /// <param name="clear_reset"></param>
        public Title(Entity player, Option clear_reset)
        {
            this.player = player;
            this.clear_reset = clear_reset;
        }

        /// <summary>
        /// title &lt;player> (title|subtitle|actionbar) &lt;JSON>
        /// </summary>
        /// <param name="player"></param>
        /// <param name="title_subtitle_actionbar"></param>
        /// <param name="jsonText"></param>
        public Title(Entity player, TitleType title_subtitle_actionbar, JsonText jsonText)
        {
            this.player = player;
            this.title_subtitle_actionbar = title_subtitle_actionbar;
            this.jsonText = jsonText;
        }

        /// <summary>
        /// title &lt;player> times &lt;渐入> &lt;保持> &lt;渐出>
        /// </summary>
        /// <param name="player"></param>
        /// <param name="fadeIn"></param>
        /// <param name="stay"></param>
        /// <param name="fadeOut"></param>
        public Title(Entity player, int fadeIn, int stay, int fadeOut)
        {
            this.player = player;
            this.fadeIn = fadeIn;
            this.stay = stay;
            this.fadeOut = fadeOut;
        }

        public override string ToString()
        {
            if (clear_reset != null)
            {
                return "title " + player + " " + clear_reset;
            }
            else if (title_subtitle_actionbar != null)
            {
                return "title " + player + " " + title_subtitle_actionbar + " " + jsonText;
            }
            else
            {
                return "title " + player + " times " + fadeIn + " " + stay + " " + fadeOut;
            }
        }
    }
}
