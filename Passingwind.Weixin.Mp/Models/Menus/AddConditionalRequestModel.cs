using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.Menus
{
    public class AddConditionalRequestModel : CreateMenuRequesetModel
    {
        /// <summary>
        ///  菜单匹配规则
        /// </summary>
        public MenuConditionalMatchRuleModel MatchRule { get; set; }
    }

    public class MenuConditionalMatchRuleModel
    {
        public int TagId { get; set; }
        public int? Sex { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public int? Client_Platform_Type { get; set; }
        /// <summary>
        ///  语言信息，是用户在微信中设置的语言，具体请参考语言表： 1、简体中文 "zh_CN" 2、繁体中文TW "zh_TW" 3、繁体中文HK "zh_HK" 4、英文 "en" 5、印尼 "id" 6、马来 "ms" 7、西班牙 "es" 8、韩国 "ko" 9、意大利 "it" 10、日本 "ja" 11、波兰 "pl" 12、葡萄牙 "pt" 13、俄国 "ru" 14、泰文 "th" 15、越南 "vi" 16、阿拉伯语 "ar" 17、北印度 "hi" 18、希伯来 "he" 19、土耳其 "tr" 20、德语 "de" 21、法语 "fr"
        /// </summary>
        public string Language { get; set; }
    }
}
