using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LinkedList
{
    internal class Inventory
    {
        //Item Name, Item ID, Quantity, and Price
        private string name;
        private int itemID;
        private int quantity;
        private int price;

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int ItemID
        {
            get { return itemID; }
            private set
            {
                itemID = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            private set { quantity = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Inventory(int itemID, string name, int quantity, int price)
        {
            this.itemID = itemID;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.price = price;
        }
    }

    //just like Node class in basic LL
    internal class InventoryNode 
    {
        //initialising data from Inventory class, next from InventoryNode this class
        private Inventory data;
        public Inventory Data
        {
            get { return data; }
            set {  data = value; }
        }

        private InventoryNode next;
        public InventoryNode Next
        {
            get { return next; }
            set { next = value; }
        }

        //making contrcutors of InventoryNode to initialise new Node

        public InventoryNode(Inventory data)
        {
            Data = data;
            Next = null;
        }
    }

    internal class InventoryLinkedList
    {

        private InventoryNode head;
        private int count;

        public int Count
        {
            get { return count; }
            set {  count = value; }
        }

        public void AddAtBeginning(Inventory inventory)
        {
            InventoryNode newNode = new InventoryNode(inventory);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        public void AddAtEnd(Inventory inventory)
        {
            InventoryNode newNode = new InventoryNode(inventory);
            //InventoryNode temp = head;
            if(head==null)
            {
                head= newNode;
                count++;
                return;
            }
            InventoryNode curr = head;
            while(curr.Next != null)
            {
                curr = curr.Next;
            }
            curr.Next = newNode;
            count++;
        }

        public void AddAtPosition(Inventory inventory,int position)
        {
            InventoryNode newNode = new InventoryNode(inventory);
            if (position <= 0 || position > count + 1)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position out of scope");
            }
            if(position == 1)
            {
                AddAtBeginning(inventory);
                return;
            }
            InventoryNode curr = head;
            for(int i=1;i<position-1;i++)
            {
                curr = curr.Next;
            }
            InventoryNode temp = curr.Next;
            newNode.Next = temp;
            curr.Next = newNode;
            //newNode.Next = curr;
        }
        public void Display()
        {

        }
    }


}
