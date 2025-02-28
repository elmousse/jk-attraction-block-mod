using System.Collections.Generic;
using JumpKing.API;
using JumpKing.Level;
using JumpKing.Level.Sampler;
using JumpKing.Workshop;
using Microsoft.Xna.Framework;

namespace AttractionBlockMod
{
    public class AttractionBlockFactory : IBlockFactory
    {
        private HashSet<Color> _blockCodes = new HashSet<Color>
        {
            new Color(70, 70, 70)
        };
        
        public bool CanMakeBlock(Color blockCode, Level level)
        {
            return _blockCodes.Contains(blockCode);
        }
        
        public bool IsSolidBlock(Color blockCode)
        {
            return false;
        }
        
        public IBlock GetBlock(
            Color blockCode,
            Rectangle blockRect,
            Level level,
            LevelTexture textureSrc,
            int currentScreen,
            int x,
            int y)
        {
            var block = new AttractionBlock(blockRect, 2f, 1.5f);
            AttractionBlockManager.Instance.AddAttractionBlock(currentScreen, block);
            return block;
        }
    }
}