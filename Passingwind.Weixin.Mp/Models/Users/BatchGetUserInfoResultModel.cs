﻿using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.Models
{
    public class BatchGetUserInfoResultModel : JsonResultModel
    {
        public UserInfoResultModel[] User_Info_List { get; set; }
    }
}
