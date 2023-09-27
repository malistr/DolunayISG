﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolunay.Models
{
	public class BaseModel
	{
		[Key]
        public int Id { get; set; }
        public Guid Guid { get; set; }= Guid.NewGuid();
        public string? Name { get; set; }
		public string? Description { get; set; }
		public bool IsDeleted { get; set; }= false;
		public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; }= DateTime.Now;
        public DateTime DateModified { get; set; }=DateTime.Now;
		public DateTime? DateDeleted { get; set; }



    }
}
