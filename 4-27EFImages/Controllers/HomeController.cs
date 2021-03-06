﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _4_27EFImages.Models;
using Microsoft.Extensions.Configuration;
using _4_27EFImages.data;


namespace _4_27EFImages.Controllers
{
    public class HomeController : Controller
    {
        private String _conn;
        public HomeController(IConfiguration configuration)
        {
            _conn = configuration.GetConnectionString("ConStr");
        }

        public IActionResult Index()
        {
            //var db = new ImageRepository(_conn);
            //return View(db.GetImages());
             return View();
        }

        public IActionResult GetImages()
        {
            
            var db = new ImageRepository(_conn);
            var vm = new ImageJsonModel();
            vm.Images = db.GetImages();
            vm.LikedImageIds = Request.Cookies["likedyet"]; //this is used in the js to determine if like button is enabled. 

            return Json(vm);
        }

        [HttpPost]
        public void AddImage(Image i)
        {
            var db = new ImageRepository(_conn);
            i.UploadDate = DateTime.Now;
            db.AddImage(i);
        }

        [HttpPost]
        public void DeleteImage(int imageId)
        {
            var db = new ImageRepository(_conn);
            db.DeleteImage(imageId);
        }

        [HttpPost]
        public void UpdateLikes(Image i)

        {
            //update the likecount in the db and append the imageid to the list of liked ids. This approach is if the button will be disabled after image is liked so the user doesn't have a chance to like it again. 
                
                string imageids= Request.Cookies["likedyet"]; //get the cookie value

                //update the db
                var db = new ImageRepository(_conn);
                db.UpdateLikes(i);              

               //2) set the cookie to latest list of liked ids
               if (string.IsNullOrEmpty(imageids) )  //cookie doesn't exist yet; user never liked any images yet
               {
                imageids = $"{i.Id}";
                }

               else //cookie does exist, add the id to the list of existing ids. 
                 {
                   imageids += $",{i.Id}";
                 }

                Response.Cookies.Append("likedyet", $"{imageids}"); //sets the cookie to hold the latest list of liked ids.
        }

        //another way to identify if user can like an image (this is if  the button is not disabled in the view once liked). 
        // public IActionResult UpdateLikes(Image i)

        //{
        //    //Only update like count if the user didn't yet like the image; only 1 like per user per image. 

        //    //bool alreadyliked = true; //this will be used to set the json object //
        //    string imageids = Request.Cookies["likedyet"]; //get the cookie value

        //    if (string.IsNullOrEmpty(imageids) || (!imageids.Contains(i.Id.ToString()))) //if cookie doesn't exist yet (never liked yet) or this image id is not yet in the cookie (didn't like this image yet)
        //    {
        //        //1) update the like count
        //        alreadyliked = false;
        //        var db = new ImageRepository(_conn);
        //        db.UpdateLikes(i);


        //    //2) set the cookie to latest list of liked ids
        //    if (string.IsNullOrEmpty(imageids))  //cookie doesn't exist yet; user never liked any images yet
        //    {
        //        imageids = $"{i.Id}";
        //    }

        //    else //cookie does exist, add the id to the list of existing ids. 
        //    {
        //        imageids += $",{i.Id}";
        //    }

        //    Response.Cookies.Append("likedyet", $"{imageids}"); //sets the cookie to hold the latest list of liked ids.
        //                                                        //     }

        //        //3) create anonymous json object so we can use "alreadyliked"  property in js to know if alert should be shown or not
        //        var jsonObject = new
        //        {
        //            alreadyliked
        //        };

        //        // return Json(jsonObject);
        //    }

    }
}
