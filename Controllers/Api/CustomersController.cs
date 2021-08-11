using Microsoft.Ajax.Utilities;
using MovieApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using MovieApplication.Dtos;
using AutoMapper;


namespace MovieApplication.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //THIS WILL RESPOND TO GET/Api/customer
 
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.customers
                .Include(c => c.membershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
        }
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Customer,CustomerDto>(customer);
        }
        //POST /api/custommers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+ "/"+ customer.Id),customerDto);
        }
        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.customers.SingleOrDefault(c => c.Id==id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto,customerInDb);
            _context.SaveChanges();
            /*customerInDb.Name = customerDto.Name;
            customerInDb.Birthdate = customerDto.Birthdate;
            customerInDb.membershipNameId = customerDto.membershipNameId;
            customerInDb.isSubscribedToNewsLetter = customerDto.isSubscribedToNewsLetter;*/

        }
        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
