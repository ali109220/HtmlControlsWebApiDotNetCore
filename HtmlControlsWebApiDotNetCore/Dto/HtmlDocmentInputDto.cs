using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlControlsWebApiDotNetCore.Dto
{
    public class HtmlDocmentInputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string UserId { get; set; }

        public List<HtmlControlInputDto> HtmlControls { get; set; }
    }
    public class HtmlDocmentContentInputDto
    {
        public string HtmlContent { get; set; }
    }
}
