using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApplication1.Models.Models;

namespace BookApplication1.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdateRazorpayOrderId(int orderId, string razorpayOrderId);
        void UpdateRazorpayPaymentInfo(int orderId, string paymentId, string signature);
    }
}
