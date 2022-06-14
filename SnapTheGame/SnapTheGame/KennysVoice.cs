namespace SnapTheGame
{
    internal static class KennysVoice
    {
        internal const string Separator = "----------------------------------------------------------------------- ";
        internal const string Kenny = " Kenny the Unbeatable";
        internal static string WelcomeMessage = $"{Separator}\n Welcome to Snap! What's your name?\n{Separator}";
        internal static string PleasureMessage = " Pleasure to meet you ";
        internal static string IntroductionMessage = $". I'm{Kenny}\n";
        internal static string InstructionsMessage = $" Before we start, here are some simple instructions:\n{Separator}\n A full deck of cards will be shuffled specially for you just\n so you don't think I'm cheating. Then I'll deal the cards between us.\n When the game starts, press any key to flip the top card from your pile\n When you spot that our cards' ranks match press the Spacebar\n We will see if you can do it faster than me (obviously not..)\n{Separator}\n I'll let you start\n Press any key when you're ready\n";
        internal static string NewDeckMessage = "'A new deck has entered the room..' ";
        internal static string AttentionMessage = " I'll shuffle the deck now so pay attention..";
        internal static string ShuffledMessage = " Done";
        internal static string PlayersTurn = " It's your turn now ";
        internal static string KennysTurn = " It's my turn ";
        internal static string KennyWinsMessage = $"\n{Separator}\n Ha! Told you! I am{Kenny} for a reason!\n{Separator}\n";
        internal static string PlayerWinsMessage = $"\n{Separator}\n Nooooo... You won! how?!?!\n{Separator}\n";
    }
}
