using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestDAL.Entities
{
    public class BodyKitDto
    {
        public Guid Id { get; set; }

        public string FrontBumper { get; set; }

        public string RearBumper { get; set; }

        public string SideSkirts { get; set; }

        public double Version { get; set; }
    }
}
