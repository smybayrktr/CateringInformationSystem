using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class SupportRequest:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body {get;set;}
        public bool IsCompleted { get; set; }
        public DateTime CreateDate { get; set; }
    }
}