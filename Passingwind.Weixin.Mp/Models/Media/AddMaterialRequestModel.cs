using Passingwind.Weixin.Models;

namespace Passingwind.Weixin.MP.Models.Media
{
    public class AddMaterialRequestModel 
    {
        public MediaType Type { get; set; }

        public UploadFileModel Media { get; set; }

		public MediaDescription Description { get; set; }
    }
}
