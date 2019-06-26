using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.WeixinSDK.Models
{
	public class GetWXACodeUnlimitRequest
	{
		public string scene { get; set; }
		public string page { get; set; }
		public int? width { get; set; }
		public bool? auto_color { get; set; }
		public string line_color { get; set; }
		public bool? is_hyaline { get; set; }
	}
}
