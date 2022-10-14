using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    // Всегда ставить модификатор доступа. Чаще всего private
    public float speed = 10f;
    private Vector2 lastClickPos;
    private bool moving;
    public int coins = 0;
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject gameWinMenu;
    private Camera cam;
    private List<Vector2> points = new List<Vector2>();

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (points.Count != 0)
        {
            moving = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            lastClickPos = cam.ScreenToWorldPoint(Input.mousePosition);

            points.Add(lastClickPos);


        }

        if (moving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, points[0], step);

            if (transform.position.x == points[0].x && transform.position.y == points[0].y)
            {
                points.RemoveAt(0);
                moving = false;

            }
        }
        else
        {
            moving = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin") 
        {
            coins++;
            textCoins.text = "Coins: " + coins.ToString();
            other.gameObject.SetActive(false);
            if(coins == RandomSpawn.countCoins)
            {
                gameObject.SetActive(false);
                gameWinMenu.SetActive(true);
            }

        }

        else if (other.gameObject.tag == "Thorn")
        {
            gameObject.SetActive(false);
            gameOverMenu.SetActive(true);
        }
    }
}
