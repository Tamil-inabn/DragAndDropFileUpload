using System;
using System.Collections.Generic;

namespace DragAndDrop.EntityModels
{
    public partial class Attachment
    {
        public int Sno { get; set; }
        public string? Photo { get; set; }
        public string? Document { get; set; }
        public int? No { get; set; }

        public virtual Register? NoNavigation { get; set; }
    }
}
