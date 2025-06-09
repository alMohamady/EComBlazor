using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.DTOs
{
    public class ResponseDto
    {
        public ResponseDto(bool _success = false, string _msessage = null!)
        {
            success = _success;
            msessage = _msessage;
        }

        public bool success { get; set; }   

        public string msessage { get; set; }
    }
}
