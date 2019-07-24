using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    abstract class Mediator
    {
        public abstract void Send(Service service);
    }

    abstract class Service
    {
        public Mediator _mediator;
        public Service(Mediator mediator)
        {
            _mediator = mediator;
        }
    }
    class OnlineStore : Mediator
    {
       public Customer Customer { get; set; }
        public StoreHouse StoreHouse { get; set; }
        public Courier Courier { get; set; }
        public override void Send(Service service)
        {
            if (service==Customer)
            {
                Customer.Order();
            }
            else if (service == StoreHouse)
            {
                StoreHouse.PackUp();
            }
            else
            {
                Courier.Delivery();
            }
        }
    }

    class Courier : Service
    {
        public Courier(Mediator mediator) : base(mediator)
        {
        }

        public void Delivery()
        {
            Console.WriteLine("Курьер отвозит товар заказчику");
        }
    }

    class StoreHouse : Service
    {
        public StoreHouse(Mediator mediator) : base(mediator)
        {
        }

        public void PackUp()
        {
            Console.WriteLine("Склад упаковывает товар");
        }
    }

    class Customer : Service
    {
        public Customer(Mediator mediator) : base(mediator)
        {
        }

        public void Order()
        {
            Console.WriteLine("Заказчик заказывает товар по телефону");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new OnlineStore();
            Service courier = new Courier(mediator);
            Service customer = new Courier(mediator);
            Service storeHouse = new Courier(mediator);


            Console.WriteLine("Шаг 1:");
            mediator.Send(customer);
            Console.WriteLine();
            Console.WriteLine("Шаг 2:");
            Console.WriteLine();
            mediator.Send(storeHouse);
            Console.WriteLine("Шаг 3:");
            mediator.Send(courier);
            Console.WriteLine();
        }
    }
}
