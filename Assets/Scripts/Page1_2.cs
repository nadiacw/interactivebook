using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class Page1_2 : MonoBehaviour
{
    // OUTLINE FOR PAGES 1 AND 2 // +- LEVELS

    public ArduinoConnection arduinoConnection;

    private List<TrackableBehaviour> activeTrackables;

    private void Awake()
    {
        arduinoConnection.OnBookTouched += OnTouched;
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get list of active trackables
        StateManager sm = TrackerManager.Instance.GetStateManager();
        activeTrackables = sm.GetActiveTrackableBehaviours().ToList();
    }

    void OnTouched(int pin, bool touched)
    {

        // If it is a single page
        if (activeTrackables.Count == 2)
        {
            TrackableBehaviour trackablePage1 = activeTrackables[0];
            TrackableBehaviour trackablePage2 = activeTrackables[1];


            // What pin was touched?
            switch (pin)
            {
                // TODO: separate pins used on page 1 and ones used on page 2. 

                // PINS 0 to 5 -> page 1
                // PINS 6 to 11 -> page 2

                // Get ID with trackablePage1.Trackable.ID

                case 0:
                    if (touched)
                    {
                        // Touched
                    }
                    else
                    {
                        // Untouched
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;

                    // ...
            }

        }


    }



}
