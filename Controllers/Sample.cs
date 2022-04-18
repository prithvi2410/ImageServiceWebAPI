using Microsoft.AspNetCore.Mvc;
using WebApiSample.Model;

namespace WebApiSample.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SampleController : ControllerBase
{
     [HttpPost]
    public String Upload(IFormFile? postedFile)
    {
        if(postedFile==null)
        {
            return "please insert an image";
        }

        byte[] imageData;
        using(BinaryReader reader = new BinaryReader(postedFile.OpenReadStream()))
        {
            imageData=reader.ReadBytes((int)postedFile.Length);
        }
        Image image = new Image()
        {
            
            Name=postedFile.FileName,
            Data=imageData,
            Type=postedFile.ContentType
        };
        ImageContext db = new ImageContext();
        db.Add(image);
        db.SaveChanges();

        return "image uploaded";
    }

    [HttpGet]
    public List<Image> ViewImages()
    {
        ImageContext db = new ImageContext();
        List<Image> images = new List<Image>();
        images=db.Images.ToList();
        return images;
    }
}