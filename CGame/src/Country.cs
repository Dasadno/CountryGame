

namespace CountryGame
{
    public class Country
    {
        private string _name;

        private bool _isUsed = false;

        public string Name { get { return _name; } set { _name = value; } }

        public bool IsUsed { get { return _isUsed; } set { _isUsed = value; } }

        
    }
}
