using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    public Player Player { get; private set; }
    public bool Ready = false;

    public void SetPlayerInfo(Player player, bool ready)
    {
        Player = player;
        if (player.IsMasterClient)
        {
            if(player.IsLocal)
                _text.text = player.NickName + " (masterclient) (you)";
            else
                _text.text = player.NickName + " (masterclient)";
        }
        else
        {
            if (player.IsLocal)
                _text.text = player.NickName + " (you)";
            else
            {
                if (ready)
                    _text.text = player.NickName + " (ready)";
                else
                    _text.text = player.NickName + " (not ready yet)";
            }
        }
    }
}
