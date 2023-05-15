using BookAPI.BL;
using BookAPI.Domain;
using BookAPI.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace customerAPI.Presentation.Controllers
{
    /// <summary>
    /// It is controller of customer
    /// </summary>
    [Route("api/[controller]s")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        #region Private Properties
        private readonly IBLCustomer _customerService;
        private readonly int _userId = 1;
        #endregion

        #region Constructor
        public CustomerController(IBLCustomer customerService)
        {
            _customerService = customerService;

            //var identity = httpContext.User.Identity as ClaimsIdentity;
            //int.TryParse(identity.Claims.FirstOrDefault(x => x.Type == "UserId").Value, out userId);
        }
        #endregion

        #region Public Methods

        #region GetCustomerAsync
        /// <summary>
        /// Get list of customers
        /// </summary>
        /// <returns> List of customer in json</returns>
        [HttpGet]
        public async Task<IActionResult> GetCustomerAsync()
        {
            return Ok(JsonSerializer.Serialize(await _customerService.GetAllAsync(_userId)));
        }
        #endregion

        #region GetCustomerByIdAsync
        /// <summary>
        /// Get customer by id
        /// </summary>
        /// <param name="id"> id represent a primary key of customer table</param>
        /// <returns>customer in json</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id, _userId);
            if (customer != null)
            {
                return Ok(JsonSerializer.Serialize(customer));
            }
            return NotFound(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "customer not found"
            }));
        }
        #endregion

        #region AddCustomerAsync
        /// <summary>
        /// Add customer in customer table
        /// </summary>
        /// <param name="customer">customer is object which we want to add</param>
        /// <returns>Message model which contains message that customer is successfully created or not</returns>
        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(BOSD02 customer)
        {
            customer.D02F06 = _userId;
            if (await _customerService.AddAsync(customer))
            {
                return Created("", JsonSerializer.Serialize(new MessageModel()
                {
                    Message = "customer added successfully"
                }));
            }
            return BadRequest(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "customer doesn't added successfully"
            }));
        }
        #endregion

        #region UpdateCustomerAsync
        /// <summary>
        /// update customer in customer table
        /// </summary>
        /// <param name="customer">customer is object which contains new value which we want to update</param>
        /// <returns>Message model which contains message that customer is successfully updated or not</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(BOSD02 customer)
        {
            customer.D02F06 = _userId;
            if (await _customerService.UpdateAsync(customer, _userId))
            {
                return Ok(JsonSerializer.Serialize(new MessageModel()
                {
                    Message = "customer updated successfully"
                }));
            }
            return BadRequest(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "customer doesn't updated successfully"
            }));
        }
        #endregion

        #region DeleteCustomerAsync
        /// <summary>
        /// delete customer from customer table
        /// </summary>
        /// <param name="id">id represent a primary key of customer which we want to delete</param>
        /// <returns>Message model which contains message that customer is successfully deleted or not</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (await _customerService.DeleteAsync(id, _userId))
            {
                return Ok(JsonSerializer.Serialize(new MessageModel()
                {
                    Message = "customer deleted successfully"
                }));
            }
            return NotFound(JsonSerializer.Serialize(new MessageModel()
            {
                Message = "customer not found"
            }));
        }
        #endregion

        #endregion
    }
}
