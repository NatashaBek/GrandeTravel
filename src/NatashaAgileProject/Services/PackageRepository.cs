﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using NatashaAgileProject.Models;

namespace NatashaAgileProject.Services
{
    public class PackageRepository : BaseEFRepository<Package>, IPackageRepository
    {
    }
}
