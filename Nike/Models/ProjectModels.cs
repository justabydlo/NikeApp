using System.ComponentModel.DataAnnotations;

namespace Nike.Models
{
    public class User
    {
        [Required(ErrorMessage = "Это поле должно быть заполнено")]
        public string username { get; set; }
        [Required(ErrorMessage = "Это поле должно быть заполнено")]
        public string password { get; set; }
    }
}
