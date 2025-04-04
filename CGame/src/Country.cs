

namespace CountryGame
{
    public class Country
    {
        private string _name;

        public string Name { get { return _name; } set { _name = value; } }
        public bool IsUsed { get; set; } = false;
    }
}
