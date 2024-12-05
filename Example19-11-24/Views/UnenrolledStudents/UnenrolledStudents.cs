using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Example19_11_24.Data;

namespace Example19_11_24.Views.UnenrolledStudents
{
    public class UnenrolledStudents : Controller
    {
        private readonly CollegeContext _context;

        public UnenrolledStudents(CollegeContext context)
        {
            _context = context;
        }

        public List<Student> UnenrolledStudentsList { get; set; }

        public async Task OnGetAsync()
        {
            UnenrolledStudentsList = await _context.Students
                .Where(s => !s.Courses.Any())
                .ToListAsync();
        }
    }
}