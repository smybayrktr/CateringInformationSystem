using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSupportRequestDal:EfEntityRepositoryBase<SupportRequest, CateringISContext>,ISupportRequestDal
    {
        public async Task<List<SupportRequest>> GetSupportRequestsByUserId(int id)
        {
            using (var context = new CateringISContext())
            {
                var result = from supportRequest in context.SupportRequests
                    join userSupportRequest in context.UserSupportRequests on supportRequest.Id equals userSupportRequest.SupportRequestId
                    where userSupportRequest.UserId == id
                    select new SupportRequest()
                    {
                        Id = supportRequest.Id,
                        CreateDate = supportRequest.CreateDate,
                        Title = supportRequest.Title,
                        Body = supportRequest.Body,
                        IsCompleted = supportRequest.IsCompleted
                    };
                return await result.ToListAsync();
            }
        }

        public async Task<List<SupportRequest>> GetSupportRequestsByUserSchoolNumber(string number)
        {
            using (var context = new CateringISContext())
            {
                var result = from supportRequest in context.SupportRequests
                    join userSupportRequest in context.UserSupportRequests on supportRequest.Id equals userSupportRequest.SupportRequestId
                    where userSupportRequest.UserSchoolNumber == number
                    select new SupportRequest()
                    {
                        Id = supportRequest.Id,
                        CreateDate = supportRequest.CreateDate,
                        Title = supportRequest.Title,
                        Body = supportRequest.Body,
                        IsCompleted = supportRequest.IsCompleted
                    };
                return await result.ToListAsync();
            }
        }
    }
}