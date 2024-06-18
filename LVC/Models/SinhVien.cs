using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVC.Models
{
    public class SinhVien
    {
       
        [Display(Name = "Mã sinh viên")]
        [MaxLength(20)]
         [Key]
        public string MaSinhVien { get; set; }
        [Display(Name = "Họ và tên")]
        [MaxLength(50)]
        public string HoTen { get; set;}
        [Display(Name = "Mã lớp")]
        [ForeignKey("MaLop")]
        public int? MaLop { get; set; }
        [Display(Name = "Mã lớp")]
        public LopHoc? LopHoc { get; set; }

    }
}