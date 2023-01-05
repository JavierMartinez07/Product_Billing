﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Schad.Maintenance.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double TotalItbis { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }

    }
}