using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISupportRequestService
    {
        public IDataResult<List<SupportRequest>> GetSupportRequests();
        public IDataResult<SupportRequest> GetSupportRequest(int id);
        public IResult AddSupportRequest(SupportRequest supportRequest);
        public IResult UpdateSupportRequest(SupportRequest supportRequest);
        public IResult DeleteSupportRequest(SupportRequest supportRequest);
        public IDataResult<List<SupportRequest>> GetSupportRequestsByUserId(int id);
        public IDataResult<List<SupportRequest>> GetSupportRequestsByUserSchoolNumber(string number);
    }
}