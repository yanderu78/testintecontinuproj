using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GoodtimeApi.Binders;
using GoodtimeApi.Configuration;
using GoodtimeApi.Models;
using GoodtimeApi.Services;
using GoodtimeApi.SwaggerExamples;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Filters;

namespace GoodtimeApi.Controllers
{
    /// <summary>
    /// Foo controller.
    /// </summary>
    [Route("api/[controller]")]
    public class GoodtimeController : ControllerBase
    {
        private readonly ConnectionStrings _connectionStrings;
        private readonly IGoodtimeService _service;
        private readonly ILogger _logger;

        /// <summary>
        /// Creates new instance of <see cref="GoodtimeController"/>.
        /// </summary>
        /// <param name="connectionStrings">
        /// Instance of <see cref="IOptionsSnapshot{ConnectionStrings}"/> object that contains connection string.
        /// More information: https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1?view=aspnetcore-2.1
        /// </param>
        /// <param name="service">Instance of <see cref="IGoodtimeService"/></param>
        /// <param name="logger"></param>
        public GoodtimeController(IOptionsSnapshot<ConnectionStrings> connectionStrings, IGoodtimeService service, ILogger<GoodtimeController> logger)
        {
            _connectionStrings = connectionStrings.Value ?? throw new ArgumentNullException(nameof(connectionStrings));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _service.SetConnectionString(_connectionStrings.SqlCon);
        }

        /// <summary>
        /// Tries to retrieve all Bar objects.
        /// </summary>
        /// <response code="200">All available Bar objects retrieved.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("Bar"), ResponseCache(CacheProfileName = "default")]
        [ProducesResponseType(typeof(IEnumerable<Bar>), 200)]
        [SwaggerResponseExample(200, typeof(BarListResponseExample))]
        public async Task<IActionResult> Get()
        {
            var response = await _service.GetAllBars().ConfigureAwait(false);
            return Ok(response);
        }

        /// <summary>
        /// Tries to retrieve specified Bar.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <response code="200">Bar successfully retrieved.</response>
        /// <response code="404">Specified Bar doesn't exist.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("Bar/{id:int:min(1)}", Name = "getById")]
        [ProducesResponseType(typeof(Bar), 200)]
        [ProducesResponseType(404)]
        [SwaggerResponseExample(200, typeof(BarResponseExample))]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _service.GetBar(id).ConfigureAwait(false);

            if (response == null)
                return NotFound(id);

            return Ok(response);
        }

        /// <summary>
        /// Tries to retrieve all Reservations.
        /// </summary>
        /// <response code="200">All available Reservations objects retrieved.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("Reservation/{id:int:min(1)}", Name = "reservationGetById")]
        [ProducesResponseType(typeof(Reservations), 200)]
        [ProducesResponseType(404)]
        [SwaggerResponseExample(200, typeof(ReservationsResponseExemple))]
        public async Task<IActionResult> GetReservation(int id)
        {
            var response = await _service.GetReservations(id).ConfigureAwait(false);

            if (response == null)
                return NotFound(id);

            return Ok(response);
        }

        /// <summary>
        /// Tries to retrieve all MenuItem.
        /// </summary>
        /// <response code="200">All available MenuItem objects retrieved.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("Menu/{id:int:min(1)}", Name = "menuGetById")]
        [ProducesResponseType(typeof(IEnumerable<MenuItem>), 200)]
        [SwaggerResponseExample(200, typeof(MenuListResponseExample))]
        public async Task<IActionResult> GetMenu(int id)
        {
            var response = await _service.GetMenu(id).ConfigureAwait(false);

            return Ok(response);
        }

        /// <summary>
        /// Tries to create a new MenuItem.
        /// </summary>
        /// <param name="item">Instance of <see cref="MenuItem"/>.</param>
        /// <response code="200">Foo created.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("Menu/{id:int:min(1)}")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] MenuItem item, int id)
        {
            _service.CreateMenuItem(item, id);

            return Ok();
        }

        /// <summary>
        /// Tries to create a new Reservation.
        /// </summary>
        /// <param name="item">Instance of <see cref="Reservation"/>.</param>
        /// <response code="200">Foo created.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost("Reservation/{id:int:min(1)}/{user_id:int:min(1)}")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] Reservation item, int id, int user_id)
        {
            _service.CreateReservation(item, id, user_id);

            return Ok();
        }

        /// <summary>
        /// Tries to accept reservation.
        /// </summary>
        /// <param name="id"> </param>
        /// <response code="200">Reservation updated successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("Reservation/Accept/{id:int:min(1)}")]
        public async Task<IActionResult> AcceptReservation(int id)
        {
            _service.AcceptEvent(id);

            return Ok();
        }

        /// <summary>
        /// Tries to refuse reservation.
        /// </summary>
        /// <param name="id"> </param>
        /// <response code="200">Reservation updated successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPatch("Reservation/Refuse/{id:int:min(1)}")]
        public async Task<IActionResult> RefuseReservation(int id)
        {
            _service.RefuseEvent(id);

            return Ok();
        }

        /// <summary>
        /// Tires to delete specified MenuItem.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <response code="200">Item deleted successfully.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("Menu/{id:int:min(1)}")]
        public async Task<IActionResult> Delete(int id)
        {
            _service.DeleteMenuItem(id);

            return Ok();
        }

        /*
        /// <summary>
        /// Tries to create a new Picture.
        /// </summary>
        /// <param name="file">A file content</param>
        /// <returns></returns>
        [HttpPost("Picture")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(500)]
        [AddSwaggerFileUploadButton]
        public async Task<IActionResult> PostFile([ModelBinder(BinderType = typeof(JsonModelBinder))] Bar bar, IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.OpenReadStream().CopyToAsync(memoryStream);

                var path = Path.Combine(Path.GetTempPath(), file.FileName);
                await System.IO.File.WriteAllBytesAsync(path, memoryStream.ToArray());
            }

            var response = await _service.Create(bar);

            return CreatedAtRoute("getById", new { id = response }, response);
        }*/
    }
}