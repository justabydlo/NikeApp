using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Nike.Models
{
    public class UserRepository:IUserRepository
    {
        public bool IsModelCorrect(User user)
        {
            string correctLoginPassword = "admin";
            if (user.username.ToUpper() != correctLoginPassword.ToUpper() || user.password.ToUpper() != correctLoginPassword.ToUpper())
            {
                return false;
            }
            return true;
        }
        public void GetValidationErrors(ControllerContext ctx, User user)
        {
            string correctLoginPassword = "admin";
            if(user.username.ToUpper() != correctLoginPassword.ToUpper())
            {
                ctx.ModelState.AddModelError("username", "Здесь должно быть значение admin");
            }
            if(user.password.ToUpper() != correctLoginPassword.ToUpper())
            {
                ctx.ModelState.AddModelError("password", "Здесь должно быть значение admin");
            }
        }
    }
    public interface IUserRepository
    {
        public bool IsModelCorrect(User user);
        public void GetValidationErrors(ControllerContext ctx, User user);
    }
}
