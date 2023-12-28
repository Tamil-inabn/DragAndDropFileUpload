using System;
using System.Collections.Generic;

namespace DragAndDrop.EntityModels
{
    public partial class Register
    {
        public Register()
        {
            Attachments = new HashSet<Attachment>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public long? Mobile { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
