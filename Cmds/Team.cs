using MCSharp.Type;
using MCSharp.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MCSharp.Cmds
{
    /// <summary>
    /// 管理队伍。
    /// <code>
    /// team list [&lt;team>]
    /// team add &lt;team> [&lt;displayName>]
    /// team remove &lt;team>
    /// team empty &lt;team>
    /// team join &lt;team> [&lt;members>]
    /// team leave &lt;members>
    /// team modify &lt;team> &lt;option> &lt;value>
    /// </code>
    /// </summary>
    public class Team : Command{

        string team;
        JsonText displayName;
        re remove_empty;
        int type;
        Entity members;
        OptionBool optionBool;
        bool valueBool;
        Color valueColor;
        OptionColor optionColor;
        OptionJSON optionJSON;
        JsonText jsonText;

        public enum re
        {
            remove,empty
        }

        public enum OptionBool
        {
            friendlyFire, seeFriendlyInvisibles, nametagVisibility, deathMessageVisibility, collisionRule
        }      
        public enum OptionJSON
        {
            displayName, prefix, suffix
        }        
        public enum OptionColor
        {
            color
        }
        
        /// <summary>
        /// team list [&lt;team>]
        /// </summary>
        /// <param name="team"></param>
        public Team(string team = null)
        {
            this.team = team;
            type = 0;
        }

        /// <summary>
        /// team add &lt;team> [&lt;displayName>]
        /// </summary>
        /// <param name="team"></param>
        /// <param name="displayName"></param>
        public Team(string team, JsonText displayName = null) : this(team)
        {
            this.displayName = displayName;
            type = 1;
        }

        /// <summary>
        /// team (remove|empty) &lt;team>
        /// </summary>
        /// <param name="remove_empty"></param>
        /// <param name="team"></param>
        public Team(re remove_empty, string team)
        {
            this.remove_empty = remove_empty;
            this.team = team;
            type = 2;
        }

        /// <summary>
        /// team join &lt;team> [&lt;members>]
        /// </summary>
        /// <param name="team"></param>
        /// <param name="members"></param>
        public Team(string team, Entity members)
        {
            this.team = team;
            this.members = members;
            type = 3;
        }

        /// <summary>
        /// team leave &lt;members>
        /// </summary>
        /// <param name="members"></param>
        public Team(Entity members)
        {
            this.members = members;
            type = 4;
        }

        /// <summary>
        /// team modify &lt;team> &lt;option> &lt;value>
        /// </summary>
        /// <param name="team"></param>
        /// <param name="option"></param>
        /// <param name="value"></param>
        public Team(string team, OptionBool option, bool value)
        {
            this.team = team;
            this.optionBool = option;
            this.valueBool = value;
            type = 5;
        }

        /// <summary>
        /// team modify &lt;team> &lt;option> &lt;value>
        /// </summary>
        /// <param name="team"></param>
        /// <param name="option"></param>
        /// <param name="value"></param>
        public Team(string team, OptionColor option, Color value)
        {
            this.team = team;
            this.optionColor = option;
            this.valueColor = value;
            type = 6;
        }

        /// <summary>
        /// team modify &lt;team> &lt;option> &lt;value>
        /// </summary>
        public Team(string team, OptionJSON option, JsonText jsonText)
        {
            this.team = team;
            this.optionJSON = option;
            this.jsonText = jsonText;
            type = 7;
        }

        public override string ToString()
        {
            string re = "team ";
            switch (type)
            {
                case 0:
                    re += " list";
                    if (team != null)
                        re += " " + team;
                    break;
                case 1:
                    re += " add " + team;
                    if (displayName != null)
                        re += " " + displayName;
                    break;
                case 2:
                    re += " " + Tools.getEnumString(remove_empty) + " " + team;
                    break;
                case 3:
                    re += " join " + team;
                    if (members != null)
                        re += " " + members;
                    break;
                case 4:
                    re += " leave " + members;
                    break;
                case 5:
                    re += " modify " + team + " " + Tools.getEnumString(optionBool) + " " + valueBool;
                    break;
                case 6:
                    re += " modify " + team + " " + Tools.getEnumString(optionColor) + " " + valueColor;
                    break;
                case 7:
                    re += " modify " + team + " " + Tools.getEnumString(optionJSON) + " " + jsonText;
                    break;
            }
            return re;
        }
    }
}
