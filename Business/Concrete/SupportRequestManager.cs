using System.Collections.Generic;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public class SupportRequestManager:ISupportRequestService
    {
        private ISupportRequestDal _supportRequestDal;

        public SupportRequestManager(ISupportRequestDal supportRequestDal)
        {
            _supportRequestDal = supportRequestDal;
        }

        public IDataResult<List<SupportRequest>> GetSupportRequests()
        {
            return new SuccessDataResult<List<SupportRequest>>(_supportRequestDal.GetAll());
        }

        public IDataResult<SupportRequest> GetSupportRequest(int id)
        {
            return new SuccessDataResult<SupportRequest>(_supportRequestDal.Get(i => i.Id == id));
        }

        public IResult AddSupportRequest(SupportRequest supportRequest)
        {
            _supportRequestDal.Add(supportRequest);
            return new SuccessResult();
        }

        public IResult UpdateSupportRequest(SupportRequest supportRequest)
        {
            _supportRequestDal.Update(supportRequest);
            return new SuccessResult();
        }

        public IResult DeleteSupportRequest(SupportRequest supportRequest)
        {
            _supportRequestDal.Delete(supportRequest);
            return new SuccessResult();
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