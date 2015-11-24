namespace BugLoggingSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        public Bug()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [MaxLength(200)]
        public string Text { get; set; }

        public DateTime LogDate { get; set; }

        public BugStatus Status { get; set; }
    }
}
