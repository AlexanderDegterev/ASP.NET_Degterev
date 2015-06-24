using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF6App
{
    class LoadingFileContext:DbContext
    {
        public LoadingFileContext()
            :base("DbConnection")
        {}

        public DbSet<LoadingFile> LoadingFiles { get; set; }
    }
}
