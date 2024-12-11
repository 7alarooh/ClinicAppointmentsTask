using ClinicAppointmentsTask.Models;
using ClinicAppointmentsTask.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace ClinicAppointmentsTask.Controllers
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class BookingController : ControllerBase
        {
            private readonly IBookingService _bookingService;

            public BookingController(IBookingService bookingService)
            {
                _bookingService = bookingService;
            }

        // POST: api/Booking/BookAppointment
        [HttpPost("BookAppointment")]
        public async Task<IActionResult> BookAppointmentAsync(int patientId, int clinicId, DateTime date)
        {
            try
            {
                var result = await _bookingService.BookAppointmentAsync(patientId, clinicId, date);
                if (result.Contains("successfully booked"))
                {
                    return Ok(new { Message = result, StatusCode = 200 });
                }
                return BadRequest(new { Message = result, StatusCode = 400 });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, StatusCode = 500 });
            }
        }

        // GET: api/Booking/ViewByClinicId/{clinicId}
        [HttpGet("ViewByClinicId/{clinicId}")]
        public IActionResult ViewBookingsByClinicId(int clinicId)
        {
            var bookings = _bookingService.ViewBookingsByClinicId(clinicId);
            if (bookings == null || !bookings.Any())
            {
                return NotFound(new { Message = "No bookings found for the specified clinic ID", StatusCode = 404 });
            }
            return Ok(new { Data = bookings, Message = "Bookings retrieved successfully", StatusCode = 200 });
        }

        // GET: api/Booking/ViewByClinicSpecialization/{specialization}
        [HttpGet("ViewByClinicSpecialization/{specialization}")]
        public IActionResult ViewBookingsByClinicSpecialization(string specialization)
        {
            var bookings = _bookingService.ViewBookingsByClinicSpecialization(specialization);
            if (bookings == null || !bookings.Any())
            {
                return NotFound(new { Message = "No bookings found for the specified specialization", StatusCode = 404 });
            }
            return Ok(new { Data = bookings, Message = "Bookings retrieved successfully", StatusCode = 200 });
        }

        // GET: api/Booking/ViewByPatientId/{patientId}
        [HttpGet("ViewByPatientId/{patientId}")]
        public IActionResult ViewBookingsByPatientId(int patientId)
        {
            var bookings = _bookingService.ViewBookingsByPatientId(patientId);
            if (bookings == null || !bookings.Any())
            {
                return NotFound(new { Message = "No bookings found for the specified patient ID", StatusCode = 404 });
            }
            return Ok(new { Data = bookings, Message = "Bookings retrieved successfully", StatusCode = 200 });
        }

        // GET: api/Booking/ViewByPatientName/{patientName}
        [HttpGet("ViewByPatientName/{patientName}")]
        public IActionResult ViewAppointmentsByPatientName(string patientName)
        {
            var bookings = _bookingService.ViewAppointmentsByPatientName(patientName);
            if (bookings == null || !bookings.Any())
            {
                return NotFound(new { Message = "No bookings found for the specified patient name", StatusCode = 404 });
            }
            return Ok(new { Data = bookings, Message = "Bookings retrieved successfully", StatusCode = 200 });
        }

        // POST: api/Booking/AddBooking
        [HttpPost("AddBooking")]
        public IActionResult AddBooking(string CSepcia, int NumberOfSlots)
        {
            try
            {
                // Implementation for adding a booking based on the parameters.
                return Ok(new { Message = "Booking added successfully", StatusCode = 201 });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message, StatusCode = 500 });
            }
        }
    }
}
