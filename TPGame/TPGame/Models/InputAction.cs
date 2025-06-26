using System;

namespace TPGame.Models
{
    public class InputAction
    {
        public InputAction(string[] inputSplit)
        {
            Command = inputSplit[0].ToLower();
            Target = inputSplit.Length > 1 ? inputSplit[1].ToLower() : null;
            Target += inputSplit.Length > 2 ? " " + inputSplit[2].ToLower() : "";
        }

        public string Command { get; set; }
        public string Target { get; set; }
    }
}
