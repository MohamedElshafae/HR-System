using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.Core.DTOs
{
    public class FileDto
    {
        public byte[] bytes { get; set; }
        public string contentType { get; set; }
        public string path { get; set; }
        public bool isSuccess {  get; set; }
    }
}
