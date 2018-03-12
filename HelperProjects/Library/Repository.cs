using System;
using System.Collections.Generic;
using System.Text;

namespace Library.GitAccessor.Model
{
    public class Repository
    {
        public int Id { get; set; }
        public string HtmlUrl { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DefaultBranch { get; set; }
        public Owner Owner { get; set; }
        public Parent Parent {get; set; }
        public Parent Source { get; set; }
    }
    public class Owner
    {
        public string AvatarUrl { get; set; }
        public string HtmlUrl { get; set; }
        public string Login { get; set; }
    }
    public class Parent
    {
        public string HtmlUrl { get; set; }
        public int Id { get; set; }
        public Owner Owner { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public object Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
