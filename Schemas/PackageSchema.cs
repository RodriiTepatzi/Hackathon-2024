using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Hackathon_2024_API.Schemas
{
    public class PackageSchema
    {
        
        
        
        public float Weight { get; set; }
        
        public float Height { get; set; }
        
        public float Width { get; set; }
       
        public float Lenghth { get; set; }
        
        public string? ClientAddress { get; set; }
        
        public string? ClientFullName { get; set; }
        
        public string? ClientPhone { get; set; }
       
        
        public string? PackagePictureUrl { get; set; }
    }
}
