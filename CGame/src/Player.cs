namespace CountryGame
{
    public class Player
    {
        private string _answer;
        private string _name;
        private int _rightAnswerCounter = 0;

        public Player() { }

        public string Name { get { return _name; } set { _name = value; } }
        public int Move { get; set; }
        public string Answer { get { return _answer; } set { _answer = value; } }
        public int Lives { get; set; } = 2;
        public int RightAnswerCouner { get { return _rightAnswerCounter; } set { _rightAnswerCounter = value; } }
      
      
        
        
    }
}
