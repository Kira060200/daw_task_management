using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task_management.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Status { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        //De verificat daca am implementat bine key si ICollection
    }
}