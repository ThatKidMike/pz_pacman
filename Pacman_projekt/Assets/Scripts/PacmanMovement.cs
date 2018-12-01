using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PacmanMovement : MonoBehaviour {

    public AudioClip sound1;
    public AudioClip sound2;

    private Vector2 startingPos = new Vector2(1.5f, -5);

    public float velocity = 4f;
    private Vector2 go;
    public Vector2 direction = Vector2.right;
    //Vector2 position;
    public GameObject find;
    public PillsSpawn lookFor;
    public Vector2 orientation;

    public RuntimeAnimatorController deathAnimation;
    public RuntimeAnimatorController eatingAnimation;

    public bool afterDeathMovement = false;

    private bool playedSound1 = false;

    private AudioSource deathSound;
    private bool deathStarted = false;

    private GameObject background;
    private GameObject backgroundFear;
    private GameObject soundOfDeath;
    private GameObject introSound;
    public AudioSource backgroundSound;
    public AudioSource backgroundFearSound;
    private AudioSource deathAudioSource;
    private AudioSource introMusic;
    

    private AudioSource _audio;

    public GameObject red;
    public GameObject blue;
    public GameObject orange;
    public GameObject pink;

    private Pink_movement pScript;
    private Orange_movement oScript;
    private Blue_movement bScript;
    private red_movement rScript;

    private GameObject canvas;
    private Canvas readyCanvas;

    public int score = 0;
    public int playerCharLives = 3;

    public Text scoreText;
    public Text up1;
    public Image lives1;
    public Image lives0;
    public Text highScore;

    private GameObject checkForPellets;
    private GameObject checkForPellets1;
    private GameObject checkForPellets2;
    private GameObject checkForPellets3;



    // Use this for initialization
    void Start () {

        find = GameObject.Find("PillsSpawn");
        lookFor = find.GetComponent<PillsSpawn>();
        transform.position = new Vector2(1.5f, -5);
        _audio = gameObject.GetComponent<AudioSource>();
        //position = gameObject.transform.position;

        red = GameObject.Find("ghost");
        blue = GameObject.Find("ghost_blue");
        orange = GameObject.Find("ghost_orange");
        pink = GameObject.Find("ghost_pink");

        pScript = pink.GetComponent<Pink_movement>();
        oScript = orange.GetComponent<Orange_movement>();
        bScript = blue.GetComponent<Blue_movement>();
        rScript = red.GetComponent<red_movement>();

        background = GameObject.Find("background_sound");
        backgroundFear = GameObject.Find("fearModeSound");
        soundOfDeath = GameObject.Find("DeathSound");
        backgroundSound = background.GetComponent<AudioSource>();
        backgroundFearSound = backgroundFear.GetComponent<AudioSource>();
        deathSound = soundOfDeath.GetComponent<AudioSource>();

        introSound = GameObject.Find("IntroSound");
        introMusic = background.GetComponent<AudioSource>();

        canvas = GameObject.Find("Canvas");
        readyCanvas = canvas.GetComponent<Canvas>();
        highScore.text = StaticStas.Points.ToString();

        StartGame();


    }
	
	// Update is called once per frame
	void Update () {

        if (!afterDeathMovement) {

            CheckInput();
            //Move();
            moveToNxtPoint(direction);
            UpdateUI();
          

            if(lookFor.amount <= 0) {

                
                rScript.afterDeathMovement = true;
                bScript.afterDeathMovement = true;
                pScript.afterDeathMovement = true;
                oScript.afterDeathMovement = true;

                gameObject.GetComponent<Animator>().enabled = false;
                afterDeathMovement = true;
                backgroundSound.enabled = false;
                backgroundFearSound.enabled = false;

                StaticStas.Points = score;
                //highScore.text = StaticStas.Points.ToString();

                StartCoroutine(ProcessEnd(4));

            } 


        }

	}

    IEnumerator ProcessEnd(float delay) {

        yield return new WaitForSeconds(delay);


        SceneManager.LoadScene("End title screen");


    }

    void UpdateUI() {

        scoreText.text = score.ToString();

        if(playerCharLives == 3) {

            lives0.enabled = true;
            lives1.enabled = true;

        } else if(playerCharLives == 2) {

            lives0.enabled = true;
            lives1.enabled = false;

        } else if(playerCharLives == 1) {

            lives0.enabled = false;
            lives1.enabled = false;

        }

    }

    public void StartGame() {

        red.transform.GetComponent<SpriteRenderer>().enabled = false;
        blue.transform.GetComponent<SpriteRenderer>().enabled = false;
        pink.transform.GetComponent<SpriteRenderer>().enabled = false;
        orange.transform.GetComponent<SpriteRenderer>().enabled = false;
        rScript.afterDeathMovement = true;
        bScript.afterDeathMovement = true;
        pScript.afterDeathMovement = true;
        oScript.afterDeathMovement = true;

        gameObject.transform.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
        afterDeathMovement = true;
        backgroundSound.enabled = false;
        introMusic.Play();

        StartCoroutine(SpawnStart(2.25f));

    }

    IEnumerator SpawnStart(float delay) {

        yield return new WaitForSeconds(delay);

        red.transform.GetComponent<SpriteRenderer>().enabled = true;
        blue.transform.GetComponent<SpriteRenderer>().enabled = true;
        pink.transform.GetComponent<SpriteRenderer>().enabled = true;
        orange.transform.GetComponent<SpriteRenderer>().enabled = true;

        gameObject.transform.GetComponent<SpriteRenderer>().enabled = true;


        introMusic.enabled = false;
        StartCoroutine(StartGameAfter(2));


    }

    IEnumerator StartGameAfter (float delay) {

        yield return new WaitForSeconds(delay);

        backgroundSound.enabled = true;
        rScript.afterDeathMovement = false;
        bScript.afterDeathMovement = false;
        pScript.afterDeathMovement = false;
        oScript.afterDeathMovement = false;
        afterDeathMovement = false;
        readyCanvas.enabled = false;
        gameObject.GetComponent<Animator>().enabled = true;

    }

    IEnumerator AfterDeathSpawning(float delay) {

        readyCanvas.enabled = true;

        _audio.enabled = false;

        pScript.Restart();
        oScript.Restart();
        bScript.Restart();
        rScript.Restart();

        transform.position = startingPos;
        direction = Vector2.right;
        transform.rotation = Quaternion.Euler(0, 0, 0);

        gameObject.transform.GetComponent<Animator>().enabled = false;

        red.transform.GetComponent<SpriteRenderer>().enabled = true;
        blue.transform.GetComponent<SpriteRenderer>().enabled = true;
        pink.transform.GetComponent<SpriteRenderer>().enabled = true;
        orange.transform.GetComponent<SpriteRenderer>().enabled = true;

        gameObject.transform.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.transform.GetComponent<Animator>().runtimeAnimatorController = eatingAnimation;

        yield return new WaitForSeconds(delay);

        Restart();


    }


    public void DeathStart() {

        if(!deathStarted) {

            deathStarted = true;

            rScript.afterDeathMovement = true;
            oScript.afterDeathMovement = true;
            pScript.afterDeathMovement = true;
            bScript.afterDeathMovement = true;
            afterDeathMovement = true;

            gameObject.transform.GetComponent<Animator>().enabled = false;
            backgroundSound.Stop();
            backgroundFearSound.Stop();

            StartCoroutine(ProcessDeathAfter(2));

        }



    }

    IEnumerator ProcessDeathAfter(float delay) {

        yield return new WaitForSeconds(delay);

        red.GetComponent<SpriteRenderer>().enabled = false;
        blue.GetComponent<SpriteRenderer>().enabled = false;
        pink.GetComponent<SpriteRenderer>().enabled = false;
        orange.GetComponent<SpriteRenderer>().enabled = false;

        StartCoroutine(ProcessDeathAnimation(1.9f));

    }

    IEnumerator ProcessDeathAnimation(float delay) {

        gameObject.transform.localScale = new Vector3(1, 1, 1);
        gameObject.transform.localRotation = Quaternion.identity;

        gameObject.transform.GetComponent<Animator>().runtimeAnimatorController = deathAnimation;
        gameObject.GetComponent<Animator>().enabled = true;

        deathSound.Play();

        yield return new WaitForSeconds(delay);

        StartCoroutine(ProcessRestart(2));

    }

    IEnumerator ProcessRestart(float delay) {

        playerCharLives--;

        gameObject.transform.GetComponent<SpriteRenderer>().enabled = false;

        transform.GetComponent<AudioSource>().Stop();

        if(playerCharLives <= 0) {

            StaticStas.Points = score;
            //highScore.text = StaticStas.Points.ToString();
            SceneManager.LoadScene("End title screen");

        }

        yield return new WaitForSeconds(delay);

        StartCoroutine(AfterDeathSpawning(2.5f));
    }

    public void Restart() {

       // playerCharLives--;

        if(playerCharLives > 0) {

            readyCanvas.enabled = false;

            rScript.afterDeathMovement = false;
            oScript.afterDeathMovement = false;
            pScript.afterDeathMovement = false;
            bScript.afterDeathMovement = false;
            afterDeathMovement = false;
            deathStarted = false;

            gameObject.GetComponent<Animator>().enabled = true;
            
            backgroundSound.Play();
            backgroundFearSound.Play();
            _audio.enabled = true;

        }  

    }

    public void PlaySound() {

        if(playedSound1) {

            _audio.PlayOneShot(sound1);
            playedSound1 = false;

        } else {

            _audio.PlayOneShot(sound2);
            playedSound1 = true;

        }
    }


    // Checks for User's input and adjusts the movement direction and the facing direction
    void CheckInput() {
      
        if(Input.GetKeyDown(KeyCode.LeftArrow) && /*valid(new Vector2(-2, 0)) &&*/ canMove(Vector2.left)) {

            if(!direction.Equals(Vector2.left)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0 - 180, 0);
                direction = Vector2.left;
                moveToNxtPoint(direction);
            }
            //Debug.Log("Left");

        } else if(Input.GetKeyDown(KeyCode.RightArrow) && /*valid(new Vector2(2, 0)) &&*/ canMove(Vector2.right)) {

            if(!direction.Equals(Vector2.right)) {
                transform.rotation = Quaternion.identity;
                direction = Vector2.right;
                moveToNxtPoint(direction);
            }
            //Debug.Log("Right");

        } else if(Input.GetKeyDown(KeyCode.UpArrow) && /*valid(new Vector2(0, 2)) &&*/ canMove(Vector2.up)) {

            if(!direction.Equals(Vector2.up)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0, 0 + 90);
                direction = Vector2.up;
                moveToNxtPoint(direction);
            }
            //Debug.Log("Up");

        } else if(Input.GetKeyDown(KeyCode.DownArrow) && /*valid(new Vector2(0, -2)) &&*/ canMove(Vector2.down)) {

            if(!direction.Equals(Vector2.down)) {
                transform.rotation = Quaternion.identity;
                transform.Rotate(0, 0, 0 - 90);
                direction = Vector2.down;
                moveToNxtPoint(direction);
            }
            //Debug.Log("Down");

        }
  
    }

    //Is not used for now
    void Move() {

         //Vector2 position = (transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime); 
        if (lookFor.xy[(int)Math.Round(transform.position.x) + 30, (int)Math.Round(transform.position.y) + 30] == 1) {
            transform.localPosition += (Vector3)(direction * velocity) * Time.deltaTime;
        }

    }

    void moveToNxtPoint(Vector2 d) {

        Vector2 currPosition = transform.localPosition;
        // transform.localPosition = new Vector2((int)Math.Round(currPosition.x + d.x), (int)Math.Round(currPosition.y + d.y));
        Vector2 targetPos = new Vector2((int)Math.Round(currPosition.x + d.x), (int)Math.Round(currPosition.y + d.y));
        transform.localPosition = Vector2.MoveTowards(currPosition, targetPos, velocity * Time.deltaTime * 1.3f);
        
    }

    bool valid(Vector2 dir) {
        // Cast Line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }

    bool canMove(Vector2 d) {

        Vector2 currPosition = transform.localPosition;

        if(lookFor.xy[(int)Math.Round(currPosition.x + d.x) + 30, (int)Math.Round(currPosition.y + d.y) + 30] == 1) {
            return true;
        } else {
            return false;
        }

    }


}
