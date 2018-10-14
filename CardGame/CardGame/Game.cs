using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Game
    {
        private List<Player> player;

        private List<Karta> deck;

        public Game()
        {
            player = new List<Player>();
            deck = new List<Karta>();

            player.Add(new Player { });
            player.Add(new Player { });
            CreateDeck();
        }

        public void CreateDeck()
        {
            for (int i = 0; i < 9; i++) 
            {
                for (int j = 0; j < 4; j++) 
                {
                    CreateKart(deck, j, i);
                }                
            }
        }

        public void Вistribution()
        {
            int turn = 0;
            int one = 1, zero = 0;

            for (int i =0;i < 36;i++)
            {
                if (turn == zero)
                {
                    player[zero].TakeKart(deck[i]);                    
                    turn++;
                }
                else if (turn == one)
                {
                    player[one].TakeKart(deck[i]);                    
                    turn = zero;                    
                }               
            }          
        }

        public void At(int index)
        {
            Console.WriteLine(deck[index].Mast);
            Console.WriteLine(deck[index].Type);
        } 

        private void CreateKart(List<Karta> list, int mast, int type)
        {
            Karta karta = new Karta();

            switch (type)
            {
                case 0: karta = mast == 0 ?  new Karta { Mast = Mast.Kresti, Type = TypeKarta.six } : mast == 1 ? new Karta { Mast = Mast.Bubni, Type = TypeKarta.six } : mast == 2 ? new Karta { Mast = Mast.Pika, Type = TypeKarta.six } : new Karta { Mast = Mast.Chervi, Type = TypeKarta.six };  break;
                case 1: karta = mast == 0 ?  new Karta { Mast = Mast.Kresti, Type = TypeKarta.seven } : mast == 1 ? new Karta { Mast = Mast.Bubni, Type = TypeKarta.seven } : mast == 2 ? new Karta { Mast = Mast.Pika, Type = TypeKarta.seven } : new Karta { Mast = Mast.Chervi, Type = TypeKarta.seven }; break;
                case 2: karta = mast == 0 ?  new Karta { Mast = Mast.Kresti, Type = TypeKarta.eight} : mast == 1 ? new Karta { Mast = Mast.Bubni, Type = TypeKarta.eight } : mast == 2 ? new Karta { Mast = Mast.Pika, Type = TypeKarta.eight } : new Karta { Mast = Mast.Chervi, Type = TypeKarta.eight };  break;
                case 3: karta = mast == 0 ?  new Karta { Mast = Mast.Kresti, Type = TypeKarta.nine } : mast == 1 ? new Karta { Mast = Mast.Bubni, Type = TypeKarta.nine } : mast == 2 ? new Karta { Mast = Mast.Pika, Type = TypeKarta.nine } : new Karta { Mast = Mast.Chervi, Type = TypeKarta.nine };  break;
                case 4: karta = mast == 0 ?  new Karta { Mast = Mast.Kresti, Type = TypeKarta.ten } : mast == 1 ? new Karta { Mast = Mast.Bubni, Type = TypeKarta.ten } : mast == 2 ? new Karta { Mast = Mast.Pika, Type = TypeKarta.ten } : new Karta { Mast = Mast.Chervi, Type = TypeKarta.ten };  break;
                case 5: karta = mast == 0 ?  new Karta { Mast = Mast.Kresti, Type = TypeKarta.jack } : mast == 1 ? new Karta { Mast = Mast.Bubni, Type = TypeKarta.jack } : mast == 2 ? new Karta { Mast = Mast.Pika, Type = TypeKarta.jack } : new Karta { Mast = Mast.Chervi, Type = TypeKarta.jack };  break;
                case 6: karta = mast == 0 ?  new Karta { Mast = Mast.Kresti, Type = TypeKarta.lady } : mast == 1 ? new Karta { Mast = Mast.Bubni, Type = TypeKarta.lady } : mast == 2 ? new Karta { Mast = Mast.Pika, Type = TypeKarta.lady } : new Karta { Mast = Mast.Chervi, Type = TypeKarta.lady };  break;
                case 7: karta = mast == 0 ?  new Karta { Mast = Mast.Kresti, Type = TypeKarta.king } : mast == 1 ? new Karta { Mast = Mast.Bubni, Type = TypeKarta.king } : mast == 2 ? new Karta { Mast = Mast.Pika, Type = TypeKarta.king } : new Karta { Mast = Mast.Chervi, Type = TypeKarta.king };  break;
                case 8: karta = mast == 0 ?  new Karta { Mast = Mast.Kresti, Type = TypeKarta.ACE } : mast == 1 ? new Karta { Mast = Mast.Bubni, Type = TypeKarta.ACE } : mast == 2 ? new Karta { Mast = Mast.Pika, Type = TypeKarta.ACE } : new Karta { Mast = Mast.Chervi, Type = TypeKarta.ACE };  break;
            }

            list.Add(karta);
        }

        public void shuffle()
        {
            Random random = new Random();

            int cycle = random.Next(30,70);

            for (int i = 0; i < cycle; i++) 
            {
                Swap(random.Next(0,35), random.Next(0, 35));
            }
        }

        private void Swap(int i,int j)
        {
            Karta karta = new Karta();

            karta = deck[i];

            deck[i] = deck[j];

            deck[j] = karta;
        }

        public void Start()
        {            
            int one = 1, zero = 0;            

            while (true)
            {
                Console.WriteLine($"Player1: {player[zero].GetKart(zero).Mast}, {player[zero].GetKart(zero).Type}");
                Console.WriteLine($"Player2: {player[one].GetKart(zero).Mast}, {player[one].GetKart(zero).Type}");

                if (Check(player[zero].GetKart(zero), player[one].GetKart(zero)) == 1)
                {
                    player[zero].TakeKart(player[one].GetKart(zero));
                    player[zero].TakeKart(player[zero].GetKart(zero));
                    player[zero].GetDeck().RemoveAt(zero);
                    player[one].GetDeck().RemoveAt(zero);
                }
                else if (Check(player[zero].GetKart(zero), player[one].GetKart(zero)) == 2)
                {
                    player[one].TakeKart(player[one].GetKart(zero));
                    player[one].TakeKart(player[zero].GetKart(zero));
                    player[one].GetDeck().RemoveAt(zero);
                    player[zero].GetDeck().RemoveAt(zero);
                }
                else
                {
                    player[zero].TakeKart(player[one].GetKart(zero));
                    player[zero].TakeKart(player[zero].GetKart(zero));
                    player[zero].GetDeck().RemoveAt(zero);
                    player[one].GetDeck().RemoveAt(zero);
                }

                if (player[zero].GetDeck().Count == 0)
                {
                    Console.WriteLine("Player2 Win");
                    Console.ReadLine();
                    break;
                }
                if (player[one].GetDeck().Count == 0)
                {
                    Console.WriteLine("Player1 Win");
                    Console.ReadLine();
                    break;
                }

                Console.ReadLine();
            }
        }

        private int Check(Karta kartaOne, Karta kartaTwo)
        {
            if (kartaOne.Type > kartaTwo.Type)
            {
                return 1;
            }
            else if (kartaOne.Type < kartaTwo.Type)
            {
                return 2;
            }
            return 0;
        }

    }
}
