using System;
using System.Collections.Generic;
using System.Linq;
using FiscusApi.DataAccess;
using FiscusApi.Models;
using FiscusApi.Repositories.Interface;

namespace FiscusApi.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly SqlContext _context;

        public PaymentRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Payment> GetPayments()
        {
            return _context.Payment.ToList();
        }

        public Payment GetPayment(int id)
        {
            return _context.Payment.FirstOrDefault(t => t.PaymentId == id);
        }

        public void AddPayment(Payment payment)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Payment.FirstOrDefault(x => x.PaymentId == payment.PaymentId);

                if (entity != null)
                    throw new Exception($"Entity with id: '{payment.PaymentId}' already exists.");

                _context.Payment.Add(payment);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void UpdatePayment(Payment payment)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                _context.Payment.Update(payment);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void DeletePayment(int id)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.Payment.FirstOrDefault(t => t.PaymentId == id);

                if (entity == null)
                    throw new Exception($"Entity with {id} not found.");

                _context.Payment.Remove(entity);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}