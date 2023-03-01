using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //The dropdown that displays resolutions.
    public TMPro.TMP_Dropdown resolutionDropdown;

    //Array for possible resolutions.
    Resolution[] resolutions;

    //Called before first frame.
    void Start ()
    {
        //Fills the array with all possible resolutions.
        resolutions = Screen.resolutions;

        //Clears all resultions in the dropdown.
        resolutionDropdown.ClearOptions();

        //List for all resolution options.
        List<string> options = new List<string>();

        //Variable to store the index of the currently active resolution.
        int currentResolutionIndex = 0;

        //Goes through the array of possible resolutions.
        for (int i = 0; i < resolutions.Length; i++)
        {
            //Creates an intuitive display of the resolution option.
            string option = resolutions[i].width + " x " + resolutions[i].height;

            //Adds the option to the list of resolution options.
            options.Add(option);

            //If the current resolution option is the same as the currently active resolution.
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                //Sets the currently acitve resolutions index.
                currentResolutionIndex = i;
            }
        }
        //Adds all resolution optiont to the resolution dropdown.
        resolutionDropdown.AddOptions(options);

        //Sets the selected resolution to the active resolution.
        resolutionDropdown.value = currentResolutionIndex;

        //Updates the dropdown to show active resolution.
        resolutionDropdown.RefreshShownValue();
    }

    //The resolution dropdown.
    public void Resolution (int resolutionIndex)
    {
        //Stores the selected resolution in a variable.
        Resolution resolution = resolutions[resolutionIndex];
        
        //Sets the current resolution to the resoulotion in the previous variable.
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //The quality dropdown.
    public void Quality (int qualityIndex)
    {
        //Sets the quality level to the selected level.
        QualitySettings.SetQualityLevel(qualityIndex);
        Debug.Log("Quality level set to: " + QualitySettings.GetQualityLevel());
    }

    //The fullscreen toggle.
    public void Fullscreen (bool isFullscreen)
    {
        //Toggles fullscreen on or off according to the toggle.
        Screen.fullScreen = isFullscreen;
        Debug.Log("Fullscreen = " + isFullscreen);
    }
}
