using Entities.Model.StatusesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model.AppealsModel
{
    public class Appeal
    {
        public int id { get; set; }
        public string fio { get; set; }
        public string telephone_number { get; set; }
        public DateTime create_at { get; set; } = DateTime.UtcNow;
        [ForeignKey("Status")] public int? status_id { get; set; }
        public Status status_ { get; set; }
    }
}
