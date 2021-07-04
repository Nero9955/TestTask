using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace DapperP.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Поле должно быть установлено")]
        public string IpAdress { get; set; }
        //public IPAddress IPAddress { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Gender { get; set; }
    }
}
