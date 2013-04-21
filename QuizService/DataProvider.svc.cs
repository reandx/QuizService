using QuizService.Objects;
using System;
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

        #region "Question"

        public List<Question> GetAllQuestionByCategoryID(int categoryID)
        {
            if (DB == null)
                return null;

            return (from item in DB.tabQuestion
                    where item.CategoryID == categoryID
                    select new Question()
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Answer1 = new Answer() { ID = item.Answer1.ID, Name = item.Answer1.Name },
                        Answer2 = new Answer() { ID = item.Answer2.ID, Name = item.Answer2.Name },
                        Answer3 = new Answer() { ID = item.Answer3.ID, Name = item.Answer3.Name },
                        Answer4 = new Answer() { ID = item.Answer4.ID, Name = item.Answer4.Name },
                        RightAnswer = new Answer() { ID = item.RightAnswer.ID, Name = item.RightAnswer.Name },
                    }).ToList();
        }//function

        #endregion

        #region "Score"

        public NameValue PostScore(int userID, int gameTypeID, int categoryID, int score)
        {
            if (userID <= 0)
                return new NameValue() { Name = "Error : UserID cannot be null." };

            if (gameTypeID <= 0)
                return new NameValue() { Name = "Error : GameTypeID cannot be null." };

            if (categoryID <= 0)
                return new NameValue() { Name = "Error : CategoryID cannot be null." };

            if (score < 0)
                return new NameValue() { Name = "Error : Score cannot be null." };

            if (DB == null)
                return new NameValue() { Name = "Error : Error connecting to DB." };

            DB.tabScore.Add(new ScoreEntity()
            {
                UserID = userID,
                GameTypeID = gameTypeID,
                CategoryID = categoryID,
                Score = score,
                DateTime = DateTime.Now
            });

            if (DB.SaveChanges() <= 0)
                return new NameValue() { Name = "Error saving data." };

            return new NameValue() { Name = "Successfully saved score." };
        }//function

        public List<ScoreObject> GetScore(int userID, int gameTypeID, int categoryID)
        {
            if (DB == null)
                return null;

            return (from item in DB.tabScore where 
                    (userID > 0 ? item.UserID == userID : true) &&
                    (gameTypeID > 0 ? item.GameTypeID == gameTypeID : true) &&
                    (categoryID > 0 ? item.CategoryID == categoryID : true)
                    select new ScoreObject()
                    {
                        ID = item.ID,
                        UserID = item.UserID,
                        CategoryID = item.CategoryID,
                        GameTypeID = item.GameTypeID,
                        DateTime = item.DateTime,
                        Score = item.Score
                    }).ToList();
        }//function

        #endregion

        #endregion
    }//class
}//namespace
