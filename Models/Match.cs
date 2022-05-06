namespace Models
{
    public class Match
    {
        public int id { get; set; } = 0;
        public int userId { get; set; } = 0;
        public int opponentID { get; set; } = 0;
        public string matchResult { get; set; } = "Tie";


        public Match(int user, int opponentID, string result)
        {
            this.userId = user;
            this.opponentID = opponentID;
            this.matchResult = result;

            //List<Pokemon> pokeDex { get; set; }
        }
        public Match() { }
    }
}