﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using music_manager_starter.Data;
using music_manager_starter.Data.Models;
using System;

namespace music_manager_starter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly DataDbContext _context;

        public SongsController(DataDbContext context)
        {
            _context = context;
        }

  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            try
            {
                if (song == null)
                {
                    return BadRequest("Song cannot be null.");
                }

                _context.Songs.Add(song);
                await _context.SaveChangesAsync();

                return Ok(song);
            }
            catch (Exception ex)
            {
                // Log the error (or you can use a logging library)
                Console.WriteLine(ex.Message); // This will log to the console for now
                return StatusCode(500, "Internal server error: " + ex.Message); // Return an error message
            }
        }



        /*
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            if (song == null)
            {
                return BadRequest("Song cannot be null.");
            }


            _context.Songs.Add(song);
            await _context.SaveChangesAsync();

            return Ok();
        } */
    }
}
