﻿using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public class DepositManager:IDepositService
    {
        private IDepositDal _depositDal;

        public DepositManager(IDepositDal depositDal)
        {
            _depositDal = depositDal;
        }

        public IDataResult<List<Deposit>> GetDeposits()
        {
            return new SuccessDataResult<List<Deposit>>(_depositDal.GetAll());
        }

        public IDataResult<Deposit> GetDeposit(int id)
        {
            return new SuccessDataResult<Deposit>(_depositDal.Get(p => p.Id == id));
        }

        public IResult AddDeposit(Deposit deposit)
        {
            _depositDal.Add(deposit);
            return new SuccessResult("Eklendi");
        }

        public IResult UpdateDeposit(Deposit deposit)
        {
            _depositDal.Update(deposit);
            return new SuccessResult("Güncellendi");
        }

        public IResult DeleteDeposit(Deposit deposit)
        {
            _depositDal.Delete(deposit);
            return new SuccessResult("Silindi");
        }

        public IDataResult<Deposit> GetDepositByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Deposit> GetDepositByUserSchoolNumber(string number)
        {
            throw new NotImplementedException();
        }
    }
}