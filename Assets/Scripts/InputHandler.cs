using UnityEngine;


    public class InputHandler : MonoBehaviour
    {
        private Invoker _invoker;
        public bool _isReplaying = false;
        public bool _isRecording;
        private PlayerMovement _playerMovement;
        private Command _buttonA, _buttonD, _buttonSpace;
        public GameObject replayText;

        void Start()
        {
            _invoker = gameObject.AddComponent<Invoker>();
            _playerMovement = FindObjectOfType<PlayerMovement>();

            _buttonA = new MoveLeft(_playerMovement);
            _buttonD = new MoveRight(_playerMovement);
            _buttonSpace = new TogglePolarity(_playerMovement);

            StartRecording();
        }

        void Update()
        {
            if (!_isReplaying && _isRecording)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    _invoker.ExecuteCommand(_buttonSpace);
            }
        }

        void FixedUpdate()
        {
            if (!_isReplaying && _isRecording)
            {
                if (Input.GetKey(KeyCode.A))
                    _invoker.ExecuteCommand(_buttonA);

                if (Input.GetKey(KeyCode.D))
                    _invoker.ExecuteCommand(_buttonD);
            }
        }

    public void StartRecording()
        {
            _isRecording = true;
            _invoker.Record();
        }

        public void StopRecording()
        {
            _isRecording = false;
        }

        public void StartReplay()
        {
            _playerMovement.ResetPosition();
            _playerMovement.enabled = true;
            _isRecording = false;
            _isReplaying = true;
            _invoker.Replay();
            replayText.SetActive(true);
        }

        public void StopReplay()
        {
            _isReplaying = false;
    }
    }