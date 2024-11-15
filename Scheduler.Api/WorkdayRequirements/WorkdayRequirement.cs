﻿using MediatR;
using Scheduler.Api.Data;

namespace Scheduler.Api.WorkdayRequirements
{
    public class WorkdayRequirement : BaseModel, IRequest<Result<Guid>>
    {
        public Guid CompanyId { get; set; }
        public Guid PositionId { get; set; }
        public int Quantity { get; set; }
        public int DayOfTheWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
