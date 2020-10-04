using UnityEngine;
using System.Collections;

public class Enums : MonoBehaviour {

}

public enum Wealth {
    None, Poor, Rich
}

public enum Childhood {
    None, Inside, Outside
}

public enum TeenagePersonality {
    None, Nerd, Jock
}

public enum Alignment {
    None, Evil, Neutral, Good
}
// At some point in life there will be a critical choice
// This might get the player in jail or make them rich
public enum CriticalChoiceResult {
    None, Jail, Lottery, Marriage, Nothing
}
