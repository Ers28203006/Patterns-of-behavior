using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAIN_OF_RESPONSIBILITY
{
    abstract class ErrorsHandler
    {
        public ErrorsHandler Successor { get; set; }
        public abstract void HandlerRequest(int errorNumber);
    }

    class Error200 : ErrorsHandler
    {
        public override void HandlerRequest(int errorNumber)
        {
            if (errorNumber==200)
            {
                Console.WriteLine("OK — успешный запрос");
            }
            else if (Successor != null)
            {
                Successor.HandlerRequest(errorNumber);
            }
        }
    }

    class Error400 : ErrorsHandler
    {
        public override void HandlerRequest(int errorNumber)
        {
            if (errorNumber==400)
            {
                Console.WriteLine("Bad Request — сервер обнаружил в запросе клиента синтаксическую ошибку");
            }
            else if (Successor != null)
            {
                Successor.HandlerRequest(errorNumber);
            }
        }
    }

    class Error404 : ErrorsHandler
    {
        public override void HandlerRequest(int errorNumber)
        {
            if (errorNumber == 404)
            {
                Console.WriteLine("Forbidden — сервер понял запрос, но он отказывается его выполнять из-за ограничений в доступе для клиента к указанному ресурсу");
            }
            else if (Successor != null)
            {
                Successor.HandlerRequest(errorNumber);
            }
        }
    }
    class Error501 : ErrorsHandler
    {
        public override void HandlerRequest(int errorNumber)
        {
            if (errorNumber == 501)
            {
                Console.WriteLine("Not Implemented — сервер не поддерживает возможностей, необходимых для обработки запроса");
            }
            else if (Successor != null)
            {
                Successor.HandlerRequest(errorNumber);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ErrorsHandler handler200 = new Error200();
            ErrorsHandler handler400 = new Error400();
            ErrorsHandler handler404 = new Error404();
            ErrorsHandler handler501 = new Error501();

            handler200.Successor = handler400;
            handler400.Successor = handler404;
            handler404.Successor = handler501;

            handler200.HandlerRequest(400);
        }
    }
}
