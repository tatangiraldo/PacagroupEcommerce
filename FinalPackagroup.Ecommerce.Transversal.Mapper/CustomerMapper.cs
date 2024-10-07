using FinalPackagroup.Ecommerce.Application.DTO;
using FinalPackagroup.Ecommerce.Domain.Entity;
using System;

namespace FinalPackagroup.Ecommerce.Transversal.Mapper
{
    public static class CustomerMapper
    {
        public static Customers Map(CustomersDTO dto)
        {
            return new Customers
            {
                CustomerID = dto.CustomerID,
                Address = dto.Address,
                City = dto.City,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                Country = dto.Country,
                Phone = dto.Phone,
                CompanyName = dto.CompanyName,
                ContactName = dto.ContactName,
                ContactTitle = dto.ContactTitle,
                Fax = dto.Fax,
            };
        }

        public static CustomersDTO Map(Customers customer)
        {
            return new CustomersDTO
            {
                CustomerID = customer.CustomerID,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Fax = customer.Fax,
            };
        }
    }
}
