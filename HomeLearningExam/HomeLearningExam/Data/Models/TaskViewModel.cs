using Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TaskViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int LocationId { get; set; }

        public LocationViewModel Location { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal Budget { get; set; }

        public int TaskCategoryId { get; set; }

        [Required]
        public TaskCategoryViewModel TaskCategory { get; set; }

        public int StatusId { get; set; }
        public StatusViewModel Status { get; set; }


        public int UserId { get; set; }
        [Required]
        public UserViewModel User { get; set; }

        public int AsignedHousekeeperId { get; set; }
        public UserViewModel AsignedHousekeeper { get; set; }

        public string PhotoPath { get; set; }

        public DateTime SecondDueDate { get; set; }

        public IFormFile Photo { get; set; }
    }
}
