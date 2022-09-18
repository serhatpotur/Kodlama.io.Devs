using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Dtos
{
    public class CreatedSocialMediaDto
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public string? SocialMediaName { get; set; }
        public string? SocialMediaUrl { get; set; }

    }
}
