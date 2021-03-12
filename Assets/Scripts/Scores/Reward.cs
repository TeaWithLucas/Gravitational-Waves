namespace Game.Scores {
    public class Reward {
        public string Id { get; protected set; }
        public int PlayerAmount { get; protected set; }
        public int TeamAmount { get; protected set; }

        public Reward(string id, int player, int team) {
            PlayerAmount = player;
            TeamAmount = team;

            Id = id;
        }


    }
}