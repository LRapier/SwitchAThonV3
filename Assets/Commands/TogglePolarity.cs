
    public class TogglePolarity : Command
    {
        private PlayerMovement _movement;

        public TogglePolarity(PlayerMovement movement)
        {
            _movement = movement;
        }

        public override void Execute()
        {
            _movement.TogglePolarity();
        }
    }
