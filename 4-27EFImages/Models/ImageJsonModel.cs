using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4_27EFImages.data;

namespace _4_27EFImages.Models
{
    public class ImageJsonModel
    {
        public List<Image> Images { get; set; }
        public String LikedImageIds { get; set; }
    }
}
