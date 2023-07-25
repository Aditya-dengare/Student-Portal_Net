using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAPortal.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPortal.Core.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext _dbContext;

        public StudentController(StudentDBContext dBContext)
        {
           _dbContext = dBContext;
        }

        // Get Student List API Call
        [HttpGet("GetStudent")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }

        // Get Student Detail By Id API Call
        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var student = await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) { return  NotFound(); }
            return Ok(student);
        }

        // Create Student API Call
        [HttpPost("AddStudent")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            _dbContext.Add(student);
            await _dbContext.SaveChangesAsync();

            return Ok("Data Saved SuccessFully");
        }

        // Edit Student API Call
        [HttpPut("EditStudent/{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student?.Id)
            {
                return Ok("Student not Found having id"+ id);
            }
            _dbContext.Entry(student).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else { throw; }
            }
            return Ok(student);
        }

        // Delete Student API Call
        [HttpDelete("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _dbContext.Students.Any(e => e.Id == id);
        }
    }
}
