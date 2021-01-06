using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_27EFImages.data
{
    public class ImageRepository
    {

        private readonly String _conn;

        public ImageRepository(string connString)
        {
            _conn = connString;
        }

        public List<Image> GetImages()
        {
            using (var context = new ImageContext(_conn))
            {
                return context.Images.OrderByDescending(i=>i.UploadDate).ToList();
            }
        } 

        public void AddImage(Image i)
        {
            var context = new ImageContext(_conn);
            context.Images.Add(i);
            context.SaveChanges();
        }

        public void DeleteImage (int imageId)
        {
            var context = new ImageContext(_conn);
            var image = context.Images.FirstOrDefault(i => i.Id == imageId);
            context.Images.Remove(image);
            context.SaveChanges();
        }
        public void UpdateLikes(Image newImage)
        {
            var context = new ImageContext(_conn);
            var image = context.Images.FirstOrDefault(i => i.Id == newImage.Id);
            image.CountLikes = image.CountLikes + 1;
            context.SaveChanges();
        }

    }
}
