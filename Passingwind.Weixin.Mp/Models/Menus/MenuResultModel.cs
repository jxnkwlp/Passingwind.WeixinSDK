using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Mp.Models.Menus
{
    public class MenuResultModel : JsonResultModel
    {
        /// <summary>
        ///  默认菜单
        /// </summary>
        public MenuModel Menu { get; set; }

        public int Menuid { get; set; }

        /// <summary>
        ///  个性化菜单
        /// </summary>
        public MenuModel ConditionalMenu { get; set; }
    }

    public class MenuModel
    {
        public IList<MenuButtonModel> Button { get; set; }
    }
}
