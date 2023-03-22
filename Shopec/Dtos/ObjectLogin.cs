namespace Shopec.Data
{
	public class ObjectLogin
    {
        public Principal principal { get; set; }
    }

    public class Principal
    {
        public int id { get; set; }


        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string usertype { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int zip { get; set; }
        public string state { get; set; }
        public string emailAddress { get; set; }
        public int phoneNumber { get; set; }
    }
}