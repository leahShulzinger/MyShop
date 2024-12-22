using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace DTO
{
    public record ProductDTO(int Id,string CategoryName,string ProductName,string Price,string Image,string DescreaptionProduct);
  
}
