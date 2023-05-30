using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ALevelSample.Dtos.Responses
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}
