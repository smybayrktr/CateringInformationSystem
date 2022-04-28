﻿using System;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Deposit:IEntity
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime CreateDate { get; set; }
    }
}