using System;
using System.Collections.Generic;
using System.Text;

namespace Library.GitAccessor.Model
{
    public class CommitEvent
    {
        public Author Author { get; set; }
        public string CommentsUrl { get; set; }
        public Commit Commit { get; set; }
        public Author Committer { get; set; }
        public string HtmlUrl { get; set; }
        public object Stats { get; set; }
        public List<Tree> Parents { get; set; }
        public List<File> Files { get; set; }
        public string Url { get; set; }
        public object Label { get; set; }
        public object Ref { get; set; }
        public string Sha { get; set; }
        public object User { get; set; }
        public object Repository { get; set; }
    }

    public class Commits
    {
        public List<CommitEvent> Commit_Event_List { get; set; }
        public int Repository_Id { get; set; }

        public Commits()
        {
            this.Commit_Event_List = new List<CommitEvent>();
        }
    }
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

    public class Author
    {
        public string Login { get; set; }
        public int Id { get; set; }
        public string AvatarUrl { get; set; }
        public string Url { get; set; }
        public string HtmlUrl { get; set; }
        public string FollowersUrl { get; set; }
        public string FollowingUrl { get; set; }
        public string GistsUrl { get; set; }
        public string StarredUrl { get; set; }
        public string SubscriptionsUrl { get; set; }
        public string OrganizationsUrl { get; set; }
        public string ReposUrl { get; set; }
        public string EventsUrl { get; set; }
        public string ReceivedEventsUrl { get; set; }
        public string Type { get; set; }
        public bool SiteAdmin { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
    public class Commit
    {
        public string Message { get; set; }
        public Author Author { get; set; }
        public Author Committer { get; set; }
        public Tree Tree { get; set; }
        public object Parents { get; set; }
        public int CommentCount { get; set; }
        public Verification Verification { get; set; }
        public string Url { get; set; }
        public object Label { get; set; }
        public object Ref { get; set; }
        public object Sha { get; set; }
        public object User { get; set; }
        public object Repository { get; set; }
    }

    public class Tree
    {
        public string Url { get; set; }
        public object Label { get; set; }
        public object Ref { get; set; }
        public string Sha { get; set; }
        public object User { get; set; }
        public object Repository { get; set; }
    }
    public enum AccountType
    {
        User = 0,
        Organization = 1,
        Bot = 2
    }
    public class File
    {
        public string Filename { get; set; }
        public int Additions { get; set; }
        public int Deletions { get; set; }
        public int Changes { get; set; }
        public string Status { get; set; }
        public string BlobUrl { get; set; }
        public string ContentsUrl { get; set; }
        public string RawUrl { get; set; }
        public string Sha { get; set; }
        public string Patch { get; set; }
        public object PreviousFileName { get; set; }
    }
    public class Verification
    {
        public bool Verified { get; set; }
        public Reason Reason { get; set; }
        public string Signature { get; set; }
        public string Payload { get; set; }
    }
}
