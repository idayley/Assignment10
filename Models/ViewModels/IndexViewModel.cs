using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models.ViewModels
{ 
    // list out the bowlers for the view
    public class IndexViewModel
    {
        public List<Bowlers> bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }

        public string TeamNameId { get; set; }

    }
    
}
