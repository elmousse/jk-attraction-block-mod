using System.Diagnostics;
using EntityComponent;
using JumpKing.BodyCompBehaviours;
using JumpKing.Level;
using JumpKing.Mods;
using JumpKing.Player;

namespace AttractionBlockMod
{
    [JumpKingMod("McOuille.AttractionBlockMod")]
    public static class ModEntry
    {
        [BeforeLevelLoad]
        public static void BeforeLevelLoad()
        {
            Debugger.Launch();
            AttractionBlockManager.Instance.Clear();
            
            LevelManager.RegisterBlockFactory(new AttractionBlockFactory());
        }
        
        [OnLevelStart]
        public static void OnLevelStart()
        {
            var player = EntityManager.instance.Find<PlayerEntity>();
            if (player?.m_body == null)
            {
                return;
            }
            
            // register the block behaviour
            player.m_body.RegisterBlockBehaviour<AttractionBlock>(new AttractionBlockBehaviour());

            // register the velocity update behaviour
            var existingBehaviours = player.m_body.GetBehaviourList();

            foreach (var behaviour in existingBehaviours)
            {
                if (!(behaviour is WindVelocityUpdateBehaviour))
                {
                    continue;
                }
                var newBehaviour = new AttractionVelocityUpdateBehaviour();
                player.m_body.RegisterBehaviourAfter(newBehaviour, behaviour);
                break;
            }
        }
        
        [OnLevelUnload]
        public static void OnLevelUnload()
        {
            AttractionBlockManager.Instance.Clear();
        }
    }
}
