using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.WeixinSDK.Models
{
	public class GetWXACodeRequest
	{
		public string path { get; set; }
		public int? width { get; set; }
		public bool? auto_color { get; set; }
		public string line_color { get; set; }
		public bool? is_hyaline { get; set; }
	}
}
