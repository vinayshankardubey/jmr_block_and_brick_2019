using UnityEngine;

// public class Ball : MonoBehaviour
// {
//     //Configuration parameters
//     [SerializeField] Paddle paddle1; //allows you to attach the paddle to the ball in Unity via drag & drop
//     [SerializeField] float xPush = 2f;
//     [SerializeField] float yPush = 15f;
//     [SerializeField] AudioClip[] ballSounds;
//     [SerializeField] float randomFactor = 0.2f;

//     // State
//     Vector2 paddleToBallVector;
//     bool hasStarted = false;

//     // Cached Componenet references
//     AudioSource myAudioSource;
//     Rigidbody2D myRigidBody2D; // physics on the ball happens with the RigidBody2D so we are caching this here so we can mess with the physics; want to cache if you're doing a get component more than once

//     // Start is called before the first frame update
//     void Start()
//     {
//         // paddleToBallVector = transform.position - paddle1.transform.position;
//         myAudioSource = GetComponent<AudioSource>();
//         myRigidBody2D = GetComponent<Rigidbody2D>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // if (!hasStarted)
//         // {
//         //     LockBallToPaddle();
//              LaunchOnMouseClick();
//         // }
//     }

//     

//     private void LockBallToPaddle()
//     {
//         Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
//         // transform.position = paddlePos + paddleToBallVector;
//                 // transform.position = paddlePos;

//     }

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         Vector2 velocityTweak = new Vector2
//             (Random.Range(0, randomFactor), 
//             Random.Range(0, randomFactor));

//         if (hasStarted)
//         {
//             AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
//             myAudioSource.PlayOneShot(clip);
//             myRigidBody2D.velocity += velocityTweak;
//         }
//     }
// }







public class Ball : MonoBehaviour{



    public ScoreScript scoresc;

    public Rigidbody2D rb;


void Start(){

        scoresc = FindObjectOfType<ScoreScript>();

        rb = GetComponent<Rigidbody2D>();
  rb.AddForce(Vector2.up * 90);
}

void Update(){
  Debug.Log("Ball Script Started");

}





    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log($"Collided ON {col.gameObject.name.ToString()}");

        if(col.gameObject.name.ToString()== "Breakable Block")
        {
            int sc = int.Parse(scoresc.score);
            scoresc.score = (sc + 5).ToString();
            Debug.Log(sc.ToString());

        }
    }


}