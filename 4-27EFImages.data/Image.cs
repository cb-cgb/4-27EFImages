using System;
using System.Collections.Generic;
using System.Text;

namespace _4_27EFImages.data
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime UploadDate { get; set; }
        public int CountLikes { get; set; }
    }
       

}
