using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace StudentSystem.Models
{
    [ComplexType]
    public class ContactInfo
    {
        public string Facebook { get; set; }

        public string Twitter { get; set; }
    }
}
