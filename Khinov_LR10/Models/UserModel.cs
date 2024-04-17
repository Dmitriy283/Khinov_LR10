using System.ComponentModel.DataAnnotations;
namespace Khinov_LR10.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string userName { get; set; }
        [Required(ErrorMessage = "E-mail is required")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Need correct e-mail adress")]
        public string email { get; set; }

        [Required(ErrorMessage = "Need a date")]
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        public string productConsult { get; set; }
        public static List<string> productConsultList = new()
        {
            "JavaScript",
            "C#",
            "Java",
            "Python",
            "Основи"
        };
    }

}
