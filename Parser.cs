using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Vieyra1802490_ParsingPrototype
{
    class Parser
    {
        public string inputText;
        public string outputText;
        public string inventoryText;

        delegate string ParseCommand(string[] parameters);

        //NOTE NEED TO UPDATE PROTOTYPE TO USE HASH TABLE
        Dictionary<string, ParseCommand> Commands = new Dictionary<string, ParseCommand>();
        Dictionary<string, string> Discriptions = new Dictionary<string, string>();
        Dictionary<string, string> Inventory = new Dictionary<string, string>();
       

        public Parser()
        {
            inputText = "";
        }

        public void Start()
        {
            Commands.Add("look", Look);
            Commands.Add("use", Use);
            Commands.Add("pickup", Pickup);

            Discriptions.Add("chest", "You see an old weatherworn iron chest.");
            Discriptions.Add("key", "Its a big bronze key.");
            Discriptions.Add("lamp", "It's providing a dim reddish light.");
        }

        public void Parse()
        {
            string output = "";
            string[] words = GetWords(inputText);            
            ParseCommand handler; 
            try
            {
                Commands.TryGetValue(words[0], out handler);
                output += handler(words);
            }
            catch(Exception ex)
            {
                outputText = "Please try again.";
            }
            

            outputText = output;
        }
        
        string[] GetWords(string s)
        {
            s = s.Trim().ToLower();
            return s.Split(' ');
        }

        string Look(string[] words)
        {
            string output = "";
            string lookAtObject;
            if(words[1] == "at")
            {
                lookAtObject = words[2];
            }
            else
            {
                lookAtObject = words[1];
            }

            try
            {
                string Description;
                Discriptions.TryGetValue(lookAtObject, out Description);
                output += Description;
            }
            catch (Exception ex)
            {
                outputText = "I dont see that object.";
            }

            outputText = output;
            return outputText;
        }

        string Use(string[] words)
        {
            string output = "";
            string useObject = words[1];
            string targetObject;

            if(words[2] == "on")
            {
                targetObject = words[3];
            }
            else
            {
                targetObject = words[2];
            }

            output += "You use the " + useObject + " on the " + targetObject;

            //Another Dictionary of Use Methods
            //      OR
            //Just add game Code
            if(targetObject == "chest" && useObject == "key")
            {
                Console.WriteLine("You opened the chest.");
            }
            outputText = output;
            return outputText;
        }

        string Pickup(string[] words)
        {
            string output = "";
            string pickupObject = words[1];

            try
            {
                string Description;
                Discriptions.TryGetValue(pickupObject, out Description);
                output += "You add " + pickupObject + " to your inventory.";
                Discriptions.Remove(pickupObject);
                Inventory.Add(pickupObject, Description);
                RefreshInventory();
            }
            catch (Exception ex)
            {
                outputText = "I can't do that.";
            }

            outputText = output;
            return outputText;
        }

        void RefreshInventory()
        {
            inventoryText = "";
            foreach(string s in Inventory.Values)
            {
                inventoryText += s + "\n";
            }
        }
    }
}
