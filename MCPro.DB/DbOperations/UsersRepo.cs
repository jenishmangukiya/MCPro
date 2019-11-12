using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCProj.Models;

namespace MCPro.DB.DbOperations
{
    public class UsersRepo
    {
        //Signup
        public int GetRegister(Models.RegisterModel model)
        {
            using (var context = new MusicDBEntities())
            {
                Users u = new Users()
                {
                    Fname = model.Fname,
                    Lname = model.Lname,
                    Email = model.Email,
                    Pwd = model.Pwd,
                    Role = "User"
                };

                context.Users.Add(u);

                context.SaveChanges();

                return u.Id;
            }
        }

        //Login
        public int Login(Models.LoginModel model)
        {
            using (var context = new MusicDBEntities())
            {
                //bool isValid = context.Users.Any(x=>x.Email == model.Email && x.Pwd == model.Pwd);

                bool isUser = context.Users.Any(x => x.Role == "User" && x.Email==model.Email && x.Pwd == model.Pwd);

                bool isAdmin = context.Users.Any(x => x.Role == "Admin" && x.Email == model.Email && x.Pwd == model.Pwd);

                if (isUser)
                    return 1; // is simple user
                else if (isAdmin)
                    return 2; // is admin user
                else
                    return 0; // not valid
            }
        }

        //Get user info
        public UsersModel GetInfo(string email)
        {
            using (var context = new MusicDBEntities())
            {
                Users u = context.Users.Where(x => x.Email == email).FirstOrDefault();

                UsersModel um = new UsersModel()
                {
                    Fname = u.Fname,
                    Lname=u.Lname,
                    Email=u.Email,
                    Pwd=u.Pwd
                };

                return um;
            }
        }
    }
}
