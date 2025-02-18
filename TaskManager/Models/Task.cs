using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class Task
    {
        [Key] private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Title{get;set;}
        public string Description{get;set;}
        public int Priority{get;set;}
        public byte[]? FileName{get;set;}
    }
}