using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tejedor.Infrastructure.DTO.UserDTO;
using Tejedor.Infrastructure.Entity;

namespace Tejedor.Infrastructure.DTO.AuthDTO;


    public class LoginDTO
    {
        public required string UserName { get; set; }
        public required string UserPassword { get; set; }

        public static explicit operator LoginDTO(User user)
        {
            return new LoginDTO()
            {
                UserName = user.UserName,
                UserPassword = user.UserPassword,
            };
        }
    }
