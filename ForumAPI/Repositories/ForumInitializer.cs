using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ForumInitializer<TContext> : DropCreateDatabaseAlways<ForumContext>
    {
        //TODO Write seed method for database
        protected override void Seed(ForumContext context)
        {
            base.Seed(context);
        }
    }
}
