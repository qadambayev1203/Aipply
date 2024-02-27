using Entities.DTO.StatusesDTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.AppealsDTOS
{
    public class AppealReadedDTO
    {
        public int id { get; set; }
        public string fio { get; set; }
        public string telephone_number { get; set; }
        public DateTime create_at { get; set; }
        public StatusReadedDTO status_ { get; set; }
    }
}
