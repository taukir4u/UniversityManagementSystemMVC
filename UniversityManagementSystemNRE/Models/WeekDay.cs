using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using UniversityManagementSystemNRE.Models;

namespace UniversityManagementSystemNRE.Models
{
    public class WeekDay
    {
        public int WeekDayID { set; get; }
        public string DayName { set; get; }
        public virtual List<AllocatedRoom> AllocatedRoomList { set; get; }
    }
}