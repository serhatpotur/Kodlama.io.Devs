using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SocialMedia : Entity
    {
        public int DeveloperId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
        public virtual Developer? Developer { get; set; }

        public SocialMedia()
        {

        }
        public SocialMedia(int id, int developerId, string socialMediaName, string socialMediaUrl) : this()
        {
            Id = id;  //1  //2
            DeveloperId = developerId;  //1  //1
            SocialMediaName = socialMediaName;  //github , //linkedin
            SocialMediaUrl = socialMediaUrl;
        }
    }
}
