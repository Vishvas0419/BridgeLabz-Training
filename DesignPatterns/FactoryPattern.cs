using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class FactoryPattern
    {

    }

    //interface

    public interface INotification
    {
        void SendNotification(string message);
    }


    //different services to send notification
    public class EmailService : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("Email Sent : " + message);
        }
    }
    public class SMSService : INotification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine("SMS Sent : " + message);
        }
    }


    

    //factory that will create objects according to user demand
    public class NotificationFactory
    {
        //private INotification notification;
        public static INotification CreateNotification(string type)
        {
            if (type == "email")
            {
                return new EmailService();
            }
            else if (type == "sms")
            {
                return new SMSService();
            }
            //return null;
            throw new ArgumentException("Invalid notification type");
        }
    }

    //bussiness logic will call the CreateNotification method in factory class
    public class OrderService
    {
        public void SendNotification(string type, string message)
        {
            INotification notification = NotificationFactory.CreateNotification(type);
            notification.SendNotification(message);
        }
    }


    //example 2 - Payment factory
    //public interface IPayment
    //{
    //    public void Pay(string message);
    //}

    //public class UPIPayment : IPayment
    //{
    //    public void Pay(string message)
    //    {
    //        Console.WriteLine("payment done through UPI : "+message);
    //    }
    //}

    //public class CreditCardPayment : IPayment
    //{
    //    public void Pay(string message)
    //    {
    //        Console.WriteLine("payment done through Credit Card : " + message);
    //    }
    //}

    //public class PaymentFactory
    //{
    //    public static IPayment CreatePayment(string type)
    //    {
    //        if (type == "UPI") return new UPIPayment();
    //        else if(type =="Credit Card") return new CreditCardPayment();
    //        throw new ArgumentException("Invalid Payment Method Type..!");
    //    }
    //}
    //public class PaymentProcessor
    //{
    //    public void ProcessPayment(string type, string message)
    //    {
    //        //UPIPayment upiPayment = new UPIPayment();
    //        //upiPayment.Pay(message);

    //        IPayment payment = PaymentFactory.CreatePayment(type);
    //        payment.Pay(message);
    //    }
    //}

}
