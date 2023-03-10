using System;
namespace introApp
{
	public class Player
	{
		public string? name;
		public int? score = 0;
        public List<char> guessedLetters = new();

		public Player(string name)
		{
			this.name = name;
		}
    }
}

