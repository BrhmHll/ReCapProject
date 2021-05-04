using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class RentalDetailDto : IDto
	{
		public int Id { get; set; }
		public string CarDescription { get; set; }
		public int DailyPrice { get; set; }
		public string ColorName { get; set; }
		public string BrandName { get; set; }
		public string CompanyName { get; set; }
		public DateTime RentDate { get; set; }
		public DateTime ReturnDate { get; set; }
	}
}
