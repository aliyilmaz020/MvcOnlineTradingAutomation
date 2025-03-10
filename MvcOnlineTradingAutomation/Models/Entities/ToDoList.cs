﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTradingAutomation.Models.Entities
{
    public class ToDoList
    {
        [Key]
        public int ToDoListId { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(100)]
        public string Title { get; set; }
        [Column(TypeName ="bit")]
        public bool Status { get; set; }
    }
}