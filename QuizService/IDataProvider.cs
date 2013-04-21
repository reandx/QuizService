using QuizService.Objects;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace QuizService
{
    [ServiceContract]
    public interface IDataProvider
    {
        #region "User"

        [WebGet(UriTemplate = "/Register?n={name}&s={surname}&e={email}&p={password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        NameValue Register(string name, string surname, string email, string password);

        [WebGet(UriTemplate = "/Login?e={email}&p={password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        NameValue Login(string email, string password);

        #endregion

        #region "GameType"

        [WebGet(UriTemplate = "/GetAllGameType", ResponseFormat = WebMessageFormat.Json)]
        List<GameTypeObject> GetAllGameType();

        #endregion

        #region "Category"

        [WebGet(UriTemplate = "/GetAllCategory", ResponseFormat = WebMessageFormat.Json)]
        List<CategoryObject> GetAllCategory();

        #endregion

        #region "Question"

        [WebGet(UriTemplate = "/GetAllQuestionByCategoryID?c={categoryID}", ResponseFormat = WebMessageFormat.Json)]
        List<QuestionObject> GetAllQuestionByCategoryID(int categoryID);

        #endregion

        #region "Score"

        [WebGet(UriTemplate = "/PostScore?u={userID}&g={gameTypeID}&c={categoryID}&s={score}", ResponseFormat = WebMessageFormat.Json)]
        NameValue PostScore(int userID, int gameTypeID, int categoryID, int score);

        [WebGet(UriTemplate = "/GetScore?u={userID}&g={gameTypeID}&c={categoryID}", ResponseFormat = WebMessageFormat.Json)]
        List<ScoreObject> GetScore(int userID, int gameTypeID, int categoryID);

        #endregion
    }//interface
}//namespace
