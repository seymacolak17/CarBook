using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Application.Features.Mediator.Results.CarDescriptionResult;
using MediatR;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class CarDescriptionByCarIdQuery:IRequest<GetCarDescriptionQueryResult>
    {
        public int Id { get; set; }

        public CarDescriptionByCarIdQuery(int id)
        {
            Id = id;
        }


    }
}
