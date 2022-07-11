using AutoMapper;
using FinalProject.Core.Customers;
using FinalProject.Core.DTOs;
using FinalProject.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Customer> _service;

        public CustomersController(IService<Customer> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Tüm Müşterileri Listeler
        /// </summary>
        /// <returns>List of Customer döndürür.</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var customer = await _service.GetAllAsync();
            var customersDto = _mapper.Map<List<CustomerDto>>(customer.ToList());
            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customersDto));
        }

        /// <summary>
        /// Seçili Müşteriyi Getirir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            var customersDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customersDto));

        }

        /// <summary>
        /// Müşteri Ekler
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> Save(CustomerDto customerDto)
        {
            var customer = await _service.AddAsync(_mapper.Map<Customer>(customerDto));
            var customersDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(201, customersDto));//201 created

        }

        /// <summary>
        /// Müşteriyi Günceller
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<IActionResult> Update(CustomerDto customerDto)
        {
            await _service.UpdateAsync(_mapper.Map<Customer>(customerDto));
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(204)); 

        }

        /// <summary>
        /// Müşteriyi Siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/customers/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customer);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }
    }

}
