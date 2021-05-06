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

		public static string Error = "Hata! Lütfen tekrar deneyiniz.";

		public static string CarNotAvaiable = "Araba zaten kiralanmış, tekrar kiralanamaz!";

		public static string CarNameExists = "Böyle bir araç adı zaten mevcut!";
		public static string CarExists = "Böyle bir araç zaten mevcut!";
		public static string CarNotFound = "Böyle bir araç bulunamadı!!";
		public static string ImageCountAlert = "Resim sayısı en fazla 5 tane olabilir.";
		public static string ImageNotFound = "Böyle bir resim bulunamadı!";
	}
}
