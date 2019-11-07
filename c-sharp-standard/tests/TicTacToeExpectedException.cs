using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests
{
    public sealed class TicTacToeExpectedException : ExpectedExceptionBaseAttribute
    {
        private Type _expectedExceptionType;
        private string _expectedExceptionMessage;

        public TicTacToeExpectedException(Type expectedExceptionType)
        {
            _expectedExceptionType = expectedExceptionType;
            _expectedExceptionMessage = string.Empty;
        }

        public TicTacToeExpectedException(Type expectedExceptionType, string expectedExceptionMessage)
        {
            _expectedExceptionType = expectedExceptionType;
            _expectedExceptionMessage = expectedExceptionMessage;
        }

        protected override void Verify(Exception exception)
        {
            Assert.IsNotNull(exception);

            Assert.IsInstanceOfType(exception, _expectedExceptionType, "Wrong type of exception was thrown.");

            if (!_expectedExceptionMessage.Length.Equals(0))
            {
                Assert.AreEqual(_expectedExceptionMessage, exception.Message, "Wrong exception message was returned.");
            }
        }
    }
}
