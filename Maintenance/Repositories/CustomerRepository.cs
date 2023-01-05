using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Schad.Maintenance.Models;

namespace Test_Schad.Maintenance.Repositories
{
    public class CustomerRepository : BaseRepository
    {
        public static ResponseModel<Customer> Get()
        {
            var response = new ResponseModel<Customer>();
            try
            {
                string query = "select * from Customers";
                var result = Query<Customer>(query);
                response.Records.AddRange(result);
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");

            }

            return response;
        }

        public static ResponseModel<Customer> GetById(int Id)
        {
            var response = new ResponseModel<Customer>();
            try
            {
                string query = "select * from Customers where Id = @Id";
                var result = Query<Customer>(query, new { Id });
                response.Records.AddRange(result);
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");

            }

            return response;
        }

        public static ResponseModel<Customer> Update(Customer model)
        {
            var response = new ResponseModel<Customer>();
            try
            {
                string query = @"
                Update Customers 
                set CustName = @CustName,
                CustLastName = @CustLastName,
                Adress = @Adress,
                Status = @Status,
                CustomerTypeId = @CustomerTypeId
                Where Id = @Id";

                var result = Query<Customer>(query, model);
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");

            }
            return response;
        }

        public static ResponseModel<Customer> Delete(int Id)
        {
            var response = new ResponseModel<Customer>();
            try
            {
                string query = $"delete from Customers where Id = @Id";
                var result = Query<Customer>(query, new { Id });
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");
            }
            return response;
        }


        public static ResponseModel<Customer> Insert(Customer model)
        {
            var response = new ResponseModel<Customer>();
            try
            {
                string query = @"
                Insert Into Customers (CustName, CustLastName, Adress, Status, CustomerTypeId) 
                Values (@CustName,@CustLastName, @Adress, @Status, @CustomerTypeId) 
                ";

                var result = Query<Customer>(query, model);
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");
            }
            return response;
        }

    }
}
