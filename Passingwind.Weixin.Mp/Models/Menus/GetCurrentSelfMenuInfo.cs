using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Mp.Models.Menus
{
    public class GetCurrentSelfMenuInfo : MenuResultModel
    {
        public int Is_Menu_Open { get; set; }

        public MenuModel Button { get; set; }
    }

    //public class SelfMenuInfoModel
    //{
    //    public IList<MenuButtonModel> Button { get; set; }
    //}
}
