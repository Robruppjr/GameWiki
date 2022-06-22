using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class DeveloperService : IDeveloperService
    {
        private readonly ApplicationDbContext _context;

        private readonly IDeveloperService _developerService;
    }
