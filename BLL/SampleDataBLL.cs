using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OurStore.Model;
using OurStore.DAL;

namespace OurStore.BLL
{
    public class SampleDataBLL
    {
        public static void Initialize()
        {
            System.Data.Entity.Database.SetInitializer(new OurStore.DAL.SampleData());
        }
    }
}