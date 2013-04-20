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

        [WebGet(UriTemplate = "/register?n={name}&s={surname}&e={email}&p={password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        NameValue Register(string name, string surname, string email, string password);

        [WebGet(UriTemplate = "/login?e={email}&p={password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        NameValue Login(string email, string password);

        #endregion

        #region "GameType"
        
        #endregion
        [WebGet(UriTemplate = "getallgametype", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<GameTypeEntity> GetAllGameType();
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
