using System;

namespace MatrixExceptions
{
    public class MatrixException : Exception
    {
        public MatrixException(string message) : base(message)
        {
        }
    }
}