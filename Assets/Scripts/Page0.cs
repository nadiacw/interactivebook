using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;

public class Page0 : MonoBehaviour
{
    // OUTLINE FOR PAGE 0 // ABCD QUIZ

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
        if (activeTrackables.Count == 1)
        {
            TrackableBehaviour trackablePage = activeTrackables[0];
            print("Touched event on book page number " + trackablePage.Trackable.ID);

                    // What pin was touched?
                    switch (pin)
                    {
                        // TODO: add only pins on page 0 (A, B, C, D quiz)
                        case 0:
                            if (touched)
                            {
                                print("touched 0: now a visual will be activated"); 
                            }
                            else
                            {
                                print("UN touched 0: now a visual will be deactivated");
                            }
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                    }

        }


    }



}
