
    public class MoveRight : Command
    {
        private PlayerMovement _movement;

        public MoveRight(PlayerMovement movement)
        {
            _movement = movement;
        }

        public override void Execute()
        {
            _movement.MoveRight();
        }
    }
