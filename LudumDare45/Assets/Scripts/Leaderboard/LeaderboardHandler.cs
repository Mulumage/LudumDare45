using UnityEngine;
using UnityEngine.Networking;

public class LeaderboardHandler : MonoBehaviour
{
    private const string PRIVATE_CODE = "h7Txr8cH80OKkfQqXF5IcALdKeUnwZbUCzapmY-Tdjgw";
    private const string PUBLIC_CODE = "5d98d6b5d1041303ec29819c";
    private const string WEB_URL = "http://dreamlo.com/lb/";


    [SerializeField] private Leaderboard _leaderboard;
    private bool _downloadFailed;

    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _scoreElement;

    private void Start()
    {
        DownloadScores();

        if (_downloadFailed || _leaderboard.entry == null)
            return;

        UpdateUi();
    }

    public static void UploadScore(string name, int value)
    {
        var webRequest =
            new UnityWebRequest(WEB_URL + PRIVATE_CODE + "/add/" + UnityWebRequest.EscapeURL(name) + "/" + value);
        webRequest.SendWebRequest();
        
        while (!webRequest.isDone && string.IsNullOrEmpty(webRequest.error))
            print(webRequest.downloadProgress);
        
        if (!string.IsNullOrEmpty(webRequest.error))
            Debug.Log("Downloading Error: " + webRequest.error);
    }

    private void DownloadScores()
    {
        var webRequest = new UnityWebRequest(WEB_URL + PUBLIC_CODE + "/pipe/");
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        webRequest.SendWebRequest();

        while (!webRequest.isDone && string.IsNullOrEmpty(webRequest.error))
            print(webRequest.downloadProgress);

        if (string.IsNullOrEmpty(webRequest.error))
        {
            var dreamlo = webRequest.downloadHandler.text;
            PopulateLeaderboard(dreamlo);
        }
        else
        {
            _downloadFailed = true;
            Debug.Log("Downloading Error: " + webRequest.error);
        }
    }

    private void PopulateLeaderboard(string text)
    {
        _leaderboard = new Leaderboard();

        var entries = text.Split(new char[]{'\n'}, System.StringSplitOptions.RemoveEmptyEntries);

        foreach (var t in entries)
        {
            var entry = new Entry();
            var entryInfo = t.Split('|');
            entry.name = entryInfo[0];
            entry.score = int.Parse(entryInfo[1]);
            _leaderboard.entry.Add(entry);
        }
    }


    private void UpdateUi()
    {
        for (var i = 0; i < _leaderboard.entry.Count; i++)
        {
            var entry = _leaderboard.entry[i];
            var go = Instantiate(_scoreElement, _content);
            var element = go.GetComponent<ScoreElement>();

            element.Order.text = (i + 1).ToString();
            element.Name.text = entry.name;
            element.Score.text = entry.score.ToString();
        }
    }
}