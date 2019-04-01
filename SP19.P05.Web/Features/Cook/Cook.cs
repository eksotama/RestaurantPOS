using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SP19.P05.Common;
using SP19.P05.Web.Features.Authorization;

namespace SP19.P05.Web.Features.Cook
{
    public class Cook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
