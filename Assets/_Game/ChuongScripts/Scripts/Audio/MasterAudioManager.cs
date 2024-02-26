namespace ChuongCustom
{
    using UnityEngine;

    public static class MasterAudioManager
    {
        private static float _musicVolume;
        private static float _sfxVolume;

        private static bool _temporarySfxFlag;

        /// <summary>
        /// This must be called in very first of the game.
        /// </summary>
        public static void LoadSettings()
        {
            /*_musicVolume = settings.MusicVolume;
            _sfxVolume   = settings.SfxVolume;*/
        }

        /// <summary>
        /// Force true. Run before scene goes
        /// </summary>
        public static void ReplayBackgroundMusic()
        {
            _temporarySfxFlag = false;
            SetPlaylistVolume(_musicVolume);
            SetSFXVolume(_sfxVolume);
            
            AudioWrapper.Replay();
        }

        public static void NextPlaylistClip(string playlistName)
        {
            AudioWrapper.NextPlaylistClip(playlistName);
        }

        public static void RandomPlaylistClip(string playlistName)
        {
            AudioWrapper.RandomPlaylistClip(playlistName);
        }

        public static void PlayPlaylistClip(string playlistName, string clipName)
        {
            if (string.IsNullOrEmpty(clipName))
            {
#if UNITY_EDITOR
                Debug.LogError("Clip name is null or empty");
#endif
                return;
            }

            AudioWrapper.PlayPlaylistClip(playlistName, clipName);
        }

        public static void TemporaryStopAll()
        {
            _temporarySfxFlag = true;
            AudioWrapper.StopEverything();
        }

        public static bool IsSfxPlaying(string soundName)
        {
            return AudioWrapper.IsSoundGroupPlaying(soundName);
        }
        
        public static void ChangeSfxPitch(string soundName, float pitch)
        {
            AudioWrapper.ChangePitchOfSound(soundName, pitch);
        }

        public static void Play2DSfx(string soundName, float delay = 0f)
        {
            if (_temporarySfxFlag)
            {
                bool ignore = soundName.StartsWith("ui") || soundName.StartsWith("game") || soundName.StartsWith("accomp");
                if (!ignore) return;
            }

            if (string.IsNullOrEmpty(soundName))
            {
#if UNITY_EDITOR
                Debug.LogError("Sound name is null or empty");
#endif
                return;
            }

            if (_sfxVolume > 0f)
            {
                AudioWrapper.Play2DSound(soundName, delay);
            }
        }

        public static void Play3DSfxAtTransform(string soundName, Transform transform, float delay = 0f)
        {
            if (_temporarySfxFlag) return;
            
            if (string.IsNullOrEmpty(soundName))
            {
#if UNITY_EDITOR
                Debug.LogError("Sound name is null or empty");
#endif
                return;
            }

            if (_sfxVolume > 0f)
            {
                AudioWrapper.Play3DSoundAtTransform(soundName, transform, delay);
            }
        }

        public static void Play3DSfxAtPosition(string soundName, Vector3 position, float delay = 0f)
        {
            if (_temporarySfxFlag) return;
            
            if (string.IsNullOrEmpty(soundName))
            {
#if UNITY_EDITOR
                Debug.LogError("Sound name is null or empty");
#endif
                return;
            }

            if (_sfxVolume > 0f)
            {
                AudioWrapper.Play3DSoundAtPosition(soundName, position, delay);
            }
        }

        public static void StopSpecificSfx(string soundName) { AudioWrapper.StopSpecificSFX(soundName); }

        public static void SetSpecific2DSfx(string soundName, bool value, float delay = 0f)
        {
            if (value) Play2DSfx(soundName, delay);
            else StopSpecificSfx(soundName);
        }

        public static void SetSpecific3DSfxAtTransform(string soundName, Transform trans, bool value, float delay = 0f)
        {
            if (value) Play3DSfxAtTransform(soundName, trans, delay);
            else StopSpecificSfx(soundName);
        }

        public static void SetSpecific3DSfxAtPosition(string soundName, Vector3 position, bool value, float delay = 0f)
        {
            if (value) Play3DSfxAtPosition(soundName, position, delay);
            else StopSpecificSfx(soundName);
        }


        public static void SetPlaylistVolume(float volume)
        {
            if (volume >= 0 && volume <= 1f)
            {
                _musicVolume = volume;
                AudioWrapper.SetPlaylistVolume(volume);
            }
        }

        public static void SetSFXVolume(float volume)
        {
            if (volume >= 0 && volume <= 1f)
            {
                _sfxVolume = volume;
                AudioWrapper.SetSFXVolume(volume);
            }
        }

        public static void PauseSfx(string sfx)
        {
            AudioWrapper.PauseSfx(sfx);
        }
        
        public static void PauseSfx(string[] sfxs)
        {
            for (int i = 0; i < sfxs.Length; i++)
            {
                PauseSfx(sfxs[i]);
            }
        }

        public static void UnpauseSfx(string sfx)
        {
            AudioWrapper.UnpauseSfx(sfx);
        }
        
        public static void UnpauseSfx(string[] sfxs)
        {
            for (int i = 0; i < sfxs.Length; i++)
            {
                UnpauseSfx(sfxs[i]);
            }
        }
        
        
        public static void ClickSound()
        {
            Play2DSfx(AudioConst.ClickSound);
        }
    }
}