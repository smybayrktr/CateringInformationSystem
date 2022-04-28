using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public class SupportRequestManager:ISupportRequestService
    {
        public IDataResult<List<SupportRequest>> GetSupportRequests()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<SupportRequest> GetSupportRequest(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<SupportRequest> AddSupportRequest(SupportRequest supportRequest)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<SupportRequest> UpdateSupportRequest(SupportRequest supportRequest)
        {
            throw new System.NotImplementedException();
        }

        public IResult DeleteSupportRequest(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<SupportRequest> GetSupportRequestByUserId(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<SupportRequest> GetSupportRequestByUserSchoolNumber(string number)
        {
            throw new System.NotImplementedException();
        }
    }
}