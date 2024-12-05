using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Example19_11_24.Data;

namespace Faculty.Controllers
{
    public class FacultyController : Controller
    {
        private readonly CollegeContext _context;

        public FacultyController(CollegeContext context)
        {
            _context = context;
        }

        // GET: Show all faculty sorted by department
        public async Task<IActionResult> Index(string selectedDepartment)
        {
            // Fetch unique departments for dropdown
            var departments = await _context.Departments
                .OrderBy(d => d.Name)
                .Select(d => new SelectListItem
                {
                    Value = d.Name,
                    Text = d.Name
                }).ToListAsync();

            ViewData["Departments"] = departments;

            // Fetch faculty, filtered by department if selected
            var facultyQuery = _context.FacultyMembers.Include(f => f.Courses) // Include department details
                .AsQueryable();

            //if (!string.IsNullOrEmpty(selectedDepartment))
            //{
            //    facultyQuery = facultyQuery.Where(f => f.Department.Name == selectedDepartment);
            //}

            //var faculty = await facultyQuery
            //    .OrderBy(f => f.Department.Name)
            //    .ThenBy(f => f.LastName)
            //    .ToListAsync();

            return View();
        }

        // POST: Filter faculty by department
        [HttpPost]
        public async Task<IActionResult> IndexPost(string selectedDepartment)
        {
            // Redirect to the GET method with the selected department as a query parameter
            return RedirectToAction(nameof(Index), new { selectedDepartment });
        }
    }
}