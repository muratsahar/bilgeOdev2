using bilgeOdev2.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bilgeOdev2.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public User User { get; set; }
    }
}