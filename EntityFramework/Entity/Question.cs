using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entity
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public virtual ICollection<FocusArea> FocusAreas { get; set; }
    }
}
