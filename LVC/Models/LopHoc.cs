using System.ComponentModel.DataAnnotations;

namespace LVC.Models
{
    public class LopHoc
    {
        [Key]
        [Display(Name = "Mã lớp")]
        public int MaLop { get; set; }
        [Display(Name = "Tên lớp")]
        [MaxLength(50)]
        public string TenLop { get; set;}
        public ICollection<SinhVien>? SinhVien { get; set;}

    }
}