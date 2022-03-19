using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HtmlControlsWebApiDotNetCore.Models
{
    public class HtmlDocument
    {
        public HtmlDocument()
        {
            HtmlControls = new List<HtmlControl>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public IList<HtmlControl> HtmlControls { get; set; }
    }
}