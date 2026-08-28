namespace DSAReview
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public bool IsPriority { get; set; }
        public Passenger(int passengerId, string name, bool isPriority)
        {
            PassengerId = passengerId;
            Name = name;
            IsPriority = isPriority;
        }
    }
}