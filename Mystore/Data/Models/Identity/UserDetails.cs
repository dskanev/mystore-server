﻿using Common.Data.Models;
using Mystore.Api.Data.Models.Nomenclature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Identity
{
    public class UserDetails : DatabaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public IList<Mystore.Api.Data.Models.Project.Project> Projects { get; set; }
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
