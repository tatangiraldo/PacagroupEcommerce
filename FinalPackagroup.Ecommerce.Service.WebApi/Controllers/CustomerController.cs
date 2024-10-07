using FinalPackagroup.Ecommerce.Application.DTO;
using FinalPackagroup.Ecommerce.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinalPackagroup.Ecommerce.Service.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]     
    public class CustomerController : ControllerBase
    {
        private readonly IcustomerApplication _customerApp;
        public CustomerController(IcustomerApplication icustomerApplication)
        {
            _customerApp = icustomerApplication;
        }

        #region Sync methods

        [HttpPost]
        public IActionResult Insert([FromBody] CustomersDTO dto)
        {
            if (dto == null) return BadRequest();
            var response = _customerApp.Insert(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomersDTO dto)
        {
            if (dto == null) return BadRequest();
            var response = _customerApp.Update(dto);
            if (response.IsSuccess) {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();
            var result = _customerApp.Delete(customerId);
            if (result.IsSuccess) {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("{customerId}")]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) return BadRequest();
            var result = _customerApp.Get(customerId);
            if (result.IsSuccess) {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customerApp.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        #endregion

        #region Async

        [HttpPost]
        public async Task<ActionResult> InstertAS([FromBody] CustomersDTO dto)
        {
            if (dto == null) return BadRequest();
            var result = await _customerApp.InsertAsync(dto);
            if (result.IsSuccess) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAS([FromBody] CustomersDTO dto)
        {
            if (dto == null) return BadRequest();
            var result = await _customerApp.UpdateAsync(dto);
            if (result.IsSuccess) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult> DeleteAS(string customerId)
        {
            if (string.IsNullOrEmpty(customerId)) { return BadRequest(); }
            var result = await _customerApp.DeleteAsync(customerId);
            if (result.IsSuccess) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult> GetAS(string customerId) 
        {
            if (!string.IsNullOrEmpty(customerId)) return BadRequest();
            var result = await _customerApp.GetAsync(customerId);
            if (result.IsSuccess) {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAS()
        {
            var response = await _customerApp.GetAllAsync();
            if (response.IsSuccess)            
                return Ok(response);
            
            return BadRequest(response.Message);
        }
        #endregion
    }
}
