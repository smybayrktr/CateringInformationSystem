using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSupportRequestDal:EfEntityRepositoryBase<SupportRequest, CateringISContext>,ISupportRequestDal
    {
        public List<SupportRequest> GetSupportRequestsByUserId(int id)
        {
            using (var context = new CateringISContext())
            {
                var result = from supportRequest in context.SupportRequests
                    join userSupportRequest in context.UserSupportRequests on supportRequest.Id equals userSupportRequest.SupportRequestId
                    join user in context.Users on userSupportRequest.UserId equals user.Id
                    select new SupportRequest()
                    {
                        Id = supportRequest.Id,
                        CreateDate = supportRequest.CreateDate,
                        Title = supportRequest.Title,
                        Body = supportRequest.Body,
                        IsCompleted = supportRequest.IsCompleted
                    };
                return result.ToList();
            }
        }

        public List<SupportRequest> GetSupportRequestsByUserSchoolNumber(string number)
        {
            using (var context = new CateringISContext())
            {
                var result = from supportRequest in context.SupportRequests
                    join userSupportRequest in context.UserSupportRequests on supportRequest.Id equals userSupportRequest.SupportRequestId
                    join user in context.Users on userSupportRequest.UserSchoolNumber equals user.SchoolNumber
                    select new SupportRequest()
                    {
                        Id = supportRequest.Id,
                        CreateDate = supportRequest.CreateDate,
                        Title = supportRequest.Title,
                        Body = supportRequest.Body,
                        IsCompleted = supportRequest.IsCompleted
                    };
                return result.ToList();
            }
        }
    }
}