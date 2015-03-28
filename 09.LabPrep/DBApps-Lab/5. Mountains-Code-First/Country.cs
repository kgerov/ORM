using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Mountains_Code_First
{
    public class Country
    {
        private ICollection<Mountain> mountains;

        public Country()
        {
            this.mountains = new HashSet<Mountain>();
        }

        [Key]
        [StringLength(2, MinimumLength = 2)]
        [Column(TypeName = "char")]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Mountain> Mountains
        {
            get { return this.mountains; }
            set { this.mountains = value; }
        }
    }
}
