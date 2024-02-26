namespace ChuongCustom
{
    using DarkTonic.MasterAudio;
    using UnityEngine;

    internal static class AudioWrapper
    {
        /// <summary>
        /// Play a sound.
        /// </summary>
        /// <param name="soundName">The sound group's name</param>
        /// <param name="delay">Delay starting sound</param>
        /// <returns>Return whether or not sound is played</returns>
        public static void Play2DSound(string soundName, float delay = 0f)
        {
            if (MasterAudio.Instance)
            {
                MasterAudio.PlaySound(soundName, delaySoundTime: delay);
            }
        }
        
        /// <summary>
        /// Check whether or not the specific sound group is playing
        /// </summary>
        /// <param name="soundName">The sound group's name</param>
        /// <returns>Return whether or not sound is played</returns>
        public static bool IsSoundGroupPlaying(string soundName)
        {
            return MasterAudio.IsSoundGroupPlaying(soundName);
        }
        
        /// <summary>
        /// Change the pitch of specific sound
        /// </summary>
        /// <param name="soundName">The sound group's name</param>
        /// <param name="pitch">The pitch of sound</param>
        /// <returns>Return whether or not sound is played</returns>
        public static void ChangePitchOfSound(string soundName, float pitch)
        {
            MasterAudio.ChangeVariationPitch(soundName, true, "", pitch);
        }

        /// <summary>
        /// Play a sound.
        /// </summary>
        /// <param name="soundName">The sound group's name</param>
        /// <param name="transform">Transform of where sound will play</param>
        /// <param name="delay">Delay starting sound</param>
        /// <returns>Return whether or not sound is played</returns>
        public static void Play3DSoundAtTransform(string soundName, Transform transform, float delay = 0f)
        {
            if (MasterAudio.Instance)
            {
                MasterAudio.PlaySound3DAtTransform(soundName, transform, delaySoundTime: delay);
            }
        }
        
        /// <summary>
        /// Play a sound.
        /// </summary>
        /// <param name="soundName">The sound group's name</param>
        /// <param name="position">Position of where sound will play</param>
        /// <param name="delay">Delay starting sound</param>
        /// <returns>Return whether or not sound is played</returns>
        public static void Play3DSoundAtPosition(string soundName, Vector3 position, float delay = 0f)
        {
            if (MasterAudio.Instance)
            {
                MasterAudio.PlaySound3DAtVector3(soundName, position, delaySoundTime: delay);
            }
        }

        /// <summary>
        /// This need to call when unpause settings.
        /// </summary>
        public static void Replay()
        {
            MasterAudio.RestartPlaylist();
        }

        public static void NextPlaylistClip(string playlistName)
        {
            MasterAudio.TriggerNextPlaylistClip(playlistName);
        }
        
        public static void RandomPlaylistClip(string playlistName)
        {
            MasterAudio.TriggerRandomPlaylistClip(playlistName);
        }
        
        public static void PlayPlaylistClip(string playlistName, string clipName)
        {
            MasterAudio.StartPlaylistOnClip(playlistName, clipName);
        }

        /// <summary>
        /// Highly recommended to stop the audio
        /// </summary>
        public static void StopEverything()
        {
            MasterAudio.StopEverything();
        }

        public static void StopPlayList()
        {
            MasterAudio.StopAllPlaylists();
        }

        public static void StopSFX()
        {
            MasterAudio.StopMixer();
        }
        
        public static void StopSpecificSFX(string soundName)
        {
            MasterAudio.StopAllOfSound(soundName);
        }
        
        /// <summary>
        /// Just pause everything, I think this one is not really help. Just stop.
        /// </summary>
        public static void PauseEverything()
        {
            MasterAudio.PauseEverything();
        }

        public static void UnPauseEverything()
        {
            MasterAudio.UnpauseEverything();
        }

        /// <summary>
        /// Just mute everything ~ volume = 0. It's worse than pause.
        /// </summary>
        public static void MuteEverything()
        {
            MasterAudio.MuteEverything();
        }

        public static void UnMuteEverything()
        {
            MasterAudio.UnmuteEverything();
        }

        /// <summary>
        /// ~ Background Music volume. This is useful when you only need to change the background music.
        /// </summary>
        /// <param name="volume"></param>
        public static void SetPlaylistVolume(float volume)
        {
            MasterAudio.PlaylistMasterVolume = volume;
        }

        /// <summary>
        /// This set all sound effect's volume (buses and groups), except the playlists.
        /// </summary>
        /// <param name="volume"></param>
        public static void SetSFXVolume(float volume)
        {
            MasterAudio.MasterVolumeLevel = volume;
        }

        public static void PauseSfx(string sfx)
        {
            MasterAudio.PauseSoundGroup(sfx);
        }
        
        public static void UnpauseSfx(string sfx)
        {
            MasterAudio.UnpauseSoundGroup(sfx);
        }
    }
}