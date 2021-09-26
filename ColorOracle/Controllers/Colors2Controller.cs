using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColorOracle.Models;
using ColorOracle.DTOs;

namespace ColorOracle
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorRoute
    {
        public decimal? ColorId { get; set; }
    }

    public class SelfClass2 
    {
        public decimal? ColorId { get; set; }
        public string ColorName { get; set; }
    }
    public class Colors2Controller : ControllerBase
    {
        private readonly ModelContext _context;

        public Colors2Controller(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Colors
        [HttpGet("GetALlTheData")]
        public async Task<ActionResult<ResponseDto>> GetColors()
        {
<<<<<<< HEAD
            List<Color> colors = await _context.Colors
                                                .ToListAsync();
            if (colors.Count <= 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Data cant be found",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "This is ok",
                Success = true,
                Payload = colors
            });
        }

        // GET: api/Colors/5
        [HttpPost("GetELementByID")]
        public async Task<ActionResult<ResponseDto>> GetColor([FromBody] ColorRoute input)
        {
            if (input.ColorId == 0) 
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto 
                {
                    Message = "Please TYPE Your ID",
                    Success = false,
                    Payload = null
                });
            }            
            var colors = await _context.Colors.Where(i => i.ColorId == input.ColorId).FirstOrDefaultAsync();
            if (colors == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto 
                {
                    Message = "Database doesn't match with the ID",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto 
            {
                Message = "Data Found for this ID",
                Success = true,
                Payload = colors
            });
        }


        // PUT: api/Colors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("UpdateColor")]
        public async Task<ActionResult<ResponseDto>> PutColor([FromBody] Color input)
        {
            if (input.ColorId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please Input Your ID",
                    Success = false,
                    Payload = null
                });
            }
            if (input.ColorName == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please Input Your Name",
                    Success = false,
                    Payload = null
                });
            }
            if (input.REPESENTER == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please input Repesenter",
                    Success = false,
                    Payload = null
                });
            }
            //in frombody only parameter can be there
            //old
            var color = await _context.Colors.Where(i => i.ColorId == input.ColorId).FirstOrDefaultAsync();
            if (color == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "Your ID is not in the database please retype currect ID!!",
                    Success = false,
                    Payload = null
                });
            }

            color.ColorName = input.ColorName;
            color.REPESENTER = input.REPESENTER;
            _context.Colors.Update(color);
            bool isSaved = await _context.SaveChangesAsync() > 0;
            if (isSaved == false)
=======
            return await _context.Colors.ToListAsync();
        }
        // GET: api/Colors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(decimal? id)
        {
            return await _context.Colors.FindAsync();
        }


        // PUT: api/Colors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(Color color, decimal? id)
        {
            if (id != color.ColorId) 
>>>>>>> 9d0b66218ac681289945368f600c9071e7f5b700
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto
                {
                    Message = "Server error Data isn't save yet",
                    Success = false,
                    Payload = null
                });
            }
<<<<<<< HEAD
            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "Data Updated",
                Success = true,
                Payload = null
            });
        }

        [HttpPost("UpdateColorName")]
        public async Task<ActionResult<ResponseDto>> PutColor([FromBody] SelfClass2 input)
        {
            if (input.ColorId == 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto 
                {
                    Message = "Please Type Id!!",
                    Success = false,
                    Payload = null
                });
            }

            if (input.ColorName == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please Type Name!!",
                    Success = false,
                    Payload = null
                });
            }
            //old
            var color = await _context.Colors.Where(i=>i.ColorId == input.ColorId).FirstOrDefaultAsync();

            if (color == null) 
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "Database Not Found for this ID please TYPE again!!",
                    Success = false,
                    Payload = null
                });
            }
            //new
            color.ColorName = input.ColorName;
            _context.Colors.Update(color);
            bool isSaved = await _context.SaveChangesAsync() > 0;
            if (isSaved ==  false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto 
                {
                    Message = "Internal Server Error thats why Data isn't changed yet!!",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "data upadated!!",
                Success = true,
                Payload = null
            });

            
=======
            _context.Entry(color).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
>>>>>>> 9d0b66218ac681289945368f600c9071e7f5b700
        }


        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertNewColor")]
        public async Task<ActionResult<ResponseDto>> PostColor([FromBody] Color input)
        {
<<<<<<< HEAD
            if (input.ColorId == 0) 
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto 
                {
                    Message ="Please fillup the ID field",
                    Success = false,
                    Payload = null
                });
            }

            if (input.ColorName == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please fillup the ColorName field",
                    Success = false,
                    Payload = null
                });
            }

            if (input.REPESENTER == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto
                {
                    Message = "Please fillup the REPESENTER field",
                    Success = false,
                    Payload = null
                });
            }

            var color = await _context.Colors.Where(i => i.ColorId == input.ColorId).FirstOrDefaultAsync();
            //if (color == null)
            //{
            //    return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
            //    {
            //        Message = "Data is not found in the database",
            //        Success = false,
            //        Payload = null
            //    });
            //}


            //color.ColorId = input.ColorId;
            //color.ColorName = input.ColorName;
            //color.REPESENTER = input.REPESENTER;
            if (color != null) 
            {
                return StatusCode(StatusCodes.Status409Conflict, new ResponseDto 
                {
                    Message = "Already Data is in the database",
                    Success = false,
                    Payload = null
                });
            }
            _context.Colors.Add(input);
            bool isSaved = await _context.SaveChangesAsync()>0;
            if (isSaved == false) 
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto
                {
                    Message = "Please fillup the ID field",
                    Success = false,
                    Payload = null
                });
            }
            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "data inserted",
                Success = true,
                Payload = null
            });
=======
            _context.Colors.Add(color);
            await _context.SaveChangesAsync();
            return Ok();
>>>>>>> 9d0b66218ac681289945368f600c9071e7f5b700
        }



        // DELETE: api/Colors/5
<<<<<<< HEAD
        [HttpPost("DeleteColor")]
        public async Task<ActionResult<ResponseDto>> DeleteColor([FromBody] ColorRoute input)
        {
            if (input.ColorId == 0) 
            {
                return StatusCode(StatusCodes.Status400BadRequest, new ResponseDto 
                {
                    Message ="Please fill up ID field!!",
                    Success = false,
                    Payload = null
                });
            }
            var color = await _context.Colors.Where(i=>i.ColorId == input.ColorId).FirstOrDefaultAsync();

            if (color == null) 
            {
                return StatusCode(StatusCodes.Status404NotFound, new ResponseDto 
                {
                    Message = "Data Not found in the Database",
                    Success = false,
                    Payload = null
                });
            }
            _context.Colors.Remove(color);
            bool isSaved = await _context.SaveChangesAsync()>0;
            if (isSaved == false) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto 
                {
                    Message = "Server has some error to delete the selective ID",
                    Success = false,
                    Payload = null
                });
            }

            return StatusCode(StatusCodes.Status200OK, new ResponseDto
            {
                Message = "Delete Done",
                Success = true,
                Payload = null
            });
=======
        [HttpDelete("{id}")]
        public async Task<ActionResult<Color>> DeleteColor(decimal? id)
        {
            var color = await _context.Colors.FindAsync(id);
            if (color == null )
            {
                return BadRequest();
            }
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
            return Ok();
>>>>>>> 9d0b66218ac681289945368f600c9071e7f5b700
        }
        private bool ColorExists(decimal? id)
        {
            return _context.Colors.Any(e => e.ColorId == id);
        }
    }
}
