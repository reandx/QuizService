using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace QuizService
{
    [ServiceContract]
    public interface ITestService
    {
        [WebGet(UriTemplate = "/add?v1={value1}&v2={value2}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int Add(int value1, int value2);

        [WebGet(UriTemplate = "/multiply?v1={value1}&v2={value2}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int Multiply(int value1, int value2);

        [WebInvoke(UriTemplate = "/gettestobject", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        TestObject GetTestObject(TestObject test);
    }//interface

    public class TestObject
    {
        public int ID { get; set; }//property
        public string Name { get; set; }//property
    }//class
}//namespace
