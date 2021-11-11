using System.Collections.Generic;
using FiscusApi.Models;

namespace FiscusApi.Repositories.Interface
{
    public interface IPaymentRepository  
    {
        /// <summary>
        /// Gets the payments.
        /// </summary>
        /// <returns>The payments.</returns>
        List<Payment> GetPayments();  

        /// <summary>
        /// Gets the payment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The payment.</returns>
        Payment GetPayment(int id);

        /// <summary>
        /// Adds the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        void AddPayment(Payment payment);

        /// <summary>
        /// Updates the payment.
        /// </summary>
        /// <param name="payment">The payment.</param>
        void UpdatePayment(Payment payment);

        /// <summary>
        /// Deletes the payment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeletePayment(int id);
    }  
}