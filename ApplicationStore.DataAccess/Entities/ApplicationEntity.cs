using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationStore.DataAccess.Entities
{
    public class ApplicationEntity
    {
        public Guid Id { get; set; }
        public Guid Author { get; set; }
        public string Activity { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Outline { get; set; } = string.Empty;
        public DateTime Submitted { get; set; } = DateTime.MinValue;

    }
}
