using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Test_Schad.Maintenance.Models;

namespace Test_Schad.Maintenance.Repositories
{
    public class CustomerTypeRepository : BaseRepository
    {
        public static ResponseModel<CustomerType> Get()
        {
            var response = new ResponseModel<CustomerType>();
            try
            {
                string query = "select * from CustomerTypes";
                var result = Query<CustomerType>(query);
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

        public static ResponseModel<CustomerType> GetById(int Id)
        {
            var response = new ResponseModel<CustomerType>();
            try
            {
                string query = "select * from CustomerTypes where Id = @Id";
                var result = Query<CustomerType>(query, new { Id });
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

        public static ResponseModel<CustomerType> Update(CustomerType model)
        {
            var response = new ResponseModel<CustomerType>();
            try
            {
                string query = "Update CustomerTypes Set Name = @Name, Description = @Description Where Id = @Id";

                var result = Query<CustomerType>(query, model);
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");

            }
            return response;
        }

        public static ResponseModel<CustomerType> Delete(int Id)
        {
            var response = new ResponseModel<CustomerType>();
            try
            {
                string query = "delete from CustomerTypes where Id = @Id";
                var result = Query<CustomerType>(query, new { Id });
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");
            }
            return response;
        }


        public static ResponseModel<CustomerType> Insert(CustomerType model)
        {
            var response = new ResponseModel<CustomerType>();
            try
            {
                string query = "Insert Into CustomerTypes (Name, Description) Values (@Name, @Description)";

                var result = Query<CustomerType>(query, model);
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
