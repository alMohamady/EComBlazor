using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComBlazor.lib.DTOs
{
    public class LogInResponseDto
    {
        public LogInResponseDto(bool _success = false, string _msessage = "", string token = "", string refreshToken = "")
        {
            success = _success;
            msessage = _msessage;
            Token = token;
            RefreshToken = refreshToken;
        }

        public bool success { get; set; }
        public string msessage { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
