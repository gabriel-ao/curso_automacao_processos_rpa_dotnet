namespace RobotEasyAutomation
{
    public class Checkout
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Payment { get; set; }
        public string NameCard { get; set; }
        public string CreditCard { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }


        public static Checkout Map(string line)
        {
            var values = line.Split(',');

            return new Checkout { 
                FirstName = values[0], 
                LastName = values[1],
                Username = values[2],
                Email = values[3],
                Address = values[4],
                Country = values[5],
                State = values[6],
                Zip = values[7],
                Payment = values[8],
                NameCard = values[9],
                CreditCard = values[10],
                Expiration = values[11],
                Cvv = values[12]
            };
        }
    }
}
