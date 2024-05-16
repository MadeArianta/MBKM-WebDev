using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace MBKM_WebDev.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Anda bisa menambahkan data yang ingin diteruskan ke view di sini
            var model = new FooterModel
            {
                CompanyName = "MBKM Dagoeng",
                Year = DateTime.Now.Year,
            };
            return View(model);
        }
    }

    public class FooterModel
    {
        public string CompanyName { get; set; }
        public int Year { get; set; }
    }
}
