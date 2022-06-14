using System;

namespace SnapTheGame
{
    internal class Program
    {
        private static SnapLogic _snapLogic;
        private static string _playerName;

        static void Main()
        {
            Console.WriteLine(KennysVoice.WelcomeMessage);            
            _playerName = Console.ReadLine();

            Console.WriteLine($"{KennysVoice.PleasureMessage}{_playerName}{KennysVoice.IntroductionMessage}{KennysVoice.InstructionsMessage}");            
            Console.ReadKey();

            _snapLogic = new SnapLogic(_playerName);
            _snapLogic.StartGame();
        }
    }
}
