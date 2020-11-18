using System;

namespace LiveSchedule.API.Domains.Models
{
    public class LiveSchedule
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ChannelName { get; set; }

        public string Link { get; set; }

        public DateTime Date { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
