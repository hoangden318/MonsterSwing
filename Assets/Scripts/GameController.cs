using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private bool isEndgame;
    public bool IsEndgame { get => isEndgame; }
    [SerializeField] protected bool isStartFirstTime;
    int gamePoint = 0;
      
    [SerializeField] protected Text txtPoint;
    [SerializeField] protected Text txtHighPoint;
    [SerializeField] protected GameObject panelEG;
    [SerializeField] protected Text txtYourPoint;
    [SerializeField] protected Button RestartGame;

   

    // Start is called before the first frame update
    void Start()
    {
        this.StartGameCtrl();
    }

    protected virtual void StartGameCtrl()
    {
        Time.timeScale = 0;
        isStartFirstTime = true;
        isEndgame = false;
        panelEG.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        this.GamePlaying();
    }

    protected virtual void GamePlaying()
    {
        if (isEndgame)
        {
            if (Input.GetMouseButtonDown(0) && isStartFirstTime)
            {
                //load man choi
                StartGame();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
            }
        }
    }
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point:"+ gamePoint.ToString();
    }
   void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        StartGame();
    }
    public void EndGame()
    {
       Time.timeScale = 0;
        isStartFirstTime=false;
        isEndgame = true;
        panelEG.SetActive(true);
        txtYourPoint.text = "Your Point: \n" + gamePoint.ToString();
       
       /* if (gamePoint >max)
        {
            max = gamePoint;
            txtHighPoint.text = "High Point: " + gamePoint.ToString();
        } */
    }
}
