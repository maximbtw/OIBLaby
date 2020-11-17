using System.Data.Entity;
using System.Linq;

namespace OIB.Lab2
{
    class DBManager
    {
        /// <summary>
        /// Добавить пользователя в базу данных
        /// </summary>
        public static void AddUser(User user,Profile profile)
        {
            using (var db = new MyDBContext())
            {
                if (db.Users.Any(x => x.Login.Equals(user.Login)))
                {
                    Helper.ErrorMessage("Пользователь с таким логином уже существует");
                }
                else if (db.Users.Any(x => x.Password.Equals(user.Password)))
                {
                    Helper.ErrorMessage("Пользователь с таким паролем уже существует");
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    profile.UserId = user.Id;
                    db.UserProfiles.Add(profile);
                    db.SaveChanges();
                    Helper.InformationMessage("Регистрация успешно завершина", "Регистрация");
                }
            }
        }

        /// <summary>
        /// Проверить корректность данных; Вход в программу
        /// </summary>
        public static void Entrance(string login, string pasword)
        {
            using (var db = new MyDBContext())
            {
                if (!db.Users.Any(x => x.Login.Equals(login)))
                {
                    Helper.ErrorMessage("Пользователь с таким логином не существует");
                }
                else if (!db.Users.FirstOrDefault(x=>x.Login.Equals(login)).Password.Equals(pasword))
                {
                    Helper.ErrorMessage("Пароли не совпадают");
                }
                else
                    Helper.InformationMessage("Вход успешно выполнен", "Вход");
            }
        }

        /// <summary>
        /// Смена пароля
        /// </summary>
        public static void ChangePassword(string oldPassword, string newPassword)
        {
            using (var db = new MyDBContext())
            {
                User user = db.Users.FirstOrDefault(x=>x.Password.Equals(oldPassword));

                if (user != null)
                {
                    user.Password = newPassword;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    Helper.InformationMessage("Пароль успешно изменён", "Смена пароля");
                }
                else Helper.ErrorMessage("Пользователь с таким паролем не существует");

            }
        }

        /// <summary>
        /// Проверка пароля на корректность в соответствии с заданием
        /// </summary>
        public static bool PasswordVerification(string password)
        {
            if (password.Length != password.Distinct().Count())
            {
                Helper.ErrorMessage("Пароль имеет повторяющиеся символы");
                return false;
            }
            if (!password.All(x => char.IsLetter(x)))
            {
                Helper.ErrorMessage("В пароле должны быть только буквы");
                return false;
            }
            return true;
        }
    }
}
