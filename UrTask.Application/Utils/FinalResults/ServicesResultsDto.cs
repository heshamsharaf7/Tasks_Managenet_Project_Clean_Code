using System;
using System.Collections.Generic;
using System.Text;
using UrTask.Application.Enums.ResultsTypes;

namespace UrTask.Application.Utils.FinalResults
{
    // Fluent interface
    public class ServicesResultsDto
    {
        public bool Success { get; set; }
        public string ResponseCode { get; set; }
        public string Message { get; set; }
        public ResultsTypes ResultType { get; set; }
        public object Id { get; set; }
    }
    public class ServicesResults
    {
        private ServicesResultsDto _results = new ServicesResultsDto(); // Initializes the context

        // set the value for properties
        public ServicesResults Success(bool success = true)
        {
            _results.Success = success;
            return this;
        }

        public ServicesResults ResponseCode(string responseCode)
        {
            _results.ResponseCode = responseCode;
            return this;
        }

        public ServicesResults Message(string message)
        {
            _results.Message = message;
            return this;
        }
        public ServicesResults ResultType(ResultsTypes resultType)
        {
            _results.ResultType = resultType;
            return this;
        }
        public ServicesResults Id(object id)
        {
            _results.Id = id;
            return this;
        }
        // Prints the data to console
        public ServicesResultsDto Results()
        {
            return _results;
        }
    }
}
