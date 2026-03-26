using Forum.Application.Users;
using Forum.Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Users.Models
{
    public class Result
    {
        public bool IsSuccess { get; }
        public PossibleResponse Message { get; }

        protected Result(bool isSuccess,PossibleResponse responseMessage)
        {
            IsSuccess = isSuccess;
            Message = responseMessage;
        }

        public static Result Success() => new Result(true,PossibleResponse.Success);
        public static Result Failure(PossibleResponse response) => new Result(false,response);
        public static Result<T> Success<T>(T value) => new Result<T>(value,true,PossibleResponse.Success);
        public static Result<T> Failure<T>(PossibleResponse response) => new Result<T>(default, false, response);
    }

    public class Result<T> : Result
    {
        public T? Value { get; }
        protected internal Result(T? value,bool isSuccess, PossibleResponse response) : base(isSuccess, response)
        {
            Value=value;
        }
    }
}


