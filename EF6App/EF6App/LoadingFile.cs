
namespace EF6App
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoadingFile
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<decimal> FileLenght { get; set; }
    }
}
