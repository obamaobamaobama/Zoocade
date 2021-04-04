using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DebugController : MonoBehaviour
{
   bool showConsole;
   string input;
   //list of commands here
   public List<object> commandList;
    public static DebugCommand SKIP;
   public static DebugCommand<int> PLAY_GAME;
   
   
  

       void Awake()
    {
        PLAY_GAME = new DebugCommand<int>("!play", "load game", "play",(x) => //(command line, description, reads format)
        {
            SceneManager.LoadScene(x);
        });

        commandList = new List<object>
        {
            PLAY_GAME,
            SKIP
        };

    }
    public void Update()
   {
       if(Input.GetKeyDown(KeyCode.BackQuote)) // open console
       {
           Debug.Log("Show Console");
           OnToggleDebug();
       }
       if (Input.GetKeyDown(KeyCode.Return))
       {
           Debug.Log("enter");
           OnReturn();
       }
   }
    public void OnToggleDebug()
     {
         showConsole = !showConsole;
     }
     public void OnReturn()
     {
         if(showConsole)
         {
             HandleInput();
             input = "";
         }
     }

     //private void /// <summary>
     /// OnGUI is called for rendering and handling GUI events.
     /// This function can be called multiple times per frame (one call per event).
     /// <///summary>
     void OnGUI()
     {
         if (!showConsole) {return;}

         float y = 0f;

         GUI.Box(new Rect(0, y, Screen.width, 30),"");
         GUI.backgroundColor = new Color(0, 0, 0, 0);
         input = GUI.TextField(new Rect(10f, y + 5f, Screen.width-20f, 20f), input);

        if (Event.current.keyCode == KeyCode.Return)
       {
           Debug.Log("enter");
           OnReturn();
       }
     }
    private void HandleInput()
    {
        string[] properties = input.Split(' '); //handles another variable when there is a space
        for(int i=0; i<commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (input.Contains(commandBase.commandId))
            {
                if(commandList[i] as DebugCommand != null)
                {
                    //cast to this type and incoke the command
                    (commandList[i] as DebugCommand).Invoke();
                }
                else if (commandList[i] as DebugCommand<int> != null)
                {
                    (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
              
                }
            }
        }
    }
}