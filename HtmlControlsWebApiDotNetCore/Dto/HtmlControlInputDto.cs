using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlControlsWebApiDotNetCore.Dto
{
    public class HtmlControlInputDto
    {
        public int Id { get; set; }
        public string ElementId { get; set; }
        public string ElementType { get; set; }
        public string ElementOrder { get; set; }
        public string HtmlText { get; set; }
        public string Text { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string MarginLeft { get; set; }
        public string MarginTop { get; set; }
        public string MarginRight { get; set; }
        public string MarginBottom { get; set; }
        public string Link { get; set; }
        public string Align { get; set; }
        public string BackgroundColor { get; set; }
        public string ButtonType { get; set; }
        public string FontSize { get; set; }
        public string FontColor { get; set; }
        public string ButtonColor { get; set; }
    }
}
