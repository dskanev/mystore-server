using AutoMapper;
using Common.Data.Mappings;
using Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mystore.Api.Data.Models.Project
{
    public class Comment : DatabaseModel
    {
        public string Text { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public long UserDetailsId { get; set; }
        public long ProjectId { get; set; }
    }

    public class CommentInputModel : IMapping
    {
        public long ProjectId { get; set; }
        public string Text { get; set; }
        public string AuthorId { get; set; }

        public void MappingProfile(Profile mapper)
        {
            mapper.CreateMap<CommentInputModel, Comment>();
        }
    }

    public class CommentOutputModel : IMapping
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public UserDetailsOutputModel UserDetails { get; set; }
        public long ProjectId { get; set; }

        public void MappingProfile(Profile mapper)
        {
            mapper.CreateMap<Comment, CommentOutputModel>();
            mapper.CreateMap<User, UserDetailsOutputModel>();
        }
    }
}
