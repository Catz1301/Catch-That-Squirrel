using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System.Security.Cryptography;
using System;

public class SquirrelMovement : MonoBehaviour
{
    public GameObject gameObj;
    public GameObject PlayerObject;

    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    //[System.Obsolete]
    private Vector3 position;
    private enum Direction {
        Forward,
        Backward,
        Left,
        Right
    };
    private Quaternion rotation;
    private bool destinationReached;
    private bool minDistanceTraveled;
    private Direction direction;
    private int minDistance = 50;
    private int distanceTraveled;
    private bool caught = false;
    
    
    bool moveForward() {
        bool done;
        
        System.Random rnd = new System.Random((int)System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        int keepGoingNum = rnd.Next(0, 500);

        
        done = false;
        if (minDistanceTraveled == true) {
            if (keepGoingNum == 1) {
                done = true;
            }
        }

        if (done == false)
            gameObj.transform.position = gameObj.transform.position + transform.forward;
        return done;
    }

    bool moveBackward() {
        bool done;

        System.Random rnd = new System.Random((int)System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        int keepGoingNum = rnd.Next(0, 500);


        done = false;
        if (minDistanceTraveled == true) {
            if (keepGoingNum == 1) {
                done = true;
            }
        }

        if (done == false)
            gameObj.transform.position = gameObj.transform.position - transform.forward;

        return done;
    }

    bool moveLeft() {
        bool done;

        System.Random rnd = new System.Random((int)System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        int keepGoingNum = rnd.Next(0, 500);


        done = false;
        if (minDistanceTraveled == true) {
            if (keepGoingNum == 1) {
                done = true;
            }
        }

        if (done == false)
            gameObj.transform.position = gameObj.transform.position - transform.right;

        return done;
    }

    bool moveRight() {
        bool done;

        System.Random rnd = new System.Random((int)System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        int keepGoingNum = rnd.Next(0, 500);


        done = false;
        if (minDistanceTraveled == true) {
            if (keepGoingNum == 1) {
                done = true;
            }
        }

        if (done == false)
            gameObj.transform.position = gameObj.transform.position + transform.right;
        return done;
    }

    void Start() {

        //navMeshAgent = gameObj.GetComponent<NavMeshAgent>();
        //gameObj.transform.rotation.SetEulerRotation(gameObj.transform.rotation.ToEuler().x - 90, 0, 0);
        
        System.DateTime time = System.DateTime.Now;
        int seed = time.Millisecond;
        //Random.InitState(seed);
        //SetNewDestination();
        position = gameObj.transform.position;
        rotation = gameObj.transform.rotation;

        destinationReached = true;
        minDistanceTraveled = false;

        distanceTraveled = 0;
    }

    // Update is called once per frame
    void Update() {
        if (Time.timeScale == 1) {
            if (gameObj.transform.position.y < -7.2) {
                gameObj.transform.position = new Vector3(gameObj.transform.position.x, -6.9f, gameObj.transform.position.z);
            }
            if (destinationReached == true) {
                //int dir = (int)(Random.value * 4) + 1;
                //Debug.Log(dir);
                System.Random random = new System.Random();
                int direct = random.Next(0, 3);

                if (direct == 0)
                    direction = Direction.Forward;
                else if (direct == 1)
                    direction = Direction.Backward;
                else if (direct == 2)
                    direction = Direction.Left;
                else
                    direction = Direction.Right;

            }
            if (direction == Direction.Forward) {
                destinationReached = moveForward();
            }
            else if (direction == Direction.Backward) {
                destinationReached = moveBackward();
            }
            else if (direction == Direction.Left) {
                destinationReached = moveLeft();
            }
            else if (direction == Direction.Right) {
                destinationReached = moveRight();
            }

            distanceTraveled++;
            if (distanceTraveled == minDistance)
                minDistanceTraveled = true;

            float sx = gameObj.transform.position.x;
            float sy = gameObj.transform.position.y;
            float sz = gameObj.transform.position.z;
            float px = PlayerObject.transform.position.x;
            float py = PlayerObject.transform.position.y;
            float pz = PlayerObject.transform.position.z;


            bool xVic;
            if (px >= sx - 5 && px <= sx + 5) {
                xVic = true;
            }
            else {
                xVic = false;
            }

            bool yVic;
            if (py >= sy - 5 && py <= sy + 5) {
                yVic = true;
            }
            else {
                yVic = false;
            }

            bool zVic;
            if (pz >= sz - 5 && pz <= sz + 5) {
                zVic = true;
            }
            else {
                zVic = false;
            }

            if (xVic && yVic && zVic && caught == false) {
                GetSquirrels.squirrelsCaught++;
                caught = true;
                gameObj.SetActive(false);
            }
            //Debug.Log(
            //    "pathStatus: " + navMeshAgent.pathStatus + "\n" +
            //    "nextPosition" + navMeshAgent.nextPosition + "\n" +
            //    "remainingDistance: " + navMeshAgent.remainingDistance + "\n" +
            //    "pathEndPosition: " + navMeshAgent.pathEndPosition + "\n" +
            //    "path: " + navMeshAgent.path
            //);
        }
    }
}
