using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class AdapterPattern
    {
    }

    // Our application's interface
    interface IPaymentService
    {
        public void Pay(double amount);
    }

    //Third-party class:
    public class RazorPayClient
    {
        public void MakePayment(double amount)
        {
            Console.WriteLine("RazorPay payment done of amount : "+amount);
        }
    }

    //Adapter class for making the 3rd party library compatible with the application's already existing interface
    public class RazorPayAdapter : IPaymentService //implementing the interface that our application expects.
    {
        private readonly RazorPayClient razorpayClient; //composition : using object of the already existing class instead of inheriting it
        public RazorPayAdapter(RazorPayClient razorpayClient) //injecting third party object to constructor
        {
            this.razorpayClient = razorpayClient;
        }

        public void Pay(double amount) //implementing the application interface method Pay() to adapter so that the adapter trnaslate Pay() to MakePayment()
        {
            razorpayClient.MakePayment(amount);
        }
    }
}
