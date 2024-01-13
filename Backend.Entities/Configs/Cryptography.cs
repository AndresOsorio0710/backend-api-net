namespace Backend.Entities.Configs
{
    public class Cryptography
    {
        public string Key { get; set; }
        public string IV { get; set; }
        public int Iterations { get; set; }

        public Cryptography(string Key, string IV, string Iterations)
        {
            this.Key = Key;
            this.IV = IV;
            this.Iterations = int.Parse(Iterations);
        }
    }
}
