using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class SendFeedback
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Notes { get; set; }
    }
}
