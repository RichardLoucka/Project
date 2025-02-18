using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Task
    {
        [Key]
        private int id{get;set;}
        public string Title{get;set;}
        public string Description{get;set;}
        public int Priority{get;set;}
    }
}