using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class PlayerNameInputField : MonoBehaviour
{
        // Store the PlayerPref Key to avoid typos
        const string playerNamePrefKey = "PlayerName";

        #region MonoBehaviour CallBacks

        /// MonoBehaviour method called on GameObject by Unity during initialization phase.

        void Start()
        {
            string defaultName = string.Empty;
            InputField _inputField = this.GetComponent<InputField>();
            if (_inputField != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                }
            }

            PhotonNetwork.NickName = defaultName;
        }


        #endregion


        #region Public Methods


        /// Sets the name of the player, and save it in the PlayerPrefs for future sessions.
        /// <param name="value">The name of the Player</param>
        public void SetPlayerName(string value)
        {
            // #Important
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player Name is null or empty");
                return;
            }
            PhotonNetwork.NickName = value;


            PlayerPrefs.SetString(playerNamePrefKey, value);
        }


        #endregion
    
}
