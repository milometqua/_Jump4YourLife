using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = -1;
    [SerializeField] private TextMeshProUGUI ScoreText;
    void OnEnable()
    {
        Messenger.AddListener<float>(EventKey.UPDATE_UI, UpScore);
    }
    void OnDisable()
    {
        Messenger.RemoveListener<float>(EventKey.UPDATE_UI, UpScore); // Always remember to remove this listener
    }
    private void UpScore(float distance)
    {
        if(distance < -3f)
        {
            score += 2;
        }
        else
        {
            score += 1;
        }
        Debug.Log(score);
        ScoreText.text = score.ToString();
    }

    //Đã áp dụng Observer,nhưng đặt tên sự kiện quá chung chung,UPDATE_UI gì? điểm? 
    //anh có idea clean hơn.
    //Chẳng hạn sau này em có hiện điểm ở những chỗ khác thì sao? Ví dụ hiện ở trong màn PausePanel,GameOverPanel -> ? không lẽ lại khai báo thêm biến Text rồi kéo thả vào à


    //Solution:
    //class ScoreManager này em só thể để là static cũng được, có biến Score,hàm Set hàm Add, thậm chí sau có thể có hàm Save nữa    
    //private static int Score;
  
    //public static void AddScore(int amount)
    //{
    //    Score += amount;
    //    Messenger.Broadcast(EventKey.OnChangeScore);
    //}
    //public static void SetScore(int value)
    //{
    //    Score= value;
    //    Messenger.Broadcast(EventKey.OnChangeScore);
    //}

    // tạo một thằng ScoreView listen cái Event OnChangeScore,
    /*
    public class ScoreView:MonoBehaviour //thấy clean hơn không? Thằng nào muốn hiện điểm thì cứ add component này vào là xong,kiểu game over cũng có hiện score chẳng hạn
    {
        [SerializeField] TextMeshProUGUI scoreTxt;
        private void OnEnable()
        {
            OnChangeScore();
            Messenger.AddListener(EventKey.OnChangeScore, OnChangeScore);
        }

        private void OnChangeScore()
        {
            scoreTxt.SetText(ScoreManager.Score.ToString());
        }

        private void OnDisable()
        {
            Messenger.RemoveListener(EventKey.OnChangeScore, OnChangeScore);
        }
        
        
        private void OnValidate()
        {
            scoreTxt=GetComponent<TextMeshProUGUI>();
        }
    }
    */
}
