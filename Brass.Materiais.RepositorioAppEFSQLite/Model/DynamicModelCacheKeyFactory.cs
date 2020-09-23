using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brass.Materiais.RepositorioAppEFSQLite.Model
{
    public class DynamicModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
            => context is BIM360DataContext dynamicContext
                ? (context.GetType(), dynamicContext.PnPClassName + "_PNP")
                : (object)context.GetType();
    }
}
