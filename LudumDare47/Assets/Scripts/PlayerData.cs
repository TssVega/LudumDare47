using UnityEngine;
using System.Collections;

public static class PlayerData {

    public static int[] Interactions {
        get; set;
    } = new int[9];
    public static Age PAge {
        get; set;
    }
    public static int StoryProgress {
        get; set;
    } = 0;
    public static int InteractionsLeft {
        get; set;
    } = 3;

    public static string lastPlace = "Hospital";
    public static string exitPointName = "Home";

    public static void Interact(int index) {
        ++Interactions[index];
        --InteractionsLeft;
        if(InteractionsLeft <= 0) {
            ChangeAge();
            InteractionsLeft = 3;
        }
    }

    public static void ResetLifeData() {
        InteractionsLeft = 3;
        StoryProgress = 0;
        PAge = Age.Child;
        for(int i = 0; i < Interactions.Length; i++) {
            Interactions[i] = 0;
        }
    }

    public static void ChangePlace(string placeName) {
        lastPlace = placeName;
    }

    public static void ChangeAge() {
        if(PAge == Age.Child) {
            PAge = Age.Young;
        }
        else if(PAge == Age.Young) {
            PAge = Age.Adult;
        }
        else if(PAge == Age.Adult) {
            PAge = Age.Old;
        }
        else if(PAge == Age.Old) {
            PAge = Age.Dead;
        }
    }

    public static void Die() {
    
    }
}
