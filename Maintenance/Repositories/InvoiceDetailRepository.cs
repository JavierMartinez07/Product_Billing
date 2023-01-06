using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Schad.Maintenance.Models;

namespace Test_Schad.Maintenance.Repositories
{
    public class InvoiceDetailRepository : BaseRepository
    {
        public static ResponseModel<InvoiceDetail> Get()
        {
            var response = new ResponseModel<InvoiceDetail>();
            try
            {
                string query = "select * from InvoiceDetail";
                var result = Query<InvoiceDetail>(query);
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

        public static ResponseModel<InvoiceDetail> GetById(int Id)
        {
            var response = new ResponseModel<InvoiceDetail>();
            try
            {
                string query = "select * from InvoiceDetail where Id = @Id";
                var result = Query<InvoiceDetail>(query, new { Id });
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

        public static ResponseModel<InvoiceDetail> GetByInvoiceId(int Id)
        {
            var response = new ResponseModel<InvoiceDetail>();
            try
            {
                string query = "select * from InvoiceDetail where InvoiceId = @Id";
                var result = Query<InvoiceDetail>(query, new { Id });
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

        public static ResponseModel<InvoiceDetail> Update(int Id)
        {
            var response = new ResponseModel<InvoiceDetail>();
            try
            {
                string query = @"
                Update InvoiceDetail 
                set Qty = @Qty,
                Price = @Price,
                TotalTax = @TotalTax,
                SubTotal = @SubTotal,
                Total = @Total
                Where Id = @Id";

                var result = Query<InvoiceDetail>(query, new { Id });
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");

            }
            return response;
        }

        public static ResponseModel<InvoiceDetail> Delete(int Id)
        {
            var response = new ResponseModel<InvoiceDetail>();
            try
            {
                string query = $"delete from InvoiceDetail where Id = @Id";
                var result = Query<InvoiceDetail>(query, new { Id });
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");
            }
            return response;
        }
        public static ResponseModel<InvoiceDetail> DeleteByInvoiceId(int Id)
        {
            var response = new ResponseModel<InvoiceDetail>();
            try
            {
                string query = $"delete from InvoiceDetail where InvoiceId = @Id";
                var result = Query<InvoiceDetail>(query, new { Id });
            }
            catch (Exception e)
            {
                response.OK= false;
                response.Message.Add(e.Message);
                response.Message.Add(e.StackTrace ?? "");
            }
            return response;
        }


        public static ResponseModel<InvoiceDetail> Insert(InvoiceDetail model)
        {
            var response = new ResponseModel<InvoiceDetail>();
            try
            {
                string query = @"
                Insert Into InvoiceDetail (InvoiceId, ItemId, Qty, Price, TotalTax, SubTotal, Total) 
                Values (@InvoiceId, @ItemId, @Qty, @Price, @TotalTax, @SubTotal, @Total) 
                ";

                var result = Query<InvoiceDetail>(query, model);
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
