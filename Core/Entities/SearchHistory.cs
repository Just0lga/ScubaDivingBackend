using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Entities
{
    public class SearchHistory : BaseEntity
    {
        [Required]
        public string UserId { get; set; }  // düzelt
        public User User { get; set; }
        public string Keyword { get; set; }
    }
}
