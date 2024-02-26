namespace ChuongCustom
{
    using UnityEngine;

    public class AnimationAudioCaller : StateMachineBehaviour
    {
        public string audioName;
        public bool   loop;
        
        [Range(1, 100)]
        [Tooltip("Time for audio call in %")]
        [Sirenix.OdinInspector.LabelText("Audio call time (in %)")]
        public float audioTimeEvent = 50f;
        
        private float _prepareTime = -1f;
        
        private float _timing;
        private bool  _allowUpdate;
        private bool  _triggered;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            _timing = 0f;

            if (_prepareTime < 0f)
            {
                _prepareTime = stateInfo.length * (audioTimeEvent / 100f);
            }

            if (!string.IsNullOrEmpty(audioName))
            {
                _allowUpdate = true;
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_allowUpdate)
            {
                _timing += Time.deltaTime;
                if (_timing >= _prepareTime && !_triggered)
                {
                    MasterAudioManager.Play2DSfx(audioName);
                    _triggered = true;

                    // If no loop, do not update
                    if (!loop)
                    {
                        _allowUpdate = false;
                    }
                }

                if (loop)
                {
                    if (_timing >= stateInfo.length)
                    {
                        _timing   = 0;
                        _triggered = false;
                    }
                }
            }   
        }
    }
}