using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.Helpers
{
    using System;

    namespace Microsoft.DataTransfer.Basics
    {
        public static class Guard
        {
            public static void NotNull<T>(string argumentName, T value)
                where T : class
            {
                if (value == null)
                    throw new ArgumentNullException(argumentName);
            }

            public static void NotEmpty(string argumentName, string value)
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Non empty string expected", argumentName);
            }

            public static void Assert(bool condition)
            {
                System.Diagnostics.Debug.Assert(condition);
            }
        }
    }

}
