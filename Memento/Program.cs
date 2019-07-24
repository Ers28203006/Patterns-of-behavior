using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class HeroOriginator
    {
        public int bullet = 10;
        public string bulletInfo = string.Empty;

        public void Shot(int countShot)
        {
            if (countShot <= bullet)
            {
                bullet -= countShot;
                bulletInfo = $"у вас осталось {bullet} патронов";
            }

            else
            {
                bulletInfo=" у вас закончились патроны";
            }
        } 

        public SaveGameMemento SaveGame()
        {
            return new SaveGameMemento(bullet, bulletInfo);
        }

        public void ReturnGame(SaveGameMemento saveGameMemento)
        {
            bullet = saveGameMemento.Bullet;
            bulletInfo = saveGameMemento.BulletInfo;
        }
    }

    class SaveGameMemento
    {
        public int Bullet { get; private set; }
        public string BulletInfo { get; private set; }

        public SaveGameMemento(int bullet, string bulletInfo)
        {
            Bullet = bullet;
            BulletInfo = bulletInfo;
        }
    }

    class StateGameCareteker
    {
        public SaveGameMemento SaveGameMemento { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            HeroOriginator hero = new HeroOriginator();
            StateGameCareteker stateGameCareteker = new StateGameCareteker();
            Console.WriteLine("Боекомплект пистолета игрока - 10 патронов. " +
                "Игрок делает 3 выстрела......");
            hero.Shot(3);
            Console.WriteLine("Игрок сохраняет игру");
            stateGameCareteker.SaveGameMemento = hero.SaveGame();
            Console.WriteLine("Игрок возвращается в игру");
            hero.ReturnGame(stateGameCareteker.SaveGameMemento);

            Console.WriteLine($"На момент начала игры {hero.bulletInfo}");
        }
    }
}
