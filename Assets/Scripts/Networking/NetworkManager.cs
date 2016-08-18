using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;
    private string gameName = "Card_Bored_Game";
    private HostData[] hd;

    void OnGUI()
    {
        if (Network.isClient || Network.isServer)
        {
            return;
        }

        if (GUI.Button(new Rect(20, 20, 150, 30), "Start Server"))
        {
            StartServer();
            GameObject GameManager = Instantiate(gameManager, Vector3.zero, Quaternion.identity) as GameObject;
        }

        if (GUI.Button(new Rect(20, 60, 150, 30), "Refresh Host List"))
        {
            StartCoroutine(RefreshHost());
        }

        if (hd != null)
        {
            for (int i = 0; i < hd.Length; i++)
            {
                if (GUI.Button(new Rect(220, (20 + (i * 70)), 300, 30), hd[i].gameName))
                {
                    Network.Connect(hd[i]);
                    GameObject GameManager = Instantiate(gameManager, Vector3.zero, Quaternion.identity) as GameObject;
                }

                GUI.Box(new Rect(570, (20 + (i * 70)), 300, 30), hd[i].comment + " " + hd[i].connectedPlayers + "/4");
            }
        }
    }

    void StartServer()
    {
        Network.InitializeServer(4, 25002, false);
        MasterServer.RegisterHost(gameName, "Card Bored", "An available Card Bored match.");
    }

    IEnumerator RefreshHost()
    {
        MasterServer.RequestHostList(gameName);
        float startTime = Time.time;
        float endTime = Time.time + 5.0f;

        while (startTime < endTime)
        {
            hd = MasterServer.PollHostList();
            yield return new WaitForEndOfFrame();
        }
    }
}