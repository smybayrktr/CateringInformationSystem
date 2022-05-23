using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISupportRequestService
    {
        public Task<IDataResult<List<SupportRequest>>> GetSupportRequests();
        public Task<IDataResult<SupportRequest>> GetSupportRequest(int id);
        public Task<IResult> AddSupportRequest(SupportRequest supportRequest,User user);
        public Task<IResult> UpdateSupportRequest(SupportRequest supportRequest);
        public Task<IResult> DeleteSupportRequest(SupportRequest supportRequest,User user);
        public Task<IDataResult<List<SupportRequest>>> GetSupportRequestsByUserId(int id);
        public Task<IDataResult<List<SupportRequest>>> GetSupportRequestsByUserSchoolNumber(string number);
    }
}