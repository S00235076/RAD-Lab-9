using Example19_11_24.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Example19_11_24.Pages.Students
{
    
        public class EnrollmentModel : PageModel
        {
            private readonly CollegeContext _context;
            
        public IList<Student> Students { get; set; }

            public EnrollmentModel(CollegeContext context)
            {
                _context = context;
            }

            public async Task OnGetAsync()
            {
            Console.WriteLine("\n\n\n\n\n called");
                Students = await _context.Students
                    .Include(s => s.Courses)
                    .ToListAsync();
            }

           
            //[HttpPost]
            //public async Task<IActionResult> Unenroll(int studentId, int courseId)
            //{
            //    var student = await _context.Students
            //        .Include(s => s.Courses)
            //        .FirstOrDefaultAsync(s => s.StudentId == studentId);

            //    if (student == null)
            //        return NotFound();

            //    var course = student.Courses.FirstOrDefault(c => c.CourseId == courseId);
            //    if (course != null)
            //    {
            //        student.Courses.Remove(course);
            //        await _context.SaveChangesAsync();
            //    }

            //    return RedirectToAction(nameof(Index));
            //}
        }
    }

