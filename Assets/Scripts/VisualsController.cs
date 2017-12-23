using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System.Linq;
using System;
using System.Text.RegularExpressions;

public class VisualsController : MonoBehaviour
{

    public ArduinoConnection arduinoConnection;
    public List<GameObject> visuals;

    public bool bookON;

    private List<TrackableBehaviour> activeTrackables;
    private string lastPage;
    private string currentPage;

    private void Awake()
    {
        arduinoConnection.OnBookTouched += OnTouched;
    }


    void Start()
    {
        // Start with all visuals deactivated
        foreach (GameObject visual in visuals){
            visual.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get list of active trackables
        StateManager sm = TrackerManager.Instance.GetStateManager();
        activeTrackables = sm.GetActiveTrackableBehaviours().ToList();

    }

    public void OnTouched(int pin, bool touched)
    {

        // TODO: implement double pages!!!

        // If at leats one page is detected
        if (activeTrackables.Count > 0)
        {

            // Assuming we only have one page
            TrackableBehaviour trackablePage = activeTrackables[0];

            if (touched)
                print("Touched pin " + pin + " on single book page " + trackablePage.TrackableName);
            else
                print("Untouched pin " + pin + " on single book page " + trackablePage.TrackableName);

            // Switch condition for each page / tracker ID
            currentPage = trackablePage.TrackableName;


            // TODO: stop pages that are lost
            //CheckIfPageChanged();


            // IF statements for each page (not else if, because two can happen at once)
            if (currentPage == "trackercover")
            {
                switch(pin){

                    case 0: // pin that the "light switch" is connected to

                        if (touched)
                        {
                            visuals[0].SetActive(true);
                        }
                        else
                        {
                            visuals[0].SetActive(false);
                        }

                        break;
                    case 1:
                        break;

                }

            }
            if (currentPage == "trackerpage0")
            {
                switch (pin)
                {
                    case 0:

                        if (touched)
                        {
                            
                        }
                        else
                        {
                            
                        }

                        break;
                    case 1:
                        break;

                }
            }
            if (currentPage == "trackerpage1")
            {

            }
            if (currentPage == "trackerpage2")
            {

            }
            if (currentPage == "trackerpage3")
            {

            }
            if (currentPage == "trackerpage4")
            {

            }
            if (currentPage == "trackerpage5")
            {

            }

        }
        //// If it is a pair of pages
        //else if (activeTrackables.Count == 2)
        //{
        //    TrackableBehaviour trackablePage0 = activeTrackables[0];
        //    TrackableBehaviour trackablePage1 = activeTrackables[1];

        //    if (touched)
        //        print("Touched pin " + pin + " on double book page number " + trackablePage0.Trackable.ID + " - " + trackablePage1.Trackable.ID);
        //    else
        //        print("Untouched pin " + pin + " on double book page number " + trackablePage0.Trackable.ID + " - " + trackablePage1.Trackable.ID);

        //}

        // TODO: for pairs we can't use a switch! change to if statement


    }


    // TODO: redo this

    void CheckIfPageChanged()
    {
        if (lastPage != currentPage)
        {
            // Page changed!
            lastPage = currentPage;
            StopAllVisuals();
        }
        else
        {
            // Still on same page
        }
    }

    void StopAllVisuals()
    {
        // Stop all visuals
        foreach (GameObject visual in visuals)
        {
            if (visual != null)
                visual.SetActive(false);
        }
    }



}
