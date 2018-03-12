using System;
using System.Collections.Generic;
using System.Text;

namespace Library.GitAccessor.Model
{
    public class Repository
    {
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DefaultBranch { get; set; }
        public Owner Owner { get; set; }
    }
    public class Owner
    {
        public string AvatarUrl { get; set; }
        public string HtmlUrl { get; set; }
        public string Login { get; set; }
    }
}
