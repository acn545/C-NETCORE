using System;
using System.Collections.Generic;
using System.linq;
using System.Text;


namespace LinkedList{
    // Linked lists are objects that hold data and a pointer to the next Node object.
    // good to use when you do not know how much data you will have because each node can be stored in a different part of memory
    public class Node{
        public int data;
        public Node next;
        //constructor for adding single value to node
        public Node(int i){
            data= i;
            next = null;
        }
        // recruisive method that writes the data of a node then continues on to each node till it reaches a null value
        public void Print(){
            Console.Console.WriteLine(" " + data + "->");
            if (next != null){
                next.Print();
            }
        }
        // this method checks if pointer = null, if it does it will call node to make a new node.
        // if it is not null the function calls it self making it recruisive and keeps checking the next node till it finds null
        public void AddToEnd(int data){
            if(next == null){
                next = new Node(data);
            }else{
                next.AddToEnd(data);
            }
        }
        public void AddSorted(int data){
            if(next == null){
                next = new Node(data);
            }else if(data < next.data){
                Node temp = new Node(data);
                temp.next = this.next;
                this.next = temp;
            }else{
                next.Addsorted(data);
            }
        }
    }
    public class MyList{
        public Node headNode;
        public MyList(){
            headNode = null;
        }
        public void AddToEnd(int data){
            if (headNode == null){
                headNode = new Node(data)
            }else{
                headNode.AddToEnd(data);
            }
        }
        public void AddSorted(int data){
            if(headNode == null){
                headNode = new Node(data);
            }else if(data < headNode.data){
                AddToBeginning(data);
            }else{
                headNode.AddSorted(data);
            }
        }

        public void AddToBeginning(int data){
            if(headNode == null){
                headNode = new Node(data);
            }else{
                node temp = new node(data);
                temp.next = headNode;
                headNode = temp;

            }
        }
        public void Print(){
            if(headNode != null){
                headNode.Print();
            }
        }
    }





    class program{
        static void Main(string[] args){
            //creates a new Node with a head value of 7
            Node myNode = new Node(7);
            // adds a new node in myNode by updating Nodes pointer value and creating a new node with the new data and new pointer

            // this is not scalable
            myNode.next = new Node(5);
            //better way is to use the new method AddToEnd
            myNode.AddToEnd(12);
            myNode.AddToEnd(15);
            // call print method
            myNode.Print();



        }
    }
}
