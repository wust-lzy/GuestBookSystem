﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GuestBookSystem.Models
{
    public class GBSDBContext : DbContext
    {
        public DbSet<Guestbook> Guestbooks { get; set; }
        public DbSet<Admin>  Admins { get; set; }

        public DbSet<User>  Users { get; set; }
    }

}