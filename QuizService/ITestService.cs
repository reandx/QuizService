using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace QuizService
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/add?v1={value1}&v2={value2}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int Add(int value1, int value2);

        [OperationContract]
        [WebGet(UriTemplate = "/multiply?v1={value1}&v2={value2}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int Multiply(int value1, int value2);
    }//interface
}//namespace
    