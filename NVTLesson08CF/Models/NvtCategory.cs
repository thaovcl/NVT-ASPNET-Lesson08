using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NVTLesson08CF.Models
{
    public class NvtCategory
    {
        [Key]
        public int NvtCategoryId { get; set; }
        public string CategoryName { get; set; }

        //Thuộc tính quan hệ
        public virtual ICollection<NvtBook> NvtBooks { get; set; }
    }
}