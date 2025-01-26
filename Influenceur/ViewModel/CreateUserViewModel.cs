using Microsoft.AspNetCore.Mvc.Rendering;

namespace Influenceur.ViewModel
{
    public class CreateUserViewModel
    {
        public List<SelectListItem> UserTypeOptions { get; set; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Influenceur", Text = "Influenceur" },
        new SelectListItem { Value = "Sponsor", Text = "Sponsor" }
    };
    }
}
