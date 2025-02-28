using System.Collections.Generic;

namespace AttractionBlockMod
{
    public interface IAttractionBlockQuery
    {
        bool ScreenHasAttractionBlock(int screen);
        List<AttractionBlock> GetAttractionBlocks(int screen);
    }
}