using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVkServer
{
    public class PostModel
    {
        public virtual int userId { get; set; }
        public virtual int id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string text { get; set; }
        public virtual int likesCount { get; set; }
    }
}
