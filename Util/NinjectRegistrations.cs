using FinalLab.Models;
using FinalLab.Util;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalLab.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICinemaSystem>().To<CinemaSystem>();
        }
    }
}