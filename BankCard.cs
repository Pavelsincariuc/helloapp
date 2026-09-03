class BankCard
{
    private string cardNumber;
    private decimal balance;
    private static int totalCards;

    public static int TotalCards
    {
        get { return totalCards; }
    }
    
    public BankCard(string cardNumber)
    {
        this.cardNumber = cardNumber;
        totalCards++;
    }
    
    public string CardNumber
    {
        get { return cardNumber; }
    }
    public decimal Balance
    {
        get { return balance; }
        set
        {
            if (value < 0)
                balance = 0;     
            else
                balance = value; 
        }
    }

    

}