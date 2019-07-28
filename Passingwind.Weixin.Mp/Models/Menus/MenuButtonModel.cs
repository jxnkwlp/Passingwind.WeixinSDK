using System.Collections.Generic;

namespace Passingwind.Weixin.MP.Models.Menus
{
    public class MenuButtonModel
    {
        public MenuButtonType? Type { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public IList<MenuButtonModel> Sub_Button { get; set; }

        public string Key { get; set; }

        public string Media_Id { get; set; }

        public string AppId { get; set; }

        public string PagePath { get; set; }

        public string Value { get; set; }

        public MenuButtonNewsInfoListModel News_Info { get; set; }
    }

    public enum MenuButtonType
    {
        Unknow = 0,

        Click,
        View,
        Scancode_Push,
        Scancode_Waitmsg,
        Pic_Sysphoto,
        Pic_Photo_Or_Album,
        Pic_Weixin,
        Location_Select,
        Media_Id,
        View_Limited,
    }

    public class MenuButtonNewsInfoListModel
    {
        public IList<MenuButtonNewsInfoModel> List { get; set; }
    }

    public class MenuButtonNewsInfoModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Digest { get; set; }
        public int ShowCover { get; set; }
        public string Cover_Url { get; set; }
        public string Content_Url { get; set; }
        public string Source_Url { get; set; }
    }
}
