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
        List<GameType> GetAllGameType();

        #endregion

        #region "Category"

        [WebGet(UriTemplate = "/GetAllCategory", ResponseFormat = WebMessageFormat.Json)]
        List<Category> GetAllCategory();

        #endregion
    }//interface
}//namespace
