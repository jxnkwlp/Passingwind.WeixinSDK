namespace Passingwind.Weixin.MP.Models.Media
{
    public class AddMaterialNewsArticleItemRequestModel
    {
        public string Title { get; set; }
        public string Thumb_Media_Id { get; set; }
        public string Author { get; set; }
        public string Digest { get; set; }
        public int Show_cover_pic { get; set; }
        public string Content { get; set; }
        public string Content_Source_Url { get; set; }

        public int Need_Open_Comment { get; set; }
        public int Only_Fans_Can_Comment { get; set; }
    }
}
