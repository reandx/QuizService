using QuizService.Objects;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizService
{
    public class DataProvider : IDataProvider
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
                return HttpContext.Current.Items[EntityKey] as QuizEntities;
            }//get
        }//property

        #endregion

        #region "Methods"

        #region "User"

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

        #region "GameType"

        public List<GameType> GetAllGameType()
        {
            if (DB == null)
                return null;

            return (from item in DB.tabGameType
                    select new GameType() { ID = item.ID, Name = item.Name }).ToList();
        }//function

        #endregion

        #region "Category"

        public List<Category> GetAllCategory()
        {
            if (DB == null)
                return null;

            return (from item in DB.tabCategory
                    select new Category() { ID = item.ID, Name = item.Name }).ToList();
        }//function

        #endregion

        #endregion
    }//class
}//namespace
