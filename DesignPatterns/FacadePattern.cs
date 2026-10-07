using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DesignPatterns
{
    internal class FacadePattern
    {
    }

    // we have four different subsystem components.
    public class InventoryService
    {
        public bool CheckStock()
        {
            Console.WriteLine("Checking stock...");
            return true;
        }
    }

    public class PaymentService
    {
        public bool ProcessPayment(double amount)
        {
            Console.WriteLine("Processing Payment...");
            return true;
        }
    }

    public class DeliveryService
    {
        public void CreateDelivery()
        {
            Console.WriteLine("Creating Delivery...");
        }
    }
    public class NotificationService
    {
        public void SendNotification()
        {
            Console.WriteLine("Sending Notification..");
        }
    }

    //without facade : controller directly handles everything and also it must know the order in which the method should be called

    //public class OrderController
    //{
    //    public void PlaceOrder()
    //    {
    //        InventoryService inventory = new InventoryService();
    //        PaymentService payment = new PaymentService();
    //        DeliveryService delivery = new DeliveryService();
    //        NotificationService notification = new NotificationService();

    //        if(inventory.CheckStock())
    //        {
    //            if(payment.ProcessPayment(1000))
    //            {
    //                delivery.CreateDelivery();
    //                notification.SendNotification();
    //            }
    //        }
    //    }
    //}

    //now with facade (thekedaar) the complexity is inside the facade class instead of OrderController class


    public class OrderFacade
    {
        private readonly InventoryService _inventory;
        private readonly PaymentService _payment;
        private readonly DeliveryService _delivery;
        private readonly NotificationService _notification;

        public OrderFacade(InventoryService inventory,PaymentService payment,DeliveryService delivery,NotificationService notification)
        {
            _inventory = inventory;
            _payment = payment;
            _delivery = delivery;
            _notification = notification;
        }

        public void PlaceOrder()
        {
            if (!_inventory.CheckStock()) return;
            if (!_payment.ProcessPayment(1000)) return;
            _delivery.CreateDelivery();
            _notification.SendNotification();
        }
    }

    //controller now simply becomes 
    public class OrderController
    {
        private readonly OrderFacade _orderFacade;
        public OrderController(OrderFacade orderFacade)
        {
            _orderFacade = orderFacade;
        }

        public void PlaceOrder()
        {
            _orderFacade.PlaceOrder();
            Console.WriteLine("Placing Order...");
        }
    }

}
