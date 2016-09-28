using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckIn.Web.Utilities
{
    using System.IO;

    using Newtonsoft.Json;

    public class ImageUtility
    {
        //public string GetImage()
        //{
        //    string apPath = System.Web.Hosting.HostingEnvironment.MapPath("~/MyImages/profile.jpg");
        //    var imageBytes = ReadImageFile(apPath);
        //    var image = new ImageModel
        //    {
        //        UserId = 1.ToString(),
        //        ImageArray = imageBytes
        //    };
        //    var json = JsonConvert.SerializeObject(image);
        //    return json;
        //}

        public static byte[] ReadImageFile(string imageLocation)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo("D:\\Calc\\Id.jpg");
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream("D:\\Calc\\Id.jpg", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            return imageData;
        }

        public static string UploadAndGetImageUrl(byte[] imageArray)
        {
            var filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/MyImages/Chat/") + Guid.NewGuid()+ ".jpg";
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    System.IO.File.WriteAllBytes(filePath, imageArray);
                    return "success";
                }
                System.IO.File.WriteAllBytes(filePath, imageArray);
                
                return "success";
            }
            catch (Exception e)
            {
                return "ERROR";
            }
        }
    }
}