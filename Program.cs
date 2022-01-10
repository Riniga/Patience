using Patience;

PlayIdioten(100000);

void PlayIdioten(int numberofgames)
{ 
    Console.WriteLine($"Play 'idioten' {numberofgames} times!");
    Deck copy = new();
    Deck winner = new();

    int winning = 0;
    for (int i = 0;i< numberofgames; i++)
    { 
        Deck deck = new Deck();
        deck.Scramble();
        copy.Clear();
        foreach (var card in deck) copy.Push(card);

        Patience.Idioten game = new Patience.Idioten(deck);

        if (game.Play())
        {
            winning++;
            winner.Clear();
            foreach (var card in copy) winner.Push(card); 
        }
    }

    Console.WriteLine("Winning Deck");
    Console.WriteLine("---------------");
    winner.Print();
    Console.WriteLine($"Number of winning games = {winning} this is {((double)winning*100 / numberofgames)} %");
}