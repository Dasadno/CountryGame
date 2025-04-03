using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryGame
{
    public class Game
    {
        
        public int MoveOrder { get; set; }

        public int AmounthOfPlayers { get; set; }

        public string LastWord { get; set; }

        public char CurrentLetter
        {
            get
            {
                _currentLetter = LastWord[LastWord.Length - 1];
                return _currentLetter;
            }
        }
        public List<Country> CountryList
        { 
            get 
            {
                return _countryList;
            } 
        }

        public List<Player> PlayersList { get { return _players; } }


        public Game(int AmounthOfPlayers)
        {
            this.AmounthOfPlayers = AmounthOfPlayers;
            SetCollectorTitlesAsCountry();
            Start();
        }

        private void SetCollectorTitlesAsCountry()
        {
            DataCollector collector = new DataCollector(false);

            foreach (var name in collector.GetCountryList())
            {
                _countryList.Add(new Country { Name = name });
            }
            
        }

        public void PlayersSheet()
        {
            Console.Clear();
            foreach (Player player in _players)
            {
                Console.WriteLine($"Player moves {player.Move} in the game,\n" +
                    $"Name: {player.Name},\n" +
                    $"Right answers: {player.RightAnswerCouner},\n" +
                    $"Last answer: {player.Answer}\n\n");
               
            }
            Console.WriteLine("Press any button to play");
            if(Console.ReadKey() != null)
            {
                GameSheet.getInstance().GameSheetMethod(this);
            }
        }

        private void Start()
        {
            
            for (int i = 1; i < AmounthOfPlayers+1; i++)
            {
                Console.WriteLine($"Enter name of the player {i} : ");
                string name = Console.ReadLine();
                _players.Add(new Player { Move = i, Name = name });
            }
            
            PlayersSheet();
        }



        private char _currentLetter;

        private string _lastWord;

        private int _moveOrder = 1;

        private Player _winner = null;

        private List<Player> _players = new List<Player>();

        private List<Country> _countryList = new List<Country>(247);

    }
}