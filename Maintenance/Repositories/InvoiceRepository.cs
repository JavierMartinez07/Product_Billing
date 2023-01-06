using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Schad.Maintenance.Models;

namespace Test_Schad.Maintenance.Repositories
{
    public class InvoiceRepository : BaseRepository
    {
        public static ResponseModel<Invoice> Get()
        {
            var response = new ResponseModel<Invoice>();
            try
            {
                string query = "select * from Invoice";
                var result = Query<Invoice>(query);
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

        public static ResponseModel<Invoice> GetById(int Id)
        {
            var response = new ResponseModel<Invoice>();
            try
            {
                string query = "select * from Invoice where Id = @Id";
                var result = Query<Invoice>(query, new { Id });
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

        public static ResponseModel<Invoice> GetByCustomerId(int Id)
        {
            var response = new ResponseModel<Invoice>();
            try
            {
                string query = "select * from Invoice where CustomerId = @Id";
                var result = Query<Invoice>(query, new { Id });
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

        public static ResponseModel<Invoice> Update(int Id)
        {
            var response = new ResponseModel<Invoice>();
            try
            {
                string query = @"
                Update Invoice 
                set CustomerId = @CustomerId,
                TotalItbis = @TotalItbis,
                SubTotal = @SubTotal,
                Total = @Total
                Where Id = @Id";

                var result = Query<Invoice>(query, new { Id });
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");

            }
            return response;
        }

        public static ResponseModel<Invoice> Delete(int Id)
        {
            var response = new ResponseModel<Invoice>();
            try
            {
                string query = $"delete from Invoice where Id = @Id";
                var result = Query<Invoice>(query, new { Id });
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");
            }
            return response;
        }


        public static ResponseModel<Invoice> Insert(Invoice model)
        {
            var response = new ResponseModel<Invoice>();
            try
            {
                string query = @"
                Insert Into Invoice (CustomerId, TotalTax, SubTotal, Total) 
                Values (@CustomerId, @TotalTax, @SubTotal, @Total) 

                SELECT SCOPE_IDENTITY()
                ";

                var result = Query<int>(query, model);
                response.Values.Add(result.FirstOrDefault());
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
