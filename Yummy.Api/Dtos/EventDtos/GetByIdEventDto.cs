﻿namespace Yummy.Api.Dtos.EventDtos
{
    public class GetByIdEventDto
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
