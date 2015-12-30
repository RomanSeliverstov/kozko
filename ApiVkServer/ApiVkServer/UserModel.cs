using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVkServer
{
   public class UserModel
    {
        public virtual int ownerId { get; set; }
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string City { get; protected internal set; }
        public virtual List<PostModel> Posts { get;  set; }
       

    }
}
