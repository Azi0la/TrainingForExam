using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingForExam
{
    partial class Masters
    {
        public List <string> DT {  get
            {
                return Sessions.Where(p => p.ID_Master == this.ID && p.IsBooked == false).Select(s => s.Date.ToString()).ToList();
            } }
    }
}
