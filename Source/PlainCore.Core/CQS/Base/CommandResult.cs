using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.CQS.Base
{
    public class CommandResult
    {
        public CommandResult()
        {

        }

        public CommandResult(bool success)
        {
            this.Success = success;
            this.Errors = new List<string>();
        }
        public CommandResult(bool success, IEnumerable<string> errors)
        {
            this.Success = success;
            this.Errors = errors;
        }

        public CommandResult(bool success, string error)
        {
            this.Success = success;
            this.Errors = new List<string> { error };
        }

        public bool Success { get; protected set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
