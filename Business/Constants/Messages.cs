using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
	public static class Messages
	{
		public static string AddedNewCar = "Yeni araba sisteme eklendi!";

		public static string NotAddedNewCar = "Yeni araba sisteme eklenemedi! Bilgileri kontrol ediniz...";

		public static string InvalidValue = "Geçersiz değer girdiniz lütfen tekrar deneyiniz!";

		public static string Successful = "İşlem başarılı!";

		public static string Empty = "Liste boş!";

		public static string InvalidEmail = "Geçersiz email!";
		public static string InvalidName = "Geçersiz isim veya soyisim!";
		public static string InvalidPassword = "Parola en az 8 haneli olmalıdır!";
		public static string InvalidCompanyName = "Şirket ismi daha uzun olmalıdır!";
	}
}
