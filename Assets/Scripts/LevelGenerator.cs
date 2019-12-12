using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private Vector3 startPos = new Vector3(-10, -4.95f, 0);
    private int totalSegments = 10;
    private int currentSegmentCount = 0;

    public GameObject startSegment;
    public GameObject endSegment;

    public GameObject[] segments;
    public GameObject[] enemies;
    public GameObject[] powerups;

    public GameObject coin;

    private Segment previousSegment;
    private Segment currentSegment;

    private Vector3 playerPosition {
        get {
            return PlayerManager.instance.transform.position;
        }
    }

    private void Awake() {
        StartLevelGen();
    }

    public void StartLevelGen() {
        var start = Instantiate(startSegment);
        start.transform.position = startPos;

        currentSegmentCount++;
        currentSegment = Instantiate(segments[Random.Range(0, segments.Length)]).GetComponent<Segment>();
        currentSegment.transform.position = startPos + new Vector3(30 * currentSegmentCount, 0, 0);
        currentSegment.Generate(this);
    }

    private void Update() {
        if(playerPosition.x > (startPos.x + (currentSegmentCount * 30) + 10)) {
            Progress();
        }
    }

    public void Progress() {
        if(previousSegment) {
            Destroy(previousSegment.gameObject);
        }

        if(currentSegmentCount == 9) {
            var end = Instantiate(endSegment);
            currentSegmentCount ++;
            end.transform.position = startPos + new Vector3(30 * currentSegmentCount, 0, 0);
        } else {

            currentSegmentCount++;

            previousSegment = currentSegment;
            currentSegment = Instantiate(segments[Random.Range(0, segments.Length)]).GetComponent<Segment>();
            currentSegment.transform.position = startPos + new Vector3(30 * currentSegmentCount, 0, 0);
            currentSegment.Generate(this);
        }
    }
}
