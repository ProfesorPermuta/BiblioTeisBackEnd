using Microsoft.AspNetCore.Mvc;
using System.IO;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly string _imageDirectory = Path.Combine(
        Directory.GetCurrentDirectory(),
        "wwwroot",
        "images"
    );

    // GET: api/image/sample.jpg
    [HttpGet("{imageName}")]
    public IActionResult GetImage(string imageName)
    {
        var filePath = Path.Combine(_imageDirectory, imageName);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound(new { message = "Image not found" });
        }

        var imageFileStream = System.IO.File.OpenRead(filePath);
        var contentType = GetContentType(filePath);

        return File(imageFileStream, contentType);
    }

    private string GetContentType(string path)
    {
        var extension = Path.GetExtension(path).ToLowerInvariant();
        return extension switch
        {
            ".png" => "image/png",
            ".jpg" => "image/jpeg",
            ".jpeg" => "image/jpeg",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            ".webp" => "image/webp",
            _ => "application/octet-stream",
        };
    }
}
