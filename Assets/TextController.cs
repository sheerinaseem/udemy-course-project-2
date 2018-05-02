using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom };
    private States myState;

    
    // Use this for initialization
    void Start() {
        myState = States.cell;
    }

    // Update is called once per frame
    void Update()
    {
        print(myState);
        if (myState == States.cell) { State_cell(); }
        else if (myState == States.sheets_0) { State_sheets_0(); }
        else if (myState == States.mirror) { State_mirror(); }
        else if (myState == States.lock_0) { State_lock_0(); }
        else if (myState == States.sheets_1) { State_sheets_1(); }
        else if (myState == States.lock_1) { State_lock_1(); }
        else if (myState == States.cell_mirror) { State_cell_mirror(); }
        else if (myState == States.freedom) { State_freedom(); }
    } 


    void State_cell()
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

    void State_sheets_0()
    {
        text.text = "You can't believe you sleep in those things. Surely it's " +
                    "time somebody changed those sheets. The pleasure of prison life " +
                    "I guess!\n\n" +
                    "Press R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))            {myState = States.cell;}
    }

    void State_sheets_1()
    {
        text.text = "Holding the mirror in your hand doesn't make the sheet look " +
                    "any better.\n\n" +
                    "Press R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))            {myState = States.cell;}
    }

    void State_mirror()
    {
        text.text = "The dirty old mirror on the wall seems loose.\n\n" +
                    "Press T to take the Mirror, or R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))            {myState = States.cell;
        } else if (Input.GetKeyDown(KeyCode.T))     { myState = States.cell_mirror; }
    }

    void State_lock_0()
    {
        text.text = "This is one of those button locks. You have no idea what the " +
                    "combination is. You wish you could just somehow see where the dirty " +
                    "fingerprints were. Maybe that would help.\n\n" +
                    "Press R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R))            {myState = States.cell;}
    }

    void State_lock_1()
    {
        text.text = "You carefully put the mirror through the bars and turn it round " +
                    "so you can see the lock. You can just make out fingerprints around " +
                    "the buttons,. You press the dirty buttons and hear a click.\n\n" +
                    "Press O to Open or R to return to your cell.";
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.cell; }
        else if (Input.GetKeyDown(KeyCode.O)) { myState = States.freedom; }
    }

    void State_cell_mirror()
    {
        text.text = "You are still in your cell and you still want to escape! There are " +
                    "some dirty sheets on the bed. A mark where the mirror was, " +
                    "and the presky door is still there and firmly locked.\n\n" +
                    "Press S to view Sheets or L to view Lock.";
        if (Input.GetKeyDown(KeyCode.S))            { myState = States.sheets_1; }
        else if (Input.GetKeyDown(KeyCode.L))       { myState = States.lock_1; }
    }

    void State_freedom()
    {
        text.text = "You are FREE! \n\n" +
                    "Press P to Play again.";
        if (Input.GetKeyDown(KeyCode.P)) { myState = States.cell; }
    }

}
