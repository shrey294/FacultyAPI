using FacultyAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacultyAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FacultyController : ControllerBase
	{
		private readonly Ang_CrudContext _context;

		public FacultyController(Ang_CrudContext context)
		{
			_context = context;
		}
		[HttpGet]
		[Route("GetFaculty")]
		public async Task<IActionResult> GetFaculty()
		{
			try
			{
				var records = await _context.Faculties.AsNoTracking().ToListAsync();
				var response = new { records = records };

				return Ok(response);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while Request.", details = ex.Message });
			}
		}
		[HttpGet]
		[Route("GetFaculty/{fcId}")]
		public async Task<IActionResult> GetById(int fcId)
		{
			try
			{
				var faculty = await _context.Faculties.FirstOrDefaultAsync(f => f.FcId == fcId);

				if (faculty == null)
				{
					return NotFound(new { message = "Faculty not found" });
				}

				// Return the specific faculty record in the response format.
				return Ok(faculty);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while Request.", details = ex.Message });
			}
		}

		[HttpDelete]
		[Route("DeleteFaculty/{fcId}")]
		public async Task<IActionResult> DeleteFaculty(int fcId)
		{
			try
			{
				var recordtodelete = _context.Faculties.Where(x=> x.FcId == fcId).FirstOrDefault();

				if (recordtodelete != null) 
				{
					_context.Faculties.Remove(recordtodelete);
					await _context.SaveChangesAsync();
					return NoContent();
				}
				else
				{
					return NotFound();
				}
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPost]
		[Route("InsertFaculty")]
		public async Task<IActionResult> InsertFaculty([FromForm] Faculty faculty)
		{
			try
			{
				await _context.Faculties.AddAsync(faculty);
				await _context.SaveChangesAsync();
				return StatusCode(StatusCodes.Status201Created);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpPut]
		[Route("EditFaculty/{fcId}")]
		public async Task<IActionResult> EditFaculty(int fcId, [FromForm] Faculty faculty)
		{
			try
			{
				if (fcId == 0)
				{
					return BadRequest();
				}
				else
				{
					
						var facultybyId = _context.Faculties.FirstOrDefault(x => x.FcId == fcId);
						if (facultybyId == null)
						{
							return NotFound();
						}
						else
						{
							 facultybyId.FcName = faculty.FcName;
							 facultybyId.FcDesignation = faculty.FcDesignation;
							 facultybyId.FcHighestEducation = faculty.FcHighestEducation;
							 facultybyId.FcExYear = faculty.FcExYear;
							 facultybyId.WorkingSince = faculty.WorkingSince;
							 facultybyId.FcMobile = faculty.FcMobile;
							 facultybyId.FcEmail = faculty.FcEmail;
							 facultybyId.FcSeating = faculty.FcSeating;
							 facultybyId.FcProfile = faculty.FcProfile;
							 facultybyId.FcAreaspecialization = faculty.FcAreaspecialization;
							 facultybyId.FcSubjecttaught = faculty.FcSubjecttaught;
							 facultybyId.FcImage = faculty.FcImage;
							 facultybyId.FcDepartmentId = faculty.FcDepartmentId;
							 facultybyId.FcSequence = faculty.FcSequence;
							 await _context.SaveChangesAsync();
							 return Ok();
						}
					
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
		[HttpGet]
		[Route("GetUser")]
		public async Task<IActionResult> GetUser()
		{
			try
			{
				var User = await _context.Users.ToListAsync();
				return Ok(User);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
