using Asponna.Domain.Repositories.Parameters;
using MediatR;
using System.Collections.Generic;

namespace Asponna.Application.Queries.Cards.GetAll
{
    public class GetAllCardQuery : IRequest<List<CardListViewModel>>
    {
        public CardParameter CardParameter;

        public GetAllCardQuery(CardParameter cardParameter)
        {
            CardParameter = cardParameter;
        }
        
    }
}