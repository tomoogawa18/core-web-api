using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace SampleMVCApp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        [Display(Name="投稿者")]
        public int PersonId { get; set; }

        [ForeignKey("PersonKey")]
        public Person Person { get; set; }
    }
}
