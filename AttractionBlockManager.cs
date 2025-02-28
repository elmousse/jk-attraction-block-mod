using System.Collections.Generic;

namespace AttractionBlockMod
{
    public class AttractionBlockManager : IAttractionBlockQuery
    {
        private static AttractionBlockManager _instance;
        public static AttractionBlockManager Instance => _instance ?? (_instance = new AttractionBlockManager());
        
        private Dictionary<int, List<AttractionBlock>> _attractionBlocks = new Dictionary<int, List<AttractionBlock>>();

        public bool ScreenHasAttractionBlock(int screen)
        {
            return _attractionBlocks.ContainsKey(screen);
        }
        
        public List<AttractionBlock> GetAttractionBlocks(int screen)
        {
            return _attractionBlocks[screen];
        }
        
        public void AddAttractionBlock(int screen, AttractionBlock block)
        {
            if (!_attractionBlocks.ContainsKey(screen))
            {
                _attractionBlocks.Add(screen, new List<AttractionBlock>());
            }
            _attractionBlocks[screen].Add(block);
        }
        
        public void Clear() => _attractionBlocks.Clear();
    }
}