using Assets.Utilities.SaveLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GameObjects.Characters.Player.Scripts
{
    public class PlayerSettings : MonoBehaviour
    {
        public float masterAudioVolume;
        public float inputSensitivity;

        public InterfaceController interfaceController;


        public void SetPlayerSettingsFromLoad(SerializablePlayerSettings loadedSettings)
        {
            Debug.Log("SettingPlayerSettings From Loaded Settings");
            masterAudioVolume = loadedSettings.masterAudioVolume;
            inputSensitivity = loadedSettings.inputSensitivity;

            interfaceController.UpdateSettingsUI(this);
        }
    }
}
