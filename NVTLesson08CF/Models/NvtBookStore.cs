using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NVTLesson08CF.Models
{
    public class NvtBookStore:DbContext
    {
        public NvtBookStore() : base("NvtBookStoreConnectionString")
        {

        }

        //Tạo các bảng
        public DbSet<NvtCategory> NvtCategories { get; set; }
        public DbSet<NvtBook> NvtBooks { get; set; }

    }
}