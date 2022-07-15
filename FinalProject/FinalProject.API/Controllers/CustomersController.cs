using AutoMapper;
using FinalProject.Core.DTOs;
using FinalProject.Core.Models;
using FinalProject.Core.Services;
using FinalProject.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin")]
    public class CustomersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Customer> _service;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        public CustomersController(IService<Customer> service, IMapper mapper, RabbitMQPublisher rabbitMQPublisher)
        {
            _service = service;
            _mapper = mapper;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        /// <summary>
        /// Tüm Müşterileri Listeler
        /// </summary>
        /// <returns>List of Customer döndürür.</returns>
        [HttpGet]
        [Authorize(Roles = "admin, editor")]
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
        [Authorize(Roles = "admin, editor")]
        public async Task<IActionResult> Save(CustomerDto customerDto/*, IFormFile ImageFile*/)
        {
            //if (ImageFile is { Length: > 0 })
            //{
            //    var randomImageName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);


            //    var path = Path.Combine(Directory.GetCurrentDirectory(), "images", randomImageName);


            //    await using FileStream stream = new(path, FileMode.Create);


            //    await ImageFile.CopyToAsync(stream);


            //    _rabbitMQPublisher.Publish(new customerImageCreatedEvent() { ImageName = randomImageName });

            //    customerDto.ImageURL = randomImageName;
            //}

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
        [Authorize(Roles = "admin, editor")]
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
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(customer);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

        }

        /// <summary>
        /// Tüm Müşterileri Siler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE api/customers
        //[HttpDelete()]
        //[Authorize(Roles = "admin")]
        //public IActionResult RemoveAll(IEnumerable<int> existing)
        //{
        //    var profile = await _mapper.Include(x => x.Locations).FirstOrDefaultAsync(x => x.Id == id);

        //    var existing = profile.Locations.Where(x => locationsIds.Contains(x.Id)).ToList();
        //    _service.RemoveRange(0, existing.Count());


        //    return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        //}
    }

}
