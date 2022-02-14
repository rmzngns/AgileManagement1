using AgileManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Domain.models
{
    public class Sprint : Entity
    {
        public string Name { get; private set; } 
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public Project Project { get; private set; }
        public bool IsActive { get; private set; }

        public Sprint(DateTime startDate, DateTime endDate,string name)
        {
            Id = Guid.NewGuid().ToString();
            SetSprintDate(startDate, endDate);
            IsActive = true;
            Name = name;
        }


        public void SetSprintDate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new Exception("Bitiş tarihi başlangıç tarihinden önce olamaz.");
            }
            else if (startDate < DateTime.Now)
            {
                throw new Exception("başlangıç tarihi bugünden eski olamaz");
            }
            else if ((endDate - startDate).Days > 14)
            {
                throw new Exception("Başlangıç ile bitiş tarihi arası 2 haftadan fazla olamaz.");
            }
            StartDate = startDate.Date;
            EndDate = endDate.Date;
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name alanı boş geçilemez");
            }
            Name = name;
        }
       
        
      

    }
}
