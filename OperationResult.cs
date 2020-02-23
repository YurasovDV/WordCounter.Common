using System.Collections.Generic;
using System.Linq;
using System;

namespace WordCounter.Common
{
    public class OperationResult<T>
    {
        private T _data;

        public T Data
        {
            get
            {
                if (Status != OperationStatus.Success)
                {
                    throw new InvalidOperationException($"Property '{nameof(Data)}' can not be accessed if Status is not Success");
                }

                return _data;

            }
            private set
            {
                _data = value;
            }
        }

        public OperationStatus Status { get; private set; }

        public string[] Errors { get; private set; } = new string[0];

        private OperationResult()
        {

        }

        private OperationResult(OperationStatus status, T data, IEnumerable<string> errors)
        {
            Status = status;
            _data = data;
            Errors = (errors ?? new string[0]).ToArray();
        }

        public static OperationResult<T> Success(T data)
        {
            return new OperationResult<T>() { Data = data, Status = OperationStatus.Success };
        }

        public static OperationResult<T> Fail(string error)
        {
            var errors = string.IsNullOrWhiteSpace(error) ? throw new ArgumentNullException(nameof(error)) : new string[] { error };
            return new OperationResult<T>(OperationStatus.Error, default, errors);
        }
    }
}
