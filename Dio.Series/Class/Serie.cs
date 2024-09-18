using Dio.Series.Enums;
using System.Net.Http.Headers;

namespace Dio.Series.Class
{
    public class Serie : BaseEntity
    {
        public string Description { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public int Year { get; private set; }
        public EGender Gender { get; private set; }
        public bool IsActive { get; private set; } = false;

        public Serie(int id, string description, string title, int year, EGender gender)
        {
            Id = id;
            Description = description;
            Title = title;
            Year = year;
            Gender = gender;
        }

        public override string ToString()
        {
            string ret = "";
            ret += $"Gender: {this.Gender} {Environment.NewLine}";
            ret += $"Title: {this.Title} {Environment.NewLine}";
            ret += $"Description: {this.Description} {Environment.NewLine}";
            ret += $"Excluded: {(this.IsActive ? "Sim" : "Não")} {Environment.NewLine}";
            ret += $"Year: {this.Year}";
            return ret;
        }

        public string ReturnTitle()
            => this.Title;

        public int ReturnId()
            => this.Id;

        public bool Inactive()
            => this.IsActive = true;
    }
}
