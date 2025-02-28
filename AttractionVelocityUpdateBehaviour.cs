using JumpKing;
using JumpKing.API;
using JumpKing.BodyCompBehaviours;
using JumpKing.Level;

namespace AttractionBlockMod
{
    public class AttractionVelocityUpdateBehaviour : IBodyCompBehaviour
    {
        public bool ExecuteBehaviour(BehaviourContext context)
        {
            var bodyComp = context.BodyComp;
            var hitbox = bodyComp.GetHitbox();
            var screen = LevelManager.CurrentScreen.GetIndex0();
            
            if (!AttractionBlockManager.Instance.ScreenHasAttractionBlock(screen))
            {
                return true;
            }
            
            var attractionBlocks = AttractionBlockManager.Instance.GetAttractionBlocks(screen);
            
            foreach (var block in attractionBlocks)
            {
                bodyComp.Velocity += block.GetAttractionVelocity(hitbox.Center.ToVector2());
            }
            
            return true;
        }
    }
}