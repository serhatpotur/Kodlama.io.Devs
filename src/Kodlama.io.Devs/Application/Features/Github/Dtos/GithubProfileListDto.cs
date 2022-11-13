using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Github.Dtos
{
    public class GithubProfileListDto
    {
        public int Id { get; set; }
        public string GithubUrl { get; set; }
        public int UserId { get; set; }
    }
}
