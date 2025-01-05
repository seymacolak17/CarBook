using CarBook.Application.Features.Mediator.Results.CarDescriptionResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQuery:IRequest<GetCarDescriptionQueryResult>
    {

        public int Id { get; set; }
        public GetCarDescriptionByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}