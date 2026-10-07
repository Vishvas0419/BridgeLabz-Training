using System.Text;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Singleton Pattern
            //DBConnection db1 = DBConnection.GetDBInstance();
            //DBConnection db2 = DBConnection.GetDBInstance();
            //Console.WriteLine(db1==db2);


            //Factory Pattern
            ////order placed notification service
            //OrderService orderService = new OrderService();
            //orderService.SendNotification("email", "Your order is placed successfully");
            //orderService.SendNotification("sms", "Your order is placed successfully");

            //payment proessing service

            //PaymentProcessor paymentProcessor = new PaymentProcessor();
            //paymentProcessor.ProcessPayment("UPI","Payment processed succesfully");



            //Abstract Factory Pattern

            //Now we decide which family we want.
            //suppose our application has configuration: PaymentProvider = "Razorpay"
            //IPaymentFactory paymentFactory = new RazorPayFactory();
            ////here through polymorphism the IPaymentFactory is the RazorPayFactory object which is decided at runtime 
            //PaymentService paymentService = new PaymentService(paymentFactory);
            //paymentService.MakePayment(2000);
            //paymentService.MakeRefund(500);

            //adapter pattern

            //RazorPayClient razorpay = new RazorPayClient();
            //IPaymentService payment = new RazorPayAdapter(razorpay); //runtimr poly
            //payment.Pay(2000);

            //Facade Pattern

            //create subsystem objects
            InventoryService inventoryService = new InventoryService();
            PaymentService paymentService = new PaymentService();
            DeliveryService deliveryService = new DeliveryService();
            NotificationService notificationService = new NotificationService();
            OrderFacade orderFacade = new OrderFacade(inventoryService, paymentService, deliveryService, notificationService);
            OrderController orderController = new OrderController(orderFacade);
            orderController.PlaceOrder();


        }
    }
}
