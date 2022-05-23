using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public class SupportRequestManager:ISupportRequestService
    {
        private ISupportRequestDal _supportRequestDal;
        private IUserSupportRequestDal _userSupportRequestDal;

        public SupportRequestManager(ISupportRequestDal supportRequestDal, IUserSupportRequestDal userSupportRequestDal)
        {
            _supportRequestDal = supportRequestDal;
            _userSupportRequestDal = userSupportRequestDal;
        }

        public async Task<IDataResult<List<SupportRequest>>> GetSupportRequests()
        {
            var result = await _supportRequestDal.GetAll();
            return new SuccessDataResult<List<SupportRequest>>(result, Messages.Listed);
        }

        public async Task<IDataResult<SupportRequest>> GetSupportRequest(int id)
        {
            var result = await _supportRequestDal.Get(i => i.Id == id);
            return new SuccessDataResult<SupportRequest>(result,Messages.Listed);
        }

        public async Task<IResult> AddSupportRequest(SupportRequest supportRequest,User user)
        {
            await _supportRequestDal.Add(supportRequest);
            var userSupportRequest = new UserSupportRequest
            {
                UserId = user.Id,
                UserSchoolNumber = user.SchoolNumber,
                SupportRequestId = supportRequest.Id
            };
            await _userSupportRequestDal.Add(userSupportRequest);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IResult> UpdateSupportRequest(SupportRequest supportRequest)
        {
            await _supportRequestDal.Update(supportRequest);
            return new SuccessResult(Messages.Updated);
        }

        public async Task<IResult> DeleteSupportRequest(SupportRequest supportRequest,User user)
        {
            await _supportRequestDal.Delete(supportRequest);
            var supportRequestToDelete = await _userSupportRequestDal.Get(p => p.SupportRequestId == supportRequest.Id && p.UserId == user.Id);
            await _userSupportRequestDal.Delete(supportRequestToDelete);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<SupportRequest>>> GetSupportRequestsByUserId(int id)
        {
            var result = await _supportRequestDal.GetSupportRequestsByUserId(id);
            return new SuccessDataResult<List<SupportRequest>>(result, Messages.Listed);
        }

        public async Task<IDataResult<List<SupportRequest>>> GetSupportRequestsByUserSchoolNumber(string number)
        {
            var result = await _supportRequestDal.GetSupportRequestsByUserSchoolNumber(number);
            return new SuccessDataResult<List<SupportRequest>>(result, Messages.Listed);
        }
    }
}