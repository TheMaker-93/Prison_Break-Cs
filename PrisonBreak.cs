using System;

namespace PrisonBreak
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			int W = 83;
			int H = 22;

			Random alea = new Random();

			ConsoleKeyInfo keyInfo;

			int prisonerX, prisonerY; // prisoner's coordinates
			int wardenX, wardenY; // warden's coordinates

			int dogX, dogY; // dog's coordinates
			int dogDeltaX, dogDeltaY; // dog's deltas

			int iteration; // iteration counter 

			bool prisonerWins; // has prisoner reached left wall?
			bool wardenWins;   // has warden captured prisoner?
			bool prisonerKilled;  // has dog killed prisoner?
			bool wardenKilled; // has dog killed warden?

			/* ADD MORE VARIABLES IF YOU NEED THEM ... */

			Console.SetWindowSize(W, H + 1);
			Console.SetBufferSize(W, H + 1);
			Console.CursorVisible = false;

			// INTRODUCTION
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("*********************************************");
			Console.WriteLine("             PRISON BREAK");
			Console.WriteLine("*********************************************");

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\n");
			Console.Write("Welcome to ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("PRISON BREAK ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("the best prison-evasion game ever.");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("PRISON BREAK ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("is a two-player keyboard-based game.");
			Console.WriteLine();
			Console.WriteLine("Player at the right side, you're the PRISONER");
			Console.WriteLine("\tPRISONER use the arrow keys to move.");
			Console.WriteLine("\tYour goal is to reach the leftmost side of the screen without being caught.");
			//Console.WriteLine();
			Console.WriteLine("Player at the left side, you're the WARDEN");
			Console.WriteLine("\tWARDEN use W(UP), A(LEFT), D(RIGHT) and S(DOWN) to move");
			Console.WriteLine("\tYour goal is to catch the prisoner");

			Console.WriteLine();
			Console.WriteLine("WARDEN, PRISONER, beware!!! A vicious dog guards the place");
			Console.WriteLine("It may bite any of you to death...");


			Console.SetCursorPosition(0, Console.WindowHeight - 1);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("There you go. Press any key to start...");
			Console.ReadKey(true);
			Console.Clear();

			// SET initial positions

			prisonerX = W - 1;				
			prisonerY = alea.Next(0, H);

			wardenX = 0;
			wardenY = alea.Next(0, H);

			dogX = W / 2;
			dogY = H / 2;

			dogDeltaX = 1;
			dogDeltaY = 1;


			// show prisoner, warden and dog
			Console.SetCursorPosition(prisonerX, prisonerY);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("P");

			Console.SetCursorPosition(wardenX, wardenY);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("W");

			Console.SetCursorPosition(dogX, dogY);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("D");

			iteration = 0;
			prisonerWins = false; wardenWins = false;
			prisonerKilled = false; wardenKilled = false;

			while (!(prisonerWins || wardenWins || prisonerKilled || wardenKilled))
			{
				iteration++;

				/* COMPLETE */
				if (iteration % 4 == 0)
				{
					// ----------- DOG ------------------//
					// hide of the "sprite"
					Console.SetCursorPosition(dogX, dogY);
					Console.Write(" ");

					// calculate new position
					// DELTA X
					if (alea.Next(0, 100) > 90)
					{
						if (dogDeltaX == 0)
						{
							if (alea.Next(0, 100) > 50)
							{
								dogDeltaX = 1;
							}
							else {
								dogDeltaX = -1;
							}
						}
						else if (dogDeltaY != 0)
						{
							dogDeltaX = 0;
						}
					}

					// DELTA Y
					if (alea.Next(0, 100) > 90)
					{
						if (dogDeltaY == 0)
						{
							if (alea.Next(0, 100) > 50)
							{
								dogDeltaY = 1;
							}
							else {
								dogDeltaY = -1;
							}
						}
						else if (dogDeltaX != 0)
						{
							dogDeltaY = 0;
						}
					}

					// PREVENT THE DOG FROM GOING OUT OF THE PLAY ZONE
					if (dogX == 0) 
					{ 
						dogDeltaX = 1; 
					} else if (dogX == W - 1) 
					{ 
						dogDeltaX = -1; 
					}

					if (dogY == 0) 
					{ 
						dogDeltaY = 1; 
					} else if (dogY == H - 1) 
					{ 
						dogDeltaY = -1; 
					}

					// apply the new position
					dogX += dogDeltaX;
					dogY += dogDeltaY;

					// show the new position on screen
					Console.SetCursorPosition(dogX, dogY);
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.Write("D");
					// ----------- --- ------------------//
				}


				if (Console.KeyAvailable)                   // if there are some key pressed...
				{
					// set user interaction
					keyInfo = Console.ReadKey(true);        // we save the data of the key pressed on KeyInfo

					// ----------- WARDEN ------------------//

					// remove the "sprite"
					Console.SetCursorPosition(wardenX, wardenY);
					Console.Write(" ");

					// process the pressed key
					switch (keyInfo.Key)                    // acces the -key- component
					{
						case (ConsoleKey.W):
							if (wardenY > 0)
							{
								wardenY--;
							}
							break;
						case (ConsoleKey.S):
							if (wardenY < H - 1)
							{
								wardenY++;
							}
							break;
						case (ConsoleKey.A):
							if (wardenX > 0)
							{
								wardenX--;
							}
							break;
						case (ConsoleKey.D):
							if (wardenX < W -1)
							{
								wardenX++;
							}
							break;
					}

					// redraw on the new position
					Console.ForegroundColor = ConsoleColor.Green;
					Console.SetCursorPosition(wardenX, wardenY);
					Console.Write("W");

					// ----------- ------ ------------------//

					// ----------- PRISONER ------------------//

					// hide
					Console.SetCursorPosition(prisonerX, prisonerY);
					Console.Write(" ");

					// process of the pressed key
					switch (keyInfo.Key)                    // acces the -key- component
					{
						case (ConsoleKey.UpArrow):
							if (prisonerY > 0)
							{
								prisonerY--;
							}
							break;
						case (ConsoleKey.DownArrow):
							if (prisonerY < H - 1)
							{
								prisonerY++;
							}
							break;
						case (ConsoleKey.LeftArrow):
							if (prisonerX > 0)
							{
								prisonerX--;
							}
							break;
						case (ConsoleKey.RightArrow):
							if (prisonerX < W-1)
							{
								prisonerX++;
							}
							break;
					}

					// redraw
					Console.ForegroundColor = ConsoleColor.Red;
					Console.SetCursorPosition(prisonerX, prisonerY);
					Console.Write("P");

					// ----------- -------- ------------------//

				}

				// check current situation...
				prisonerWins = prisonerX == 0;
				wardenWins = wardenX == prisonerX && wardenY == prisonerY;
				prisonerKilled = dogX == prisonerX && dogY == prisonerY;
				wardenKilled = dogX == wardenX && dogY == wardenY;

				System.Threading.Thread.Sleep(15); // delay. Do not change it

			} // main loop ends here. 
			// when this point is reached, game is over...

			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("\n\n\n");
			if (prisonerWins)
			{
				Console.WriteLine("\t\t\tCongratulations PRISONER!!! ");
				Console.WriteLine("\t\t\t\tyou just BROKE FREE. ");
				Console.WriteLine("\t\t\t\t\tEnjoy your freedom");
			}
			else if (wardenWins)
			{
				Console.WriteLine("\t\t\tWell done WARDEN!!! ");
				Console.WriteLine("\t\t\t\tyou just PREVENTED a breakout");
				Console.WriteLine("\t\t\t\t\ta reward awaits you");
			}
			else if (prisonerKilled)
			{
				Console.WriteLine("\t\t\tOH PRISONER, that vicious DOG KILLED you");
				Console.WriteLine("\t\t\t\tA life Term in HELL awaits you");
				Console.WriteLine("\t\t\t\t\tEnjoy the heat");
			}
			else {
				Console.WriteLine("\t\t\tOH WARDEN, that vicious DOG KILLED you");
				Console.WriteLine("\t\t\t\tA new job awaits you...");
				Console.WriteLine("\t\t\t\t\t...In HELL!!!");
			}

			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(0, H - 1);
			Console.Write("press enter to exit ");
			Console.ReadLine();
		}
	}
}
