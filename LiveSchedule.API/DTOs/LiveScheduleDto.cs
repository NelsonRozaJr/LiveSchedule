using System;
using System.ComponentModel.DataAnnotations;

namespace LiveSchedule.API.DTOs
{
    public class LiveScheduleDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ChannelName is required")]
        public string ChannelName { get; set; }

        [Required(ErrorMessage = "Link is required")]
        public string Link { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
    }
}
