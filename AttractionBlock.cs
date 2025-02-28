using System;
using JumpKing.Level;
using Microsoft.Xna.Framework;

namespace AttractionBlockMod
{
    public class AttractionBlock : IBlock, IBlockDebugColor
    {
        public Color DebugColor => new Color(70, 70, 70);
        
        private readonly Rectangle _blockRect;
        private readonly float _force;
        private readonly float _decay;

        public AttractionBlock(
            Rectangle blockRect,
            float force,
            float decay)
        {
            _blockRect = blockRect;
            _force = force;
            _decay = decay;
        }
        
        public Rectangle GetRect()
        {
            return _blockRect;
        }
        
        public BlockCollisionType Intersects(Rectangle playerHitbox, out Rectangle intersection)
        {
            if (_blockRect.Intersects(playerHitbox))
            {
                intersection = Rectangle.Intersect(playerHitbox, _blockRect);
                return BlockCollisionType.Collision_NonBlocking;
            }
            intersection = new Rectangle(0, 0, 0, 0);
            return BlockCollisionType.NoCollision;
        }
        
        public Vector2 GetAttractionVelocity(Vector2 playerPosition)
        {
            var blockCenter = _blockRect.Center.ToVector2();
            
            var distance = Math.Min(Vector2.Distance(blockCenter, playerPosition), 5f) ;

            if (distance == 0f)
            {
                return Vector2.Zero;
            }
            
            var direction = Vector2.Normalize(blockCenter - playerPosition);
            
            var force = _force / (float)Math.Pow(distance, _decay);
            if (force < 0.01f)
            {
                return Vector2.Zero;
            }
            return direction * force;
        }
    }
}