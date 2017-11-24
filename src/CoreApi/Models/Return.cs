using System.Collections.Generic;

namespace src
{
    public class Return : Return<object>
    {

    }
    
    public class Return<T>
    {
        public string Message { get; set; }
        public string InternalMessage { get; set; }
        public bool Success { get; set; }
        public List<ReturnError> Errors { get; set; }
        public T Data { get; set; }
    }

    public class ReturnError
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public string InternalMessage { get; set; }
    }
}