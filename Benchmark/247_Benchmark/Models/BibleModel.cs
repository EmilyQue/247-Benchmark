using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _247_Benchmark.Models
{
    public class BibleModel
    {
        //properties
        [Required]
        [DisplayName("Testament")]
        [DefaultValue("")]
        public string testament { get; set; }

        [Required]
        [DisplayName("Book Name")]
        [DefaultValue("")]
        public string bookName { get; set; }

        [Required]
        [DisplayName("Chapter Number")]
        [DefaultValue("")]
        public int chapterNo { get; set; }

        [Required]
        [DisplayName("Verse Number")]
        [DefaultValue("")]
        public int verseNo { get; set; }

        [Required]
        [DisplayName("Verse")]
        [DefaultValue("")]
        public string verse { get; set; }

        public BibleModel (string testament, string bookName, int chapterNo, int verseNo, string verse)
        {
            this.testament = testament;
            this.bookName = bookName;
            this.chapterNo = chapterNo;
            this.verseNo = verseNo;
            this.verse = verse;
        }

        public BibleModel()
        {
            //
        }
    }
}