﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCinemaMS.Shared.DTOs
{
	public class DateAndBranchIdDTO
	{
		public int BranchId { get; set; }

		public DateTime? DayOfWeek { get; set; }

		public int? MovieId { get; set; }
	}
}
