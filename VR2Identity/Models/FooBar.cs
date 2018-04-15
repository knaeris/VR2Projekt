using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VR2Identity.Models
{
    public class FooBar
    {
        public int FooBarId { get; set; }
        public string FooBarName { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
