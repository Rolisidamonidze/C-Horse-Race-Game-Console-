using System;
using System.Threading;


namespace Threading_HorseRaceGame {
	class Horse {
		public Horse(int row) {
			Position = 2;
			Behind = "";
			Row = row;
			Win = false;
			Thread = new Thread(Run);
		}

		public Thread Thread { get; set; }
		public int Row { get; set; }
		public int Position { get; set; }
		public bool Win { get; set; }
		public string Behind { get; set; }

		public void Run() {
			while (!Win) {
				Thread.Sleep(new Random().Next(20, 120));
				Position++;
				Behind += " ";
			}
		}
	}
}
