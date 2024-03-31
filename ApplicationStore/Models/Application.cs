using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationStore.Core.Models
{
    public class Application
    {
        public const int MAX_NAME_LENGTH = 100;
        public const int MAX_DESCRIPTION_LENGTH = 300;
        public const int MAX_OUTLINE_LENGTH = 1000;
        private Application(Guid id, Guid authorId, string activity, string name, string description, string outline, DateTime submitted)
        {
            Id = id;
            Author = authorId;
            Activity = activity;
            Name = name;
            Description = description;
            Outline = outline;
            Submitted = submitted;
        }

        public Guid Id { get;}

        public Guid Author { get;}
        public string Activity { get;  } = string.Empty;
        public string Name {  get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public string Outline { get; } = string.Empty;
        public DateTime Submitted { get; set; } = DateTime.MinValue;

        private static bool check(string s)
        {
            return (string.IsNullOrEmpty(s));
        }

        public static (Application Application, string Error) Create(Guid Id, Guid author, string activity, string name, string description, string outline, DateTime submitted)
        {
            var error = String.Empty;
            if(Guid.Empty == author) {
                if (check(activity) && check(name) && check(description) && check(outline))
                {
                    error = "Введите еще одно поле помимо author";
                }else
                {
                    error = "Введите поле author";
                }
                
            }
            var Application = new Application(Id,author, activity, name, description, outline, submitted);
            return (Application,  error);
        }


    }
}
