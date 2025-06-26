using TPGame.Handlers;
using TPGame.Models;
using TPGame.Dictionaries;

namespace TPGame.Items
{
    public class ToolBelt : Item
    {
        public ToolBelt()
        {
            Name = "tool belt";
            Description = "A modified utilty belt prepared to hold any items you find that seem useful, no matter how impratically sized.";
        }

        public override void GetItem()
        {
            DialogueHandler.PrintLine("You strap your tool belt around your waist and adjust the size to acccount for your recent weight loss.");
            DialogueHandler.AddPause(200);
            DialogueHandler.PrintLine("You look great.");
            DialogueHandler.AddPause(100);
            base.GetItem("You feel great.");
        }

        public override void UseItem()
        {
            DialogueHandler.PrintLine("You look at your belt to see what all you've collected.");
            Collections.ListInventory();
        }
    }
}
