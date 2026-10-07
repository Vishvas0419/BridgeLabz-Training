using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesignPatterns
{
    internal class AbstractFactoryPattern
    {

    }
    //common capabilities of each provider : Rayzorpay and stripe
    //create product interfaces : These interfaces describe what the products can do, not how they do it
    public interface IPayment
    {
        public void Pay(double amount);
    }

    public interface IRefund
    {
        public void Refund(double amount);
    }

    //create concrete products of razorpay family : payment a`nd refund
    public class RazorPayPayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Rayzorpay payment of amount : "+amount);
        }
    }

    public class RazorPayRefund : IRefund
    {
        public void Refund(double amount)
        {
            Console.WriteLine("Razorpay refund of amount : "+amount);
        }
    }

    //similaerly for stripe family
    public class StripePayment : IPayment
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Stripe payment of amount : " + amount);
        }
    }

    public class StripeRefund : IRefund
    {
        public void Refund(double amount)
        {
            Console.WriteLine("Stripe refund of amount : " + amount);
        }
    }



    //create Abstract Factory : A factory capable of creating a complete payment-provider family (payment + refund).

    //We're saying: Any payment factory MUST know how to create: a Payment and Refund, It does not say which concrete payment or refund.
    public interface IPaymentFactory
    {
        public IPayment CreatePayment();
        public IRefund CreateRefund();

    }

    //create factories of each provider : Rayzorpay and stripe
    //which will returnn objects of the specific family of both the products through methods : CreatePayment() and CreateRefund();

    public class RazorPayFactory : IPaymentFactory
    {
        public IPayment CreatePayment()
        {
            return new RazorPayPayment();
        }
        public IRefund CreateRefund()
        {
            return new RazorPayRefund();
        }
    }

    public class StripeFactory : IPaymentFactory
    {
        public IPayment CreatePayment()
        {
            return new StripePayment();
        }
        public IRefund CreateRefund()
        {
            return new StripeRefund();
        }
    }


    //bussiness logic 
    //public class PaymentService
    //{
    //    private readonly IPaymentFactory _factory; //field
    //    public PaymentService(IPaymentFactory factory)
    //    {
    //        _factory = factory;
    //    }
    //    public void MakePayment(double amount)
    //    {
    //        IPayment payment = _factory.CreatePayment();//here factory is razorpay as we have explictly have said to ouor apllication in program.cs that we need to create objects of Razorpay provider so actua method called is RazorpayFactory.CreatePayment();
    //        payment.Pay(amount); //it is actually calling razorpay Pay() method because the factory injected in the constructor is of razorpay factory
    //    }
    //    public void MakeRefund(double amount)
    //    {
    //        IRefund refund = _factory.CreateRefund();
    //        refund.Refund(amount);
    //    }
    //}



    /*  APPLICATION
    │
    │ PaymentProvider = Razorpay
    ↓
new RazorpayFactory()
    │
    │ stored as
    ↓
IPaymentFactory
    │
    │ injected into
    ↓
PaymentService
    │
    │ MakePayment()
    ↓
factory.CreatePayment()
    │
    │ actual object is RazorpayFactory
    ↓
RazorpayFactory.CreatePayment()
    │
    ↓
new RazorpayPayment()
    │
    │ returned as
    ↓
IPayment
    │
    ↓
payment.Pay()
    │
    ↓
RazorpayPayment.Pay()*/



}
