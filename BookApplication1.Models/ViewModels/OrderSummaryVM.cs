using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApplication1.Models.Models;

namespace BookApplication1.Models.ViewModels
{
    public class OrderSummaryVM
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public double OrderTotal { get; set; }
        public ApplicationUser User { get; set; }
    }
}
