using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace QuizService
{
    [ServiceContract]
    public interface IUserService
    {
        [WebGet(UriTemplate = "/register?n={name}&s={surname}&e={email}&p={password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        NameValue Register(string name, string surname, string email, string password);

        [WebGet(UriTemplate = "/login?e={email}&p={password}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        NameValue Login(string email, string password);
    }//interface

    [DataContract]
    public class NameValue
    {
        private string _strName = string.Empty;
        private object _objValue = null;

        [DataMember]
        public string Name
        {
            get { return _strName; }
            set { _strName = value; }
        }//property

        [DataMember]
        public object Value
        {
            get { return _objValue; }
            set { _objValue = value; }
        }//property
    }//class
}//namespace
