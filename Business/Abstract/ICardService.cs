using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService
    {
        IResult Add(Card card);
        IResult Update(Card card);
        IResult Delete(Card card);
        IDataResult<List<Card>> GetAllCards();
        IDataResult<Card> GetByCustomerId(int customerId);
        IDataResult<Card> GetCardByCardNumber(string cardNumber);

        IDataResult<List<Card>> GetCardsByCustomerId(int customerId);
    }
}
