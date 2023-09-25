
    public class MoveLeft : Command
    {
        private PlayerMovement _movement;

        public MoveLeft(PlayerMovement movement)
        {
            _movement = movement;
        }

        public override void Execute()
        {
            _movement.MoveLeft();
        }
    }
