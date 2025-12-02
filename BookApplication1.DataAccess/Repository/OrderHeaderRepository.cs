using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookApplication1.DataAccess.Data;
using BookApplication1.DataAccess.Repository.IRepository;
using BookApplication1.Models.Models;

namespace BookApplication1.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader orderHeader)
        {
            _db.OrderHeaders.Update(orderHeader);
        }

        public void UpdateRazorpayOrderId(int orderId, string razorpayOrderId)
        {
            OrderHeader? orderHeader = _db.OrderHeaders.FirstOrDefault(o => o.Id == orderId);

            if (orderHeader != null && !string.IsNullOrEmpty(razorpayOrderId))
            {
                orderHeader.RazorpayOrderId = razorpayOrderId;
            }
        }

        public void UpdateRazorpayPaymentInfo(int orderId, string paymentId, string signature)
        {
            OrderHeader? orderHeader = _db.OrderHeaders.FirstOrDefault(o => o.Id == orderId);

            if (orderHeader != null)
            {
                if (!string.IsNullOrEmpty(paymentId))
                {
                    orderHeader.RazorpayPaymentId = paymentId;
                    orderHeader.PaymentDate = DateTime.Now;
                }

                if (!string.IsNullOrEmpty(signature))
                {
                    orderHeader.RazorpaySignature = signature;
                }
            }
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            OrderHeader? orderHeaderFromDB = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
            if (orderHeaderFromDB != null)
            {
                orderHeaderFromDB.OrderStatus = orderStatus;
                if (!String.IsNullOrEmpty(paymentStatus))
                    orderHeaderFromDB.PaymentStatus = paymentStatus;
            }
        }
    }


}
