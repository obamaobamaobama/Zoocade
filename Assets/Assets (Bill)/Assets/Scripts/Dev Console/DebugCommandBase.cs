using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // for the action delegate type down in DebugCommand class

public class DebugCommandBase //new class for making commands
{
   private string _commandId;
   private string _commandDescription;
   private string _commandFormat;

   public string commandId {get {return _commandId;} }
   public string commandDescription {get{return _commandDescription;}}

   public string commandFormat {get{return _commandFormat;}}

   public DebugCommandBase(string id, string description, string format)
   {
      _commandId = id;
      _commandDescription = description;
      _commandFormat = format;
   }
}
public class DebugCommand : DebugCommandBase
{
   private Action command; // action does not return a value, but delegate does
   public DebugCommand(string id, string description, string format, Action command): base (id, description, format)
   {
      this.command = command;
   }

   public void Invoke()
   {
      command.Invoke();
   }
  
}
 public class DebugCommand<T1> : DebugCommandBase // command with an int you want to put it
 {
    private Action<T1> command;
   public DebugCommand (string id, string description, string format, Action<T1> command): base (id, description, format)
   {
      this.command = command;
   }
   public void Invoke(T1 value)
   {
      command.Invoke(value);
   }

 }