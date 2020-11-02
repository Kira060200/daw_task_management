using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task_management.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Key]
        public int TeamId { get; set; }
        [Key]
        public int CreatorId { get; set; }
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public virtual Task Task { get; set; }
    }
    //De verificat daca am implementat bine legaturile
}