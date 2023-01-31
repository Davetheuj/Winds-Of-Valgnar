using Assets.GameObjects.Characters.Player.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Utilities.SaveLoad
{
    [Serializable]
    public class SerializablePlayerSettings
    {
        public float masterAudioVolume;
        public float inputSensitivity;

        public SerializablePlayerSettings(PlayerSettings loadedSettings)
        {
            masterAudioVolume = loadedSettings.masterAudioVolume;
            inputSensitivity = loadedSettings.inputSensitivity;
        }
    }
}
