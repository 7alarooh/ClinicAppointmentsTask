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
            var result = await _bookingService.BookAppointmentAsync(patientId, clinicId, date);
            if (result.Contains("successfully booked"))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        // GET: api/Booking/ViewByClinicId/{clinicId}
        [HttpGet("ViewByClinicId/{clinicId}")]
        public IActionResult ViewBookingsByClinicId(int clinicId)
        {
            var bookings = _bookingService.ViewBookingsByClinicId(clinicId);
            return Ok(bookings);
        }

        // GET: api/Booking/ViewByClinicSpecialization/{specialization}
        [HttpGet("ViewByClinicSpecialization/{specialization}")]
        public IActionResult ViewBookingsByClinicSpecialization(string specialization)
        {
            var bookings = _bookingService.ViewBookingsByClinicSpecialization(specialization);
            return Ok(bookings);
        }

        // GET: api/Booking/ViewByPatientId/{patientId}
        [HttpGet("ViewByPatientId/{patientId}")]
        public IActionResult ViewBookingsByPatientId(int patientId)
        {
            var bookings = _bookingService.ViewBookingsByPatientId(patientId);
            return Ok(bookings);
        }

        // GET: api/Booking/ViewByPatientName/{patientName}
        [HttpGet("ViewByPatientName/{patientName}")]
        public IActionResult ViewAppointmentsByPatientName(string patientName)
        {
            var bookings = _bookingService.ViewAppointmentsByPatientName(patientName);
            return Ok(bookings);
        }

        // POST: api/Booking/AddBooking
        [HttpPost("AddBooking")]
        public IActionResult AddBooking(string CSepcia, int NumberOfSlots)
        {
            // Implementation for adding a booking based on the parameters.
            return Ok("Booking added successfully");
        }
    }
}
