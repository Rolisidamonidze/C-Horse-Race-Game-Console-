using System;
using System.Collections.Generic;


namespace Threading_HorseRaceGame {
	class Race {
		private List<Horse> _horses;
		private int _distance;

		public Race(int distance) {
			Console.CursorVisible = false;
			_distance = distance;
			_horses = new List<Horse>();
		}

		public void AddHorse(Horse horse) {
			_horses.Add(horse);
		}

		public void DisplayTrack() {
			for (int i = 0; i < _horses.Count; i++) {
				Console.SetCursorPosition(0, i);
				Console.Write(i);
				Console.SetCursorPosition(_distance, i);
				Console.Write("|");
			}
		}

		public void Start() {
			foreach (var horse in _horses) {
				horse.Thread.Start();
			}
			while (WinCheck()) {
				Display();
			}
		}

		private void Display() {
			DisplayTrack();
			foreach (var horse in _horses) {
				Console.SetCursorPosition(2, horse.Row);
				Console.Write(horse.Behind);
				Console.SetCursorPosition(horse.Position, horse.Row);
				Console.WriteLine("-");
			}
		}

		private bool WinCheck() {
			foreach (var horse in _horses) {
				if (horse.Position >= _distance) {
					horse.Win = true;
					Console.SetCursorPosition(_distance / 2, horse.Row + 1);
					Console.WriteLine($"Horse {horse.Row} Wins!");
					return false;
				}
			}
			return true;
		}
	}
}
