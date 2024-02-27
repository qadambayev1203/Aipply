using Entities.Model.StatusesModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.AppealsDTOS
{
    public class AppealUpdatedDTO
    {
        public string fio { get; set; }
        public string telephone_number { get; set; }
    }
}
