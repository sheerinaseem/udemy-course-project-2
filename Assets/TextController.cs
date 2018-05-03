using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1,
                        freedom, corridor_0, stairs_0, floor, closet_door, stairs_1, corridor_1, in_closet, stairs_2, corridor_2, corridor_3, courtyard  };
    private States myState;

    
    // Use this for initialization
    void Start() {
        myState = States.cell;
    }

    // Update is called once per frame
    void Update()
    {
        print(myState);
        if      (myState == States.cell)                { Cell(); }
        else if (myState == States.sheets_0)            { Sheets_0(); }
        else if (myState == States.mirror)              { Mirror(); }
        else if (myState == States.lock_0)              { Lock_0(); }
        else if (myState == States.sheets_1)            { Sheets_1(); }
        else if (myState == States.lock_1)              { Lock_1(); }
        else if (myState == States.cell_mirror)         { Cell_mirror(); }
        else if (myState == States.corridor_0)          { Corridor_0(); }
        else if (myState == States.freedom)             { Freedom(); }
        else if (myState == States.stairs_0)            { Stairs_0(); }
        else if (myState == States.floor)               { Floor(); }
        else if (myState == States.closet_door)         { Closet_door(); }
        else if (myState == States.stairs_1)            { Stairs_1(); }
        else if (myState == States.corridor_1)          { Corridor_1(); }
        else if (myState == States.in_closet)           { In_closet(); }
        else if (myState == States.stairs_2)            { Stairs_2(); }
        else if (myState == States.corridor_2)          { Corridor_2(); }
        else if (myState == States.corridor_3)          { Corridor_3(); }
        else if (myState == States.courtyard)           { Courtyard(); }
    } 


    void Cell()
    {
        text.text = "You are in a prison cell, and you want to escape. There are " +
                    "some dirty sheets on the bed, a mirror on the wall, and the door " +
                    "is locked from the outside.\n\n" +
                    "Press S to view Sheets, M to view Mirror and L to view Lock.";
        if (Input.GetKeyDown(KeyCode.S))             {myState = States.sheets_0;
        }else if (Input.GetKeyDown(KeyCode.L))       { myState = States.lock_0;
        }else if (Input.GetKeyDown(KeyCode.M))       { myState = States.mirror;
        }
    }

    void Sheets_0()
    {
        text.text = "You can't believe you sleep in those things. Surely it's " +
                    "time somebody changed those sheets. The pleasure of prison life " +
                    "I guess!\n\n" +
                    "Press R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))            {myState = States.cell;}
    }

    void Sheets_1()
    {
        text.text = "Holding the mirror in your hand doesn't make the sheet look " +
                    "any better.\n\n" +
                    "Press R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))            {myState = States.cell;}
    }

    void Mirror()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to take the Mirror, or R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))            {myState = States.cell;
        } else if (Input.GetKeyDown(KeyCode.T))     { myState = States.cell_mirror; }
    }

    void Lock_0()
    {
        text.text = "This is one of those button locks. You have no idea what the " +
                    "combination is. You wish you could just somehow see where the dirty " +
                    "fingerprints were. Maybe that would help.\n\n" +
                    "Press R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))            {myState = States.cell;}
    }

    void Lock_1()
    {
        text.text = "You carefully put the mirror through the bars and turn it round " +
                    "so you can see the lock. You can just make out fingerprints around " +
                    "the buttons,. You press the dirty buttons and hear a click.\n\n" +
                    "Press O to Open or R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
        else if (Input.GetKeyDown(KeyCode.O)) { myState = States.corridor_0; }
    }

    void Cell_mirror()
    {
        text.text = "You are still in your cell and you still want to escape! There are " +
                    "some dirty sheets on the bed. A mark where the mirror was, " +
                    "and the presky door is still there and firmly locked.\n\n" +
                    "Press S to view Sheets or L to view Lock.";
        if (Input.GetKeyDown(KeyCode.S))            { myState = States.sheets_1; }
        else if (Input.GetKeyDown(KeyCode.L))       { myState = States.lock_1; }
    }

    void Freedom()
    {
        text.text = "You are FREE! \n\n" +
                    "Press P to Play again.";
        if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }
    }

    void Courtyard()
    {
        text.text = "You walk through the courtyard dressed as a cleaner." +
                    "The guard tips his hat at you as you walk past, claiming your freedom." +
                    "Your heart races as you walk intp the sunset.\n\n" +
                    "Press P to Play again.";
        if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }
    }

    void Corridor_0()
    {
        text.text = "You're out of your cell, but not out of trouble. " +
                    "You are in the corridor, there's a closet and some stairs leading to "+
                    "the courtyard. There's also various detrius on the floor. \n\n" +
                    "Press S to take the Stairs, F to inspect the Floor, C to view the Closet.";
        if (Input.GetKeyDown(KeyCode.S))            { myState = States.stairs_0; }
        else if (Input.GetKeyDown(KeyCode.F))       { myState = States.floor; }
        else if (Input.GetKeyDown(KeyCode.C))       { myState = States.closet_door; }
    }

    void Stairs_0()
    {
        text.text = "You start walking up the stairs towards the outside light. " +
                    "You realize it's not break time. You will be caught immediately. "+
                    "You slither back down the stairs and reconsider.\n\n"+
                    "Press R to return to the corridor.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_0; }
    }

    void Floor()
    {
        text.text = "You found a hairclip on the floor.\n\n" +
                    "Press T to take the clip and or R to return to the corridor.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_0; }
        else if (Input.GetKeyDown(KeyCode.T)) { myState = States.corridor_1; }
    }

    void Closet_door()
    {
        text.text = "You are looking at a closet door, unfortunately it's locked. " +
                    "Maybe you could find something around to help encourage it open?\n\n"+
                    "Press R to return to the corridor.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_0; }
    }

    void Stairs_1()
    {
        text.text = "Uh Oh, another dead end.\n\n" +
                    "Press R to return to the corridor 1.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_1; }
    }

    void Stairs_2()
    {
        text.text = "Uh Oh, another dead end.\n\n" +
                    "Press R to return to the corridor 2.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_2; }
    }

    void Corridor_1()
    {
        text.text = "There is staircase and a closet. See if you can use that hairclip to unlock the door?\n\n" +
                    "Press H to use the Hairclip , S to take the staircase or R to return to the corridor 1.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_1; }
        else if (Input.GetKeyDown(KeyCode.H)) { myState = States.in_closet; }
        else if (Input.GetKeyDown(KeyCode.S)) { myState = States.stairs_1; }
    }

    void Corridor_2()
    {
        text.text = "Back in the corridor, having declined to dress as a cleaner.\n\n" +
                    "Press S to use the Hairclip or R to return to the Closet.";
        if (Input.GetKeyDown(KeyCode.S)) { myState = States.stairs_2; }
        else if (Input.GetKeyDown(KeyCode.R)) { myState = States.in_closet; }
    }

    void In_closet()
    {
        text.text = "Inside the closet you see a cleaner's uniform that looks about your size. " +
                    "Seems like your day is picking up.\n\n"+
                    "Press D to Disguise or R to return to the Corridor 1.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_3; }
        else if (Input.GetKeyDown(KeyCode.D)) { myState = States.corridor_3; }
    }

    void Corridor_3()
    {
        text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner." +
                    "You strongly consider the run for the freedom.\n\n"+
                    "Press S to take the Stairs or U to undress.";
        if (Input.GetKeyDown(KeyCode.S)) { myState = States.courtyard; }
        else if (Input.GetKeyDown(KeyCode.U)) { myState = States.in_closet; }
    }

}
