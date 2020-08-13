using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSTechs.Common.DTO
{
    public class UsersDTO
    {
        public int Id { get; set; }
        public string Usrename { get; set; }

        public List<UsersDTO> Users { get; set; }

    }
}
