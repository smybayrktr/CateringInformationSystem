using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISupportRequestService
    {
        public IDataResult<List<SupportRequest>> GetSupportRequests();
        public IDataResult<SupportRequest> GetSupportRequest(int id);
        public IDataResult<SupportRequest> AddSupportRequest(SupportRequest supportRequest);
        public IDataResult<SupportRequest> UpdateSupportRequest(SupportRequest supportRequest);
        public IResult DeleteSupportRequest(int id);
        public IDataResult<SupportRequest> GetSupportRequestByUserId(int id);
        public IDataResult<SupportRequest> GetSupportRequestByUserSchoolNumber(string number);
    }
}