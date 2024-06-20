using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.LoginDTO;


    public class LoginDTO
    {
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }

    }
