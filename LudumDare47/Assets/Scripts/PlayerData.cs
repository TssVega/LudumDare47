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
    public static int ageNumber {
        get; set;
    } = 0;
    public static bool mute = false;

    public static string lastPlace = "Hospital";
    public static string exitPointName = "Home";

    public static void Interact(int index) {
        ++Interactions[index];
        --InteractionsLeft;
        ++StoryProgress;
        if(PAge == Age.Child) {
            ageNumber += 2;
        }
        else if(PAge == Age.Young) {
            ageNumber += Random.Range(2, 5);
        }
        else if(PAge == Age.Adult) {
            ageNumber += Random.Range(12, 18);
        }
        else if(PAge == Age.Old) {
            ageNumber += Random.Range(4, 12);
        }
        if(InteractionsLeft <= 0) {
            ChangeAge();
            InteractionsLeft = 3;
        }
    }

    public static void ResetLifeData() {
        lastPlace = "Hospital";
        exitPointName = "Home";
        InteractionsLeft = 3;
        StoryProgress = 0;
        PAge = Age.Child;
        for(int i = 0; i < Interactions.Length; i++) {
            Interactions[i] = 0;
        }
        ageNumber = 0;
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

    public static HealthData CheckHealth() {
        string cause = "";
        bool isDead = false;
        // Childhood
        if(StoryProgress == 3) {
            if(Interactions[4] <= 0) {
                cause = "Sleep deprivation";
                isDead = true;
            }
            else if(Interactions[5] <= 0) {
                cause = "Hunger";
                isDead = true;
            }
        }
        // Youth
        else if(StoryProgress == 6) {
            if(Interactions[5] <= 1) {
                cause = "Hunger";
                isDead = true;
            }
            else if(Interactions[7] <= 0) {
                cause = "Influenza";
                isDead = true;
            }
        }
        // Adulthood
        else if(StoryProgress == 9) {
            if(Interactions[8] <= 0) {
                cause = "Poverty";
                isDead = true;
            }
            else if(Interactions[4] <= 1) {
                cause = "Sleep deprivation";
                isDead = true;
            }
            else if(Interactions[0] <= 0 && Interactions[1] <= 0 && Interactions[2] <= 0 && Interactions[3] <= 0) {
                cause = "Depression";
                isDead = true;
            }
        }
        // Old age
        else if(StoryProgress == 12) {
            if(Interactions[5] <= 2) {
                cause = "Hunger";
                isDead = true;
            }
            else if(Interactions[0] + Interactions[1] + Interactions[2] + Interactions[3] <= 1) {
                cause = "Depression";
                isDead = true;
            }
            else {
                cause = "Old age";
                ageNumber += 10;
                isDead = true;
            }
        }
        HealthData health = new HealthData(isDead, cause, ageNumber.ToString());
        return health;
    }

    public static void Die() {
        ResetLifeData();
    }
}
