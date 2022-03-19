using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlControlsWebApiDotNetCore.Models
{
    public class HtmlControl
    {
        [Key]
        public int Id { get; set; }
        public string ElementId { get; set; }
        public string ElementType { get; set; }
        public string ElementOrder { get; set; }
        public string HtmlText { get; set; }
        public string Text { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string WidthInPX { 
            get {
                return Width + "px";
            } }
        public string HeightInPX
        {
            get
            {
                return Height + "px";
            }
        }

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
        public int HtmlDocumentId { get; set; }

        [ForeignKey("HtmlDocumentId")]
        public HtmlDocument HtmlDocument { get; set; }
    }
}
