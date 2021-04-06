using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models.ViewModels
{
    public class PageNumberingInfo
    {

        public int numItemsPerPage { get; set; }
        public int currentPage { get; set; }
        public int totalNumItems { get; set; }


        // calculate the number of pages
        public int numPages => (int) (Math.Ceiling((decimal) totalNumItems / numItemsPerPage));


    }
}
