﻿using CarBook.Application.Features.Mediator.Results.TagCloudResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery:IRequest<List<GetTagCloudByBlogIdQueryResult>> 
    {
        public GetTagCloudByBlogIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}