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


    class OnlineStore : Mediator
    {
        private Service _courier;
        private Service _storeHouse;
        private Service _customer;

        public OnlineStore(Service courier, Service storeHouse, Service customer)
        {
            _courier = courier;
            _storeHouse = storeHouse;
            _customer = customer;
        }

        public override void Send(Service service)
        {
            if (service == _customer)
            {
                _customer.Send();
            }
            else if (service == _storeHouse)
            {
                _storeHouse.Send();
            }
            else if(service == _courier)
            {
                _courier.Send();
            }
        }
    }



    abstract class Service
    {
        public abstract void Send();
    }
    

    class Courier : Service
    {
        public override void Send()
        {
            Console.WriteLine("Курьер отвозит товар заказчику");
        }
    }

    class StoreHouse : Service
    {
        public override void Send()
        {
            Console.WriteLine("Склад упаковывает товар");
        }
    }

    class Customer : Service
    {
        public override void Send()
        {
            Console.WriteLine("Заказчик заказывает товар по телефону");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Service courier = new Courier();
            Service customer = new StoreHouse();
            Service storeHouse = new Customer();
            Mediator mediator = new OnlineStore(courier,  storeHouse, customer);


            Console.WriteLine("Шаг 1:");
            mediator.Send(customer);
            Console.WriteLine();
            Console.WriteLine("Шаг 2:");
            mediator.Send(storeHouse);
            Console.WriteLine();
            Console.WriteLine("Шаг 3:");
            mediator.Send(courier);
            Console.WriteLine();
        }
    }
}
