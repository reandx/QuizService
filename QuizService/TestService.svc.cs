using System;

namespace QuizService
{
    public class TestService : ITestService
    {
        #region "Methods"

        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }//function

        public int Multiply(int value1, int value2)
        {
            return value1 * value2;
        }//function

        #endregion
    }//class
}//namespace
