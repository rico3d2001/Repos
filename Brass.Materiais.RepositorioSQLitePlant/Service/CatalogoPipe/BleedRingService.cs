﻿using Brass.Materiais.RepositorioSQLitePlant.Common;
using Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe.Models;
using SQLiteWithCSharp.Utility;

namespace Brass.Materiais.RepositorioSQLitePlant.Service.CatalogoPipe
{
    public class BleedRingService: RepositorioService<BleedRing>
    {
        public BleedRingService() : base(Storage.ConnectionString)
        {

        }

        // you can write extended methods here
    }
}