using System.Collections.Generic;
using System.Runtime.Serialization;
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

        [WebGet(UriTemplate = "/GetAllGameType", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<GameTypeEntity> GetAllGameType();

        #endregion

        #region "Category"

        [WebGet(UriTemplate = "/GetAllCategory", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<CategoryEntity> GetAllCategory();

        #endregion
    }//interface

    [DataContract]
    public class NameValue
    {
        [DataMember]
        public string Name { get; set; }//property

        [DataMember]
        public object Value { get; set; }//property
    }//class
}//namespace
