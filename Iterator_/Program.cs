using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Word : IEnumerable
    {
        List<string> listWords = new List<string>()
        {
            "один",
            "два",
            "три",
            "четыре",
            "пять",
            "шесть",
            "семь",
            "восемь",
            "девять",
            "десять"
        };

        public string this[int index]
        {
            get
            {
                return listWords[index];
            }

            set
            {
                listWords.Insert(index, value);
            }
        }

        public int Count
        {
            get
            {
                return listWords.Count;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new Counter(this);
        }
    }

    internal class Counter : IEnumerator
    {
        Word _word;
        public static int current = -1;
        public Counter(Word word)
        {
            _word = word;
        }

        public static int CurrentCounter()
        {
            return current;
        }
        public object Current
        {
            get
            {
                return _word[current];
            }
        }

        public bool MoveNext()
        {
            if (current < _word.Count-1)
            {
                current++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            current = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable word = new Word();
            IEnumerator counter = word.GetEnumerator();
            Console.Write("\nНечетные: ");

            while (counter.MoveNext())
            {
                string w = counter.Current as string;
                if (Counter.CurrentCounter()%2==0)
                {
                    Console.Write(w+"   ");
                }
            }
            counter.Reset();
            Console.Write("\nЧетные: ");
            while (counter.MoveNext())
            {
                string w = counter.Current as string;
                if (Counter.CurrentCounter() % 2 != 0)
                {
                    Console.Write(w+" ");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
