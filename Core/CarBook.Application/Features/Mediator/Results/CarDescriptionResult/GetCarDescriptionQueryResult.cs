﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.Mediator.Results.CarDescriptionResult
{
    public class GetCarDescriptionQueryResult
    {
        public int CarDescriptionID { get; set; }
        public int CarID { get; set; }
        public string Details { get; set; }
    }
}
