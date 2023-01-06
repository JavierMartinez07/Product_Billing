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
    public class ItemRepository : BaseRepository
    {
        public static ResponseModel<Item> Get()
        {
            var response = new ResponseModel<Item>();
            try
            {
                string query = "select * from Items";
                var result = Query<Item>(query);
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

        public static ResponseModel<Item> GetById(int Id)
        {
            var response = new ResponseModel<Item>();
            try
            {
                string query = "select * from Items where Id = @Id";
                var result = Query<Item>(query, new { Id });
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

        public static ResponseModel<Item> GetNameById(int Id)
        {
            var response = new ResponseModel<Item>();
            try
            {
                string query = "select Name from Items where Id = @Id";
                var result = Query<string>(query, new { Id });
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

        public static ResponseModel<Item> Update(Item model)
        {
            var response = new ResponseModel<Item>();
            try
            {
                string query = @"
                Update Items 
                Set Name = @Name, 
                Description = @Description, 
                Price = @Price, 
                Tax = @Tax
                Where Id = @Id";

                var result = Query<Item>(query, model);
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");

            }
            return response;
        }

        public static ResponseModel<Item> Delete(int Id)
        {
            var response = new ResponseModel<Item>();
            try
            {
                string query = "delete from Items where Id = @Id";
                var result = Query<Item>(query, new { Id });
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");
            }
            return response;
        }


        public static ResponseModel<Item> Insert(Item model)
        {
            var response = new ResponseModel<Item>();
            try
            {
                string query = @"
                Insert Into Items (Name, Description, Price, Tax) 
                Values (@Name, @Description, @Price, @Tax) ";

                var result = Query<Item>(query, model);
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
