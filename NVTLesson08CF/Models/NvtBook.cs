using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NVTLesson08CF.Models
{
    /// <summary>
    /// Tạo ra cấu trúc bảng
    /// </summary>
    public class NvtBook
    {
        [Key]
        public int NvtBookId { get; set; }
        public string NvtTitle { get; set; }
        public string NvtAuthor { get; set; }
        public int NvtYear { get; set; }
        public string NvtPublisher { get; set; }
        public string NvtPicture { get; set; }
        public int NvtCategoryId { get; set; }

        //Thuộc tính qhe
        public virtual NvtCategory GetNvtCategory  { get; set; }




    }
}