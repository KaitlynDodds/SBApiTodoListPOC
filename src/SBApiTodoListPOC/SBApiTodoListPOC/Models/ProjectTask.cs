﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBApiTodoListPOC.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }


        // Foreign Key
        public int ProjectId { get; set; }
        public Project Project { get; set; }

    }
}