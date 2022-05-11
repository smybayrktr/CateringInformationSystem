using System.Collections.Generic;
using Business.Constants;
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
            return new SuccessDataResult<List<SupportRequest>>(_supportRequestDal.GetAll(), Messages.Listed);
        }

        public IDataResult<SupportRequest> GetSupportRequest(int id)
        {
            return new SuccessDataResult<SupportRequest>(_supportRequestDal.Get(i => i.Id == id),Messages.Listed);
        }

        public IResult AddSupportRequest(SupportRequest supportRequest)
        {
            _supportRequestDal.Add(supportRequest);
            return new SuccessResult(Messages.Added);
        }

        public IResult UpdateSupportRequest(SupportRequest supportRequest)
        {
            _supportRequestDal.Update(supportRequest);
            return new SuccessResult(Messages.Updated);
        }

        public IResult DeleteSupportRequest(SupportRequest supportRequest)
        {
            _supportRequestDal.Delete(supportRequest);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<SupportRequest>> GetSupportRequestsByUserId(int id)
        {
            var result = _supportRequestDal.GetSupportRequestsByUserId(id);
            return new SuccessDataResult<List<SupportRequest>>(result, Messages.Listed);
        }

        public IDataResult<List<SupportRequest>> GetSupportRequestsByUserSchoolNumber(string number)
        {
            var result = _supportRequestDal.GetSupportRequestsByUserSchoolNumber(number);
            return new SuccessDataResult<List<SupportRequest>>(result, Messages.Listed);
        }
    }
}