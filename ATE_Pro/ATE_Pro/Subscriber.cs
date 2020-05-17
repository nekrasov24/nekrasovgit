namespace BillingSystem.Models.Classes
{
    public class Subscriber
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Money { get; private set; }

        public Subscriber(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Money = 30;
        }

        public void AddMoney(int money)
        {
            Money += money;
        }

        public void RemoveMoney(int money)
        {
            Money -= money;
        }
    }
}