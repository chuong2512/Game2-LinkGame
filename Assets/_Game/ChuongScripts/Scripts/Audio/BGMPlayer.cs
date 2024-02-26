namespace ChuongCustom
{
    using UnityEngine;

    public class BGMPlayer : MonoBehaviour
    {
        private void Start()
        {
            MasterAudioManager.ReplayBackgroundMusic();
        }
        
#if UNITY_EDITOR
        [Sirenix.OdinInspector.Title("Testing Sound")]
        [Sirenix.OdinInspector.Button]
        void Test2DSfx(string sound)
        {
            MasterAudioManager.Play2DSfx(sound);
        }
        
        [Sirenix.OdinInspector.Button]
        void Test3DSfxTrans(string sound, Transform trans)
        {
            MasterAudioManager.Play3DSfxAtTransform(sound, trans);
        }
        
        [Sirenix.OdinInspector.Button]
        void Test3DSfxPosition(string sound, Vector3 pos)
        {
            MasterAudioManager.Play3DSfxAtPosition(sound, pos);
        }
#endif
    }
}