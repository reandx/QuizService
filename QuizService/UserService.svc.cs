using System.Web;
using System.Linq;

namespace QuizService
{
    public class UserService : IUserService
    {
        #region "Constants"

        private const string EntityKey = "ServiceKey";

        #endregion

        #region "Properties"

        public static QuizEntities DB
        {
            get
            {
                if (HttpContext.Current.Items[EntityKey] == null)
                    HttpContext.Current.Items[EntityKey] = new QuizEntities();
                return (QuizEntities)HttpContext.Current.Items[EntityKey];
            }//get
        }//property

        #endregion

        #region "Methods"

        public NameValue Register(string name, string surname, string email, string password)
        {
            if (DB == null)
                return new NameValue() { Name = "Error : Error connecting to DB." };

            if (string.IsNullOrEmpty(email))
                return new NameValue() { Name = "Error : Email cant be empty." };

            if (string.IsNullOrEmpty(name))
                return new NameValue() { Name = "Error : Name cant be empty." };

            if (string.IsNullOrEmpty(surname))
                return new NameValue() { Name = "Error : Surname cant be empty." };

            if (string.IsNullOrEmpty(password))
                return new NameValue() { Name = "Error : Password cant be empty." };

            if (DB.tabUser.Where(i => i.Email == email).FirstOrDefault() != null)
                return new NameValue() { Name = "This email is already registered." };

            UserEntity objEntity = new UserEntity()
            {
                Email = email,
                Name = name,
                Password = password,
                Surname = surname
            };

            DB.tabUser.Add(objEntity);

            if (DB.SaveChanges() <= 0)
                return new NameValue() { Name = "Error saving data." };

            return new NameValue() { Name = "Successfully registered.", Value = objEntity.ID };
        }//function

        public NameValue Login(string email, string password)
        {
            if (DB == null)
                return new NameValue() { Name = "Error : Error connecting to DB." };

            if (string.IsNullOrEmpty(email))
                return new NameValue() { Name = "Error : Email cant be empty." };

            if (string.IsNullOrEmpty(password))
                return new NameValue() { Name = "Error : Password cant be empty." };

            UserEntity objEntity = DB.tabUser.Where(i => i.Email == email && i.Password == password).FirstOrDefault();
            return objEntity == null ? new NameValue() { Name = "Login error." } : new NameValue() { Name = "Successfully logged in.", Value = objEntity.ID };
        }//function

        #endregion
    }//class
}//namespace
