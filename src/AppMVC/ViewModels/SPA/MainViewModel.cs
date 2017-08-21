using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppMVC.ViewModels.SPA
{
    public class MainViewModel
    {
        public string UserName { get; set; }
        public FooterViewModel FooterData { get; set; }//New Property
    }
}