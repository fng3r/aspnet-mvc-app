using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcWebApp.Models;

namespace MvcWebApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UniversityContext context) => context.EnsureSeedData();
    }
}
