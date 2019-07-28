using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models.QrCode
{
    public class QrCodeCreateRequestModel
    {
        public int? Expire_Seconds { get; set; }
        public string Action_Name { get; set; }
        public QrCodeActionInfoModel Action_Info { get; set; }
    }

    public class QrCodeActionInfoModel
    {
        public QrCodeSceneModel Scene { get; set; }
    }

    public class QrCodeSceneModel
    {
        public string Scene_Id { get; set; }
        public string Scene_Str { get; set; }
    }
}
