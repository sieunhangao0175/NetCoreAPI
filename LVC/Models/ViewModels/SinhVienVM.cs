using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVC.Models.ViewModels
{
    public class SinhVienVM
    {
       
        [Display(Name = "Mã sinh viên")]
       
        public string MaSinhVien { get; set; }
        [Display(Name = "Họ và tên")]
       
        public string HoTen { get; set;}
        [Display(Name = "Mã lớp")]
        
        public int? MaLop { get; set; }
        [Display(Name = "Tên lớp")]
        public string TenLop { get; set; }

    }
}